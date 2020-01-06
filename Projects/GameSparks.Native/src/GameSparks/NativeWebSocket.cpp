#include "../../include/GameSparks/NativeWebSocket.hpp"

#if defined(_WIN32)
#include <cassert>
#include <Windows.h>
#include <sstream>
#include <ppltasks.h>

static std::wstring utf8_to_wstring(const std::string& str)
{
	int output_size = MultiByteToWideChar(CP_UTF8, NULL, str.c_str(), static_cast<int>(str.size()), NULL, 0);
	assert(output_size > 0);
	std::vector<wchar_t> buffer(output_size);
	int result = MultiByteToWideChar(CP_UTF8, NULL, str.c_str(), static_cast<int>(str.size()), buffer.data(), static_cast<int>(buffer.size()));
	(void)result; // unused in release builds
	assert(result == output_size);
	std::wstring ret(buffer.begin(), buffer.end());
	return ret;
	//std::wstring_convert<std::codecvt_utf8<wchar_t>> myconv;
	//return myconv.from_bytes(str);
}

// convert wstring to UTF-8 string
static std::string wstring_to_utf8(const std::wstring& str)
{
	int output_size = WideCharToMultiByte(CP_UTF8, NULL, str.c_str(), static_cast<int>(str.size()), NULL, 0, NULL, NULL);
	assert(output_size > 0);
	std::vector<char> buffer(output_size);
	int result = WideCharToMultiByte(CP_UTF8, NULL, str.c_str(), static_cast<int>(str.size()), buffer.data(), static_cast<int>(buffer.size()), NULL, NULL);
	(void)result; // unused in release builds
	assert(result == output_size);
	std::string ret(buffer.begin(), buffer.end());
	return ret;

	//std::wstring_convert<std::codecvt_utf8<wchar_t>> myconv;
	//return myconv.to_bytes(str);
}

static std::string platform_to_std(Platform::String^ s)
{
	if (s == nullptr)
		return{};
	return wstring_to_utf8({ s->Begin(), s->End() });
}

std::set<const LivetimeGuard*> LivetimeGuard::aliveObjects;
std::recursive_mutex LivetimeGuard::mtx;

static constexpr size_t read_buffer_size = 1024 * 16;

using namespace Windows::Foundation;
using namespace Platform;

NativeWebSocket::NativeWebSocket()
{
}

NativeWebSocket::~NativeWebSocket()
{
	if (webSocket || webSocketIsOpen == true)
	{
		GSExternalClose(0);
	}
}

void NativeWebSocket::GSExternalOpen(int, string url, string gameObjectName, bool binary = false)
{
	this->isBinary = binary;
	if (webSocket || webSocketIsOpen == true)
	{
		GSExternalClose(0);
	}

	webSocket = ref new MessageWebSocket();
	webSocket->Control->MessageType = isBinary ? Windows::Networking::Sockets::SocketMessageType::Binary : Windows::Networking::Sockets::SocketMessageType::Utf8;

	Uri^ pUri = ref new Uri(ref new String(utf8_to_wstring(url).c_str()));

	webSocket->Closed += ref new TypedEventHandler<IWebSocket^, WebSocketClosedEventArgs^>([this](IWebSocket^, WebSocketClosedEventArgs^) {
		LivetimeGuard::guard lock(LivetimeGuard::mtx);
		if (!liveTimeGuard.isAlive()) return;

		webSocketIsOpen = false;
		PushResult({ Result::Type::Close, "Closed" });
	});

	webSocket->MessageReceived += ref new TypedEventHandler<MessageWebSocket^, MessageWebSocketMessageReceivedEventArgs^>([this](MessageWebSocket^, MessageWebSocketMessageReceivedEventArgs^ args) {
		LivetimeGuard::guard lock(LivetimeGuard::mtx);
		if (!liveTimeGuard.isAlive()) return;

		DataReader^ messageReader = args->GetDataReader();
		//messageReader->UnicodeEncoding = Windows::Storage::Streams::UnicodeEncoding::Utf8;

		auto array = ref new Platform::Array<unsigned char>(messageReader->UnconsumedBufferLength);
		messageReader->ReadBytes(array);

		if (this->isBinary) {
			string b64 = this->base64_encode(array->Data, array->Length);
			PushResult({ Result::Type::BinaryMessage, b64 });
		} else {
			string str((char*)array->begin(), (char*)array->end());
			PushResult({ Result::Type::Message, str });
		}
	});

	auto connectOp = webSocket->ConnectAsync(pUri);
	connectOp->Completed = ref new AsyncActionCompletedHandler([this](IAsyncAction^ asyncAction, AsyncStatus asyncStatus)
	{
		LivetimeGuard::guard lock(LivetimeGuard::mtx);
		if (!liveTimeGuard.isAlive()) return;

		switch (asyncStatus)
		{
			case AsyncStatus::Completed:
			{
				{
					webSocketIsOpen = true;
					PushResult({ Result::Type::Open, "opened" });
				}
			} break;

			case AsyncStatus::Error:
			{
				PushResult({Result::Type::Error, "failed to connect" });
			} break;

			case AsyncStatus::Canceled:
				break;

			case AsyncStatus::Started:
				break;

			default:
			{
				PushResult({ Result::Type::Error, "Unknown Status" });
			} break;
		}
	});

}


void NativeWebSocket::GSExternalClose(int)
{
	if (webSocket || webSocketIsOpen == true)
	{
		try
		{
			webSocketIsOpen = false;

			if (webSocket)
			{
				webSocket->Close(1000, "");
				delete webSocket;
				webSocket = nullptr;
			}
		}
		catch (const Platform::COMException^ e)
		{
			// we just ignore the exception
		}
		catch (Exception^ e)
		{
			// we just ignore the exception
		}
	}
	else
	{
		PushResult({Result::Type::Error, "Close() called on already closed socket." });
	}
}

void NativeWebSocket::GSExternalSendBinary(int, char message[], int offset, int length)
{
	if (webSocket && webSocketIsOpen == true)
	{

		char** dest = new char*[length];
		memcpy(dest, &message[offset], offset + length);

		Windows::Storage::Streams::DataWriter^ writer = ref new Windows::Storage::Streams::DataWriter(webSocket->OutputStream);
		Platform::Array<unsigned char>^ array = ref new Platform::Array<unsigned char>((unsigned char*)(dest), (unsigned int)length);
		writer->WriteBytes(array);

		delete dest;

		using namespace concurrency;

		// Send the data as one complete message
		create_task(writer->StoreAsync()).then([this, writer](unsigned int)
		{
			// Send Completed
			writer->DetachStream();    // give the stream back to m_messageWebSocket
		}).then([this](task<void> previousTask)
		{
			try
			{
				// Try getting all exceptions from the continuation chain above this point.
				previousTask.get();
			}
			catch (Platform::COMException ^ex)
			{
				LivetimeGuard::guard lock(LivetimeGuard::mtx);
				if (!liveTimeGuard.isAlive()) return;

				PushResult({ Result::Type::Error, "Error while sending data: " + platform_to_std(ex->Message) });
			}
		});
	}
	else
	{
		PushResult({ Result::Type::Error, "Send() called on closed or currently connecting WebSocket." });
	}
}


void NativeWebSocket::GSExternalSend(int, string message)
{
	if (webSocket && webSocketIsOpen == true)
	{
		Windows::Storage::Streams::DataWriter^ writer = ref new Windows::Storage::Streams::DataWriter(webSocket->OutputStream);
		Platform::Array<unsigned char>^ array = ref new Platform::Array<unsigned char>((unsigned char*)(message.data()), (unsigned int)message.size());
		writer->WriteBytes(array);

		using namespace concurrency;

		// Send the data as one complete message
		create_task(writer->StoreAsync()).then([this, writer](unsigned int)
		{
			// Send Completed
			writer->DetachStream();    // give the stream back to m_messageWebSocket
		}).then([this](task<void> previousTask)
		{
			try
			{
				// Try getting all exceptions from the continuation chain above this point.
				previousTask.get();
			}
			catch (Platform::COMException ^ex)
			{
				LivetimeGuard::guard lock(LivetimeGuard::mtx);
				if (!liveTimeGuard.isAlive()) return;

				PushResult({ Result::Type::Error, "Error while sending data: " + platform_to_std(ex->Message) });
			}
		});
	}
	else
	{
		PushResult({ Result::Type::Error, "Send() called on closed or currently connecting WebSocket." });
	}
}

bool NativeWebSocket::Update(float deltaTime)
{
	lastActivity += deltaTime;

	if (webSocketIsOpen == true && lastActivity > 60.0f)
	{
		lastActivity = 0.0f;
		GSExternalSend(0, " ");
	}

	return true;
}

#else /* _DURANGO */

void NativeWebSocket::GSExternalSendBinary(int, char message[], int offset, int length)
{ 
// UNUSED
}

void NativeWebSocket::GSExternalOpen(int socketId, string url, string gameObjectName, bool isBinary = false)
{
	this->isBinary = isBinary;
	this->socketId = socketId;
	webSocket.reset(easywsclient::WebSocket::from_url(url, gameObjectName));
}

void NativeWebSocket::GSExternalClose(int socketId)
{
	//webSocket.reset(nullptr);
	if (webSocket && webSocket->getReadyState() != easywsclient::WebSocket::CLOSED)
	{
		webSocket->close();
	}
}

void NativeWebSocket::GSExternalSend(int socketId, string message)
{
	webSocket->send(message);
}

using namespace easywsclient;

bool NativeWebSocket::Update(float deltaTime)
{
	lastActivity += deltaTime;

	if (webSocket)
	{
		{
			auto currentReadyState = webSocket->getReadyState();
			if (currentReadyState != lastReadyState)
			{
				switch (currentReadyState)
				{
				case easywsclient::WebSocket::OPEN:
					results.push(Result(Result::Type::Open, ""));
					break;
				case easywsclient::WebSocket::CLOSED:
					results.push(Result(Result::Type::Close, ""));
					break;
				default:break;
				}

				lastReadyState = currentReadyState;
			}
		}

		if (webSocket->getReadyState() != WebSocket::CLOSED)
		{
			webSocket->poll(0, OnError, this);
			//if (stopped) return false;
			webSocket->dispatch(OnMessage, OnError, this);
			//if (stopped) return false;

			if (lastActivity > 60){
				lastActivity = 0;
				webSocket->send(" ");
			}
		}
		else if (webSocket->getReadyState() == WebSocket::CLOSED)
		{
			//webSocket->DebugMsg("Websocket closed");
		}
	}
	return true;
}

void NativeWebSocket::OnMessage(const gsstl::string& message, void* self_)
{
	NativeWebSocket* self = (NativeWebSocket*)self_;
	self->results.push(Result(Result::Type::Message, message));
}

void NativeWebSocket::OnError(const easywsclient::WSError& error, void* self_)
{
	NativeWebSocket* self = (NativeWebSocket*)self_;
	self->results.push(Result(Result::Type::Error, error.message));
	self->stopped = true;
}

NativeWebSocket::NativeWebSocket()
{
}

NativeWebSocket::~NativeWebSocket()
{
}

#endif /* _DURANGO */


NativeWebSocket::Result* NativeWebSocket::GetNextResult()
{
	#if defined(_WIN32)
	{
		LivetimeGuard::guard lock(LivetimeGuard::mtx);
		if (!liveTimeGuard.isAlive()) nullptr;
	}
	#endif

	std::lock_guard<std::mutex> lock(results_mutex);
	if (results.empty())
	{
		return nullptr;
	}
	else
	{
		Result* ret = new Result(results.front());
		results.pop();
		return ret;
	}
}


void NativeWebSocket::PushResult(const Result& result)
{
#ifdef _WIN32
	{
		LivetimeGuard::guard lock(LivetimeGuard::mtx);
		if (!liveTimeGuard.isAlive()) return;
	}

	std::stringstream ss;
	ss << "PushResult, type=" << (int)result.type << ", message=" << result.message << std::endl;
	OutputDebugStringA(ss.str().c_str());
#endif

	std::lock_guard<std::mutex> lock(results_mutex);
	results.push(result);
}

static const std::string base64_chars =
"ABCDEFGHIJKLMNOPQRSTUVWXYZ"
"abcdefghijklmnopqrstuvwxyz"
"0123456789+/";

std::string NativeWebSocket::base64_encode(unsigned char const* bytes_to_encode, unsigned int in_len) {
	std::string ret;
	int i = 0;
	int j = 0;
	unsigned char char_array_3[3];
	unsigned char char_array_4[4];

	while (in_len--) {
		char_array_3[i++] = *(bytes_to_encode++);
		if (i == 3) {
			char_array_4[0] = (char_array_3[0] & 0xfc) >> 2;
			char_array_4[1] = ((char_array_3[0] & 0x03) << 4) + ((char_array_3[1] & 0xf0) >> 4);
			char_array_4[2] = ((char_array_3[1] & 0x0f) << 2) + ((char_array_3[2] & 0xc0) >> 6);
			char_array_4[3] = char_array_3[2] & 0x3f;

			for (i = 0; (i <4); i++)
				ret += base64_chars[char_array_4[i]];
			i = 0;
		}
	}

	if (i)
	{
		for (j = i; j < 3; j++)
			char_array_3[j] = '\0';

		char_array_4[0] = (char_array_3[0] & 0xfc) >> 2;
		char_array_4[1] = ((char_array_3[0] & 0x03) << 4) + ((char_array_3[1] & 0xf0) >> 4);
		char_array_4[2] = ((char_array_3[1] & 0x0f) << 2) + ((char_array_3[2] & 0xc0) >> 6);
		char_array_4[3] = char_array_3[2] & 0x3f;

		for (j = 0; (j < i + 1); j++)
			ret += base64_chars[char_array_4[j]];

		while ((i++ < 3))
			ret += '=';

	}

	return ret;

}

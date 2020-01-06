#ifdef ORBIS
#	define SWIGEXPORT __declspec(dllexport)
#endif


#if defined(_WIN32)
//#	using <mscorlib.dll>
	using namespace Windows::Networking::Sockets;
	using namespace Windows::Storage::Streams;
#	include <atomic>
#	include <set>
#	include <mutex>

	/*
	this helper keeps track of NativeWebSocket instances that are still alive, so that
	we can bale out if a MessageWebSocket callback is called after the destruction
	of NativeWebSocket.

	Unregistering the callbacks would be a cleaner solution, but it turned out to be
	unreliable in a multi threaded context.
	*/
	struct LivetimeGuard
	{
		LivetimeGuard() { guard lock(mtx); aliveObjects.insert(this); }
		~LivetimeGuard() { guard lock(mtx); aliveObjects.erase(this); }
		bool isAlive() const { guard lock(mtx); return aliveObjects.count(this) > 0; }

		typedef std::lock_guard<std::recursive_mutex> guard;
		static std::recursive_mutex mtx;
		static std::set<const LivetimeGuard*> aliveObjects;
	};

#else
	#include <easywsclient/easywsclient.hpp>
#endif

#include <string>
#include <memory>
#include <queue>
#include <mutex>
using std::string;

class NativeWebSocket
{
	public:
		class Result
		{
			public:
				enum class Type
				{
					Close,
					Open,
					Error,
					Message,
					BinaryMessage
				};

				Type getType() { return type; }
				string getMessage() { return message; }
			private:
				friend class NativeWebSocket;
				Result(Type type, string message)
					:type(type), message(message) {}

				Type type;
				string message;
		};

		NativeWebSocket();
		virtual  ~NativeWebSocket();

		void GSExternalOpen(int socketId, string url, string gameObjectName, bool binary);
		void GSExternalClose(int socketId);
		void GSExternalSend(int socketId, string message);
		void GSExternalSendBinary(int socketId, char message[], int offset, int length);
		
		bool Update(float dt);
		Result* GetNextResult();
	private:
		#if defined(_WIN32)
			MessageWebSocket^  webSocket;

			//Windows::Foundation::EventRegistrationToken onMessageReceivedToken;
			//Windows::Foundation::EventRegistrationToken onClosedToken;
			std::atomic<bool> webSocketIsOpen;
		#else
			static void OnMessage(const gsstl::string &, void*);
			static void OnError(const easywsclient::WSError&, void*);

			std::unique_ptr<easywsclient::WebSocket> webSocket;
			easywsclient::WebSocket::readyStateValues lastReadyState = easywsclient::WebSocket::CLOSED;
			int socketId = -1;
			bool stopped = false;
		#endif

		bool isBinary = false;
		float lastActivity = 0.0f;
		typedef std::queue<Result> Results;
		std::mutex results_mutex;
		Results results;
		std::string base64_encode(unsigned char const* bytes_to_encode, unsigned int in_len);
		void PushResult(const Result& result);

		#if defined(_WIN32)
			// it's safest to make this the very last member, so that
			// it gets created last and destroyed first.
			LivetimeGuard liveTimeGuard;
		#endif
};

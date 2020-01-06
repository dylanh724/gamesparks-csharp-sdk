using System;
using System.Collections;
using System.IO;
using Org.BouncyCastle.Crypto.Tls;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Security;
using System.Runtime.Remoting.Messaging;

namespace GameSparks.RT
{
#if REALTIME
    public static class GSTlsVerifyCertificateRT
#else
    public static class GSTlsVerifyCertificate
#endif
    {
        public static Func<Certificate, String> OnVerifyCertificate { get; set; }
    }

    // Need class with TlsClient in inheritance chain
    internal class GSTlsClient : DefaultTlsClient
	{

		internal static Stream WrapStream(Stream stream, String hostName)
		{
			if (GSTlsClient.logger != null)
			{
				GSTlsClient.logger("Wrapping");
			}

			TlsClientProtocol tslcp = new TlsClientProtocol(stream, new SecureRandom());
			tslcp.Connect(new GSTlsClient(hostName));
			return new DuplexTlsStream(tslcp.Stream);
		}

		private String hostName;

		private GSTlsClient(String hostName)
		{
			this.hostName = hostName;

		}

		public static Action<String> logger;

		public override TlsAuthentication GetAuthentication()
		{
			return new GSTlsAuthentication(hostName);
		}

		public override int[] GetCipherSuites()
		{
			return new int[]
				{
					CipherSuite.TLS_ECDHE_RSA_WITH_3DES_EDE_CBC_SHA,
					CipherSuite.TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256,
					CipherSuite.TLS_RSA_WITH_AES_128_CBC_SHA256,
					CipherSuite.TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA,
					CipherSuite.TLS_RSA_WITH_AES_128_CBC_SHA,
					CipherSuite.TLS_ECDHE_ECDSA_WITH_3DES_EDE_CBC_SHA,
					CipherSuite.TLS_ECDHE_RSA_WITH_3DES_EDE_CBC_SHA,
					CipherSuite.TLS_ECDH_ECDSA_WITH_3DES_EDE_CBC_SHA,
					CipherSuite.TLS_ECDH_RSA_WITH_3DES_EDE_CBC_SHA
				};
		}

		public override byte[] GetCompressionMethods()
		{
			return new byte[] { CompressionMethod.cls_null };
		}

		public override System.Collections.IDictionary GetClientExtensions()
		{
			IList serverNames = new ArrayList();
			serverNames.Add(new ServerName(NameType.host_name, hostName));
			ServerNameList serverNameList = new ServerNameList(serverNames);
			IDictionary extensions = base.GetClientExtensions();
			TlsExtensionsUtilities.AddServerNameExtension(extensions, serverNameList);
			return extensions;

		}

	}

	// Need class to handle certificate auth
	internal class GSTlsAuthentication : TlsAuthentication
	{
		
		private static X509Certificate rootCert = new X509CertificateParser().ReadCertificate(Convert.FromBase64String("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"));

		IList validCertNames = new ArrayList();

		internal GSTlsAuthentication(String hostName)
		{
			
			validCertNames.Add(hostName);
			if (hostName.IndexOf(".") != -1)
			{
				validCertNames.Add("*" + hostName.Substring(hostName.IndexOf(".")));
			}
			
		}

		public TlsCredentials GetClientCredentials(CertificateRequest certificateRequest)
		{
			return null;
		}

		public void NotifyServerCertificate(Certificate serverCertificate)
		{
#if REALTIME
            if (GSTlsVerifyCertificateRT.OnVerifyCertificate != null)
            {
                String result = GSTlsVerifyCertificateRT.OnVerifyCertificate(serverCertificate);
#else
            if (GSTlsVerifyCertificate.OnVerifyCertificate != null) {
				String result = GSTlsVerifyCertificate.OnVerifyCertificate(serverCertificate);
#endif
                if (result != null) {
					throw new TlsFatalAlert(AlertDescription.bad_certificate, new Exception(result));
				}
			}

			/*if (true)
			{
				return;
			}

			X509Certificate thisCert = new X509Certificate(serverCertificate.GetCertificateAt(0));

			bool validLeaf = false;

			foreach (String validCertName in validCertNames)
			{
				if (thisCert.SubjectDN.GetValueList().Contains(validCertName))
				{
					validLeaf = true;
				}
			}

			if (!validLeaf)
			{
				//The SubjectDN does not match, lets check the alternate names
				if (thisCert.GetSubjectAlternativeNames() != null)
				{
					IEnumerator altNames = thisCert.GetSubjectAlternativeNames().GetEnumerator();
					while (altNames.MoveNext())
					{
						object item = altNames.Current;

						if (item is ArrayList)
						{
							foreach (object altName in item as ArrayList)
							{
								if (validCertNames.Contains(altName))
								{
									validLeaf = true;
									goto endloop;
								}

							}
						}

					}
				}
			}

			endloop:

			if (!validLeaf)
			{
				throw new TlsFatalAlert(AlertDescription.bad_certificate, new Exception("Invalid leaf cert"));
			}

			for (int i = 1; i < serverCertificate.Length - 1; i++)
			{
			
				X509Certificate issuer = new X509Certificate(serverCertificate.GetCertificateAt(i));

				try
				{
					thisCert.Verify(issuer.GetPublicKey());
				}
				catch (Exception e)
				{
					while (e != null)
					{
						GSTlsClient.logger(e.Message);
						GSTlsClient.logger(e.StackTrace);
						e = e.InnerException;
					}

				}

				if (issuer.Equals(rootCert))
				{
					return;
				}
			}

			throw new TlsFatalAlert(AlertDescription.bad_certificate, new Exception("Invalid cert chain"));*/

		}

	}

	internal class DuplexTlsStream : Stream
	{

		private Stream wrapped;

		internal DuplexTlsStream(Stream wrapped)
		{
			this.wrapped = wrapped;
		}

		public override bool CanRead
		{
			get
			{
				return wrapped.CanRead;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return wrapped.CanSeek;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return wrapped.CanWrite;
			}
		}

		public override long Length
		{
			get
			{
				return wrapped.Length;
			}
		}

		public override long Position
		{
			get
			{
				return wrapped.Position;
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public override void Flush()
		{
			wrapped.Flush();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return wrapped.Read(buffer, offset, count);
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return wrapped.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			wrapped.SetLength(value);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			wrapped.Write(buffer, offset, count);
		}

		delegate int ReadDelegate(byte[] buffer, int offset, int count);

		public override IAsyncResult BeginRead(byte[] buffer, int offset,
			   int count, AsyncCallback callback, object state)
		{
			ReadDelegate read = this.Read;
			return read.BeginInvoke(buffer, offset, count, callback, state);
		}

		public override int EndRead(IAsyncResult asyncResult)
		{
			AsyncResult result = (AsyncResult)asyncResult;
			ReadDelegate caller = (ReadDelegate)result.AsyncDelegate;
			return caller.EndInvoke(asyncResult);
		}

		delegate void WriteDelegate(byte[] buffer, int offset, int count);

		public override IAsyncResult BeginWrite(byte[] buffer, int offset,
						int count, AsyncCallback callback, object state)
		{
			WriteDelegate write = this.Write;
			return write.BeginInvoke(buffer, offset, count, callback, state);
		}

		public override void EndWrite(IAsyncResult asyncResult)
		{
			AsyncResult result = (AsyncResult)asyncResult;
			WriteDelegate caller = (WriteDelegate)result.AsyncDelegate;
			caller.EndInvoke(asyncResult);
		}
	}

}


using System;
using System.IO;
using GameSparks.RT.Commands;

namespace Com.Gamesparks.Realtime.Proto
{
	internal partial class LoginCommand : RTRequest
	{
		private const int _clientVersion = 2;

		internal LoginCommand(String token){
			OpCode = 0;
			Token = token;
			ClientVersion = _clientVersion;
		}

		internal LoginCommand(){}

		internal override void Serialize (Stream stream){
			LoginCommand.Serialize(stream, this);
		}
	}
}


using System;
using Com.Gamesparks.Realtime.Proto;
using GameSparks.RT.Commands;
using System.IO;

namespace Com.Gamesparks.Realtime.Proto
{
	internal partial class PingCommand : RTRequest
	{
		internal PingCommand(){
			OpCode = -2;
		}
		internal override void Serialize (Stream stream){
			PingCommand.Serialize(stream, this);
		}
	}

}


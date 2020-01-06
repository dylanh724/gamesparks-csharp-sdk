using System;
using Com.Gamesparks.Realtime.Proto;
using System.IO;
using GameSparks.RT.Pools;
using GameSparks.RT;
using GameSparks.RT.Proto;
using System.Collections.Generic;

namespace GameSparks.RT.Commands
{
	internal abstract class RTRequest
	{
		public RTRequest(){
			TargetPlayers = new List<int> ();
		}

		protected RTData Data{ get; set; }
		protected int OpCode{ get; set; }
		protected List<int> TargetPlayers{ get; set; }
		protected GameSparksRT.DeliveryIntent intent{ get; set; }

		internal abstract void Serialize (Stream stream);

		internal virtual Packet ToPacket(IRTSessionInternal session, bool fast){
			Packet p = PooledObjects.PacketPool.Pop();
			p.OpCode = OpCode;
			p.Data = Data;
			p.Session = session;

			if (!fast && intent != GameSparksRT.DeliveryIntent.RELIABLE) {
				p.Reliable = false;
			}

			if (intent == GameSparksRT.DeliveryIntent.UNRELIABLE_SEQUENCED) {
				p.SequenceNumber = session.NextSequenceNumber ();
			}

			if (TargetPlayers != null && TargetPlayers.Count > 0) {
				p.TargetPlayers = TargetPlayers;
			}

			p.Request = this;
			return p;
		}

		internal void Reset()
		{
			TargetPlayers.Clear ();
		}
	}
}


using System;
using GameSparks.RT.Commands;
using System.IO;

namespace GameSparks.RT
{
	internal class CustomRequest : RTRequest
	{
		ArraySegment<byte>? payload;

		public void Configure(int opCode, GameSparksRT.DeliveryIntent intent, ArraySegment<byte>? payload, RTData data,  params int[] targetPlayers){
			OpCode = opCode;
			this.payload = payload;
			this.intent = intent;
			Data = data;
			if (targetPlayers != null) {
				this.TargetPlayers.AddRange (targetPlayers);
			}
		}

		internal override void Serialize (Stream stream){
			if (payload.HasValue) {
				ArraySegment<byte> payloadValue = payload.Value;
				stream.Write (payloadValue.Array, payloadValue.Offset, payloadValue.Count);
			}
		}

		new internal void Reset()
		{
			payload = null;
			base.Reset ();
		}
	}
}


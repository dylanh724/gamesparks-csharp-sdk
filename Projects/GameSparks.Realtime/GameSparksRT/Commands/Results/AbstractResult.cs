using System;
using GameSparks.RT.Proto;

namespace GameSparks.RT
{
	internal abstract class AbstractResult : IRTCommand
	{
		internal Packet packet;
		internal IRTSessionInternal session;

		internal void Configure(Packet packet, IRTSessionInternal session)
		{
			this.packet = packet;
			this.session = session;
		}

		public abstract void Execute ();

		internal virtual bool ExecuteAsync()
		{
			return true;
		}

	}
}


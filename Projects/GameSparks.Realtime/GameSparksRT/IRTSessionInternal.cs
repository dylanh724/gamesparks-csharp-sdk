using System;
using System.Collections.Generic;
using System.IO;

namespace GameSparks.RT
{
	internal interface IRTSessionInternal : IRTSession, IRTSessionListener {
		void Log (String tag, GameSparks.RT.GameSparksRT.LogLevel level, String msg, params object[] formatParams);
		string ConnectToken { get; set; }
		int FastPort { get; set; }
		new bool Ready { get; set; }
		new GameSparksRT.ConnectState ConnectState { get; set;}
		new int? PeerId { get; set;}
		new List<int> ActivePeers { get; set;}
		void ConnectReliable ();
#if !__WINDOWS__
		void ConnectWSReliable ();
#endif
		void ConnectFast ();
		bool ShouldExecute (int peerId, int? sequence);
		void SubmitAction (IRTCommand action);
		int NextSequenceNumber ();

	}

}


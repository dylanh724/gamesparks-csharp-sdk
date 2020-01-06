using System;

namespace GameSparks.RT
{
	/// <summary>
	/// IRTCommand. THe interface that objects returned from OnCustom need to implement.
	/// Code within OnCustom runs in a background Thread, so for Engines like unity UI updates 
	/// cannot be performed in this method. 
	/// These returned objects are executed on calls to IRTSession.Update(), and are executed on the thread that calls this method.
	/// This pattern allows you to run code in both the background, and foreground threads when a custom message is received
	/// </summary>
	internal interface IRTCommand
	{
		/// <summary>
		/// Execute this instance. Executed on calls to IRTSession.Update()
		/// </summary>
		void Execute ();
	}
}


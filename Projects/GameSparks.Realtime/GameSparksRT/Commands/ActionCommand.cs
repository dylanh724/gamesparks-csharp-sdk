using System;
using GameSparks.RT.Pools;

namespace GameSparks.RT
{
	internal class ActionCommand : IRTCommand
	{

		internal static ObjectPool<ActionCommand> pool = new ObjectPool<ActionCommand>(() => {return new ActionCommand();});

		Action action;

		internal ActionCommand Configure (Action action)
		{
			this.action = action;
			return this;
		}

		public void Execute()
		{
			action ();
			pool.Push (this);
		}
	}
}


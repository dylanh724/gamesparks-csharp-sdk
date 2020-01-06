using System;
using System.Collections.Generic;

namespace GameSparks.RT.Pools
{
	internal class ObjectPool<T>
	{
		Stack<T> stack = new Stack<T>();
		Func<T> creator;
		Action<T> refresher;

		//Defaults to 5
		int maxSize = 5;

		public ObjectPool(Func<T> creator, int maxSize){
			this.creator = creator;
			this.maxSize = maxSize;
		}

		public ObjectPool(Func<T> creator, Action<T> refresher, int maxSize){
			this.creator = creator;
			this.refresher = refresher;
			this.maxSize = maxSize;
		}

		public ObjectPool(Func<T> creator){
			this.creator = creator;
		}

		public ObjectPool(Func<T> creator, Action<T> refresher){
			this.creator = creator;
			this.refresher = refresher;
		}

		/// <summary>
		/// The returned stream is not reset.
		/// You must call .SetLength(0) before using it.
		/// This is done in the generated code.
		/// </summary>
		public T Pop()
		{
			lock (stack)
			{
				if (stack.Count == 0) {
					return creator ();
				} else {
					return stack.Pop ();
				}
			}
		}

		public void Push(T item)
		{
			if (item != null) {
				lock (stack) {
					if (stack.Contains (item)) {
						return;
					}
					if (stack.Count < maxSize) {
						if (refresher != null) {
							refresher (item);
						}
						stack.Push (item);
					}
				}
			}
		}

		public void Dispose()
		{
			lock (stack)
			{
				stack.Clear();
			}
		}
	}
}


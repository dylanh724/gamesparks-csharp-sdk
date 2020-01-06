using System;
using System.Threading;
using System.Timers;

namespace GameSparks.Core
{
    /// <summary>
    /// Threadsafe timer implementation with callback. 
    /// </summary>
	public class GameSparksTimer : IGameSparksTimer
	{
        private System.Timers.Timer m_timer;
		private Action m_callback;

        /// <summary>
        /// Initialize the timer with a given interval (milliseconds) and callback. 
        /// </summary>
        public void Initialize(int interval, Action callback)
		{
			m_callback = callback;
			m_timer = new System.Timers.Timer(interval);
			m_timer.Elapsed += TimerCallback;
			m_timer.AutoReset = true;
			m_timer.Start();
		}

		private void TimerCallback(object state, ElapsedEventArgs e)
		{
            if (Monitor.TryEnter(m_timer))
            {
                try
                {
                    m_callback();
				} catch{
					
				}
                finally
                {
                    Monitor.Exit(m_timer);
                }
            }

		}

        /// <summary>
        /// Trigger the timer right now. 
        /// </summary>
		public void Trigger()
        {
		}

        /// <summary>
        /// Stop the timer
        /// </summary>
		public void Stop()
		{
			lock (m_timer) {
				m_timer.Stop();
			}
		}

	}
}


using System;
using System.Text;

namespace GameSparks
{
    /// <summary>
    /// Interface for timer with a callback. 
    /// It should start automatically when initialized. 
    /// </summary>
    public interface IGameSparksTimer
    {
        /// <summary>
        /// Initialize this timer. Once initialized timers automatically start. 
        /// </summary>
        /// <param name="interval">in milliseconds</param>
        /// <param name="callback">the function which is called, when the interval is over. </param>
        void Initialize(int interval, Action callback);
        
        /// <summary>
        /// Instantly trigger the registered callback. 
        /// </summary>
        void Trigger();
        
        /// <summary>
        /// Stop this timer. 
        /// </summary>
        void Stop();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    public delegate void TimerDelagate();

    public class Timer
    {
        private uint times;
        private uint interval;

        public Timer(uint times, uint interval, TimerDelagate timerDelagate)
        {
            this.times = times;
            this.interval = interval;
        }

        public void Play(Action action)
        {
            uint times = this.times;
            uint interval = this.interval;

            for (int i = 0; i < times; i++)
            {
                DateTime now = DateTime.Now;
                DateTime then = now.AddSeconds(interval);

                while (now < then)
                {
                    now = DateTime.Now;
                }

                action();
            }
        }             

    
    }
}

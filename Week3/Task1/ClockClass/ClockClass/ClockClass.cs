using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public class Clock
    {
        private Counter _secondsCounter;
        private Counter _minutesCounter;
        private Counter _hoursCounter;
        public Clock()
        {
            _secondsCounter = new Counter("Seconds");
            _minutesCounter = new Counter("Minutes");
            _hoursCounter = new Counter("Hours");
        }

        public void GetTime()
        {
            _secondsCounter.Increment();
            if (_secondsCounter.Ticks >= 60)
            {
                _secondsCounter.Reset();
                _minutesCounter.Increment();

                if (_minutesCounter.Ticks >= 60)
                {
                    _minutesCounter.Reset();
                    _hoursCounter.Increment();

                    if (_hoursCounter.Ticks >= 24)
                    {
                        _hoursCounter.Reset();
                    }
                }
            }
        }


        public void RunClock()
        {
            while (true)
            {
                GetTime();
                PrintTIme();
                Thread.Sleep(1000);
            }
        }

        public string PrintTIme()
        {
            string time = $"{_hoursCounter.Ticks:D2}:{_minutesCounter.Ticks:D2}:{_secondsCounter.Ticks:D2}";
            Console.WriteLine(time);
            return time;
        }
    }
}

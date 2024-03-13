using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterTask
{
    public class Counter
    {
        private int _counter;
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public int Ticks
        {
            get
            {
                return _counter;
            }
        }

        public Counter(string name)
        {
            _name = name;
            _counter = 0;
        }

        public void Increment()
        {
            _counter++;
        }
        public void Reset()
        {
            _counter = 0;
        }
    }
}

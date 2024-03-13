using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Clock clock = new Clock();
            clock.RunClock();
        }
    }
}
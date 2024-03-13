using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockClass
{
    public class MainClass
    {
         private static void PrintCounters(Counter[] counters)
         {
             foreach (Counter c in counters)
             {
                 Console.WriteLine("{0} is {1}", c.Name, c.Ticks);
             }

         }
        public static void Main(string[] args)
        {
             Counter[] myCounters = new Counter[3];

             myCounters[0] = new Counter("Counter 1");
             myCounters[1] = new Counter("Counter 2");
             myCounters[2] = myCounters[0];

             PrintCounters(myCounters);
             myCounters[2].Reset();
             PrintCounters(myCounters);
             Console.ReadLine();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class TPL_Example
    {

        public static void Run()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            string alpha = "";
            Parallel.For(0, 100, x => concateString(alpha));
            watch.Stop();
            Console.WriteLine("task ticks " + watch.ElapsedTicks);


            watch.Reset();
            watch.Start();
            Thread t1 = new Thread(Run100Time);
            t1.Start();
            watch.Stop();
            Console.WriteLine("thread ticks "+watch.ElapsedTicks);
            
        }

        public static void concateString(string alpha)
        {
            alpha = alpha + alpha;
        }

        public static void Run100Time()
        {
           
            string alpha = "";
            for(int i=0;i<100;i++)
            {
                alpha = alpha + i.ToString();
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {

        public static void Main(string[] args)
        {
            //Console.WriteLine("ss");
            //TaskUsesThreadPool();
            //ThreadExample();
            //ThreadPoolExample();
            //ThreadJoinExample();
            //TaskExample();
            //TPL_Example.Run();
            Thread th = new Thread(new ThreadStart(Fun));
            Thread.Sleep(2000);
            th.Start();
            //Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

        public static void Fun()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("... "+i);
                Thread.Sleep(1000);
            }
        }

        public static void ThreadExample()
        {
            Console.WriteLine("inside method");
            for(int i=0;i<10;i++)
            {
                new Thread(() =>
                {
                    Console.WriteLine($"thread started {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(2000);
                    Console.WriteLine($"thread {Thread.CurrentThread.ManagedThreadId} ended-----");

                }).Start();
            }


        }
        public static void ThreadPoolExample()
        {
            Console.WriteLine("inside method");
            Thread.Sleep(2000);
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem((o) =>
                {
                    Console.WriteLine($"thread started {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(2000);
                    Console.WriteLine($"thread {Thread.CurrentThread.ManagedThreadId} ended-----");

                });
            }
        }
        public static void ThreadJoinExample()
        {
            Console.WriteLine("inside Thread Example");
            var thread1 = new Thread(()=> {
                Console.WriteLine($"inside thread 1 {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(2000);
                Console.WriteLine($"inside thread 1 {Thread.CurrentThread.ManagedThreadId} ended");

            });
            var thread2 = new Thread(() => {
                Console.WriteLine($"inside thread 2 {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(5000);
                Console.WriteLine($"inside thread 2 {Thread.CurrentThread.ManagedThreadId} ended");

            });
            
            var thread4 = new Thread(() => {
                Console.WriteLine($"inside thread 3 {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(5000);
                Console.WriteLine($"inside thread 3 {Thread.CurrentThread.ManagedThreadId} ended");
            });
            thread1.Start();
            thread4.Start();
            thread2.Start();
            thread1.Join();
            Console.WriteLine("end of Thread Example");

        }
        public static void TaskUsesThreadPool()
        {
            int maxThreads;
            int minThreads;
            int avaThreads;
            int comp1;
            int comp2;
            int comp3;

            ThreadPool.GetMaxThreads(out maxThreads, out comp1);
            ThreadPool.GetMinThreads(out minThreads, out comp2);
            ThreadPool.GetAvailableThreads(out avaThreads, out comp3);
            Console.WriteLine($"max threads {maxThreads} min threds {minThreads} available threads {avaThreads}");



            //Task.Run(async () =>
            //{
            //    await Task.Delay(2000);
            //    Console.WriteLine("inside task");
            //});
            //ThreadPool.GetAvailableThreads(out avaThreads, out comp3);
            //Console.WriteLine($"max threads {maxThreads} min threds {minThreads} available threads {avaThreads}");

        }
        public static void TaskExample()
        {
            Console.WriteLine("calling hello task");
            var helloTask=Hello(3,5);
            Console.WriteLine("after calling hello task");

            Task.WaitAll();
            Console.WriteLine("end execution");

        }
        public static async Task<int> Hello(int a,int b)
        {
            Console.WriteLine("inside hello Task");
            int result = a + b;
            await Task.Delay(2000);
            Console.WriteLine("ended hello task");
            return result;
        }



    }
}

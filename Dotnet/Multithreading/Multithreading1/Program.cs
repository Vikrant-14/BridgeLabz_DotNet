using System;
using System.Threading;

namespace MultiThreading_example
{
    public class ThreadingDemo
    {
        public static void threadLoop()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
        }

        public static void ThreadName()
        {
            Thread t = Thread.CurrentThread;
            Console.WriteLine(t.Name + " is running");
        }

        static void Main()
        {
            Thread t1 = new Thread(ThreadName);
            Thread t2 = new Thread(ThreadName);
            Thread t3 = new Thread(ThreadName);

            t1.Name = "Player1";
            t2.Name = "Player2";
            t3.Name = "Player3";

            t3.Priority = ThreadPriority.Highest;
            t2.Priority = ThreadPriority.Normal;
            t1.Priority = ThreadPriority.Lowest;

            t1.Start();
            t2.Start();
            t3.Start();
        }

        static void Main2()
        {
            Console.WriteLine("Start of main");

            Thread t1 = new Thread(new ThreadStart(ThreadingDemo.threadLoop));
            Thread t2 = new Thread(new ThreadStart(ThreadingDemo.threadLoop));

            t1.Start();
            t2.Start();

            
            Console.WriteLine("End of Main");
        }
        static void Main1()
        {
            Thread t1 = new Thread(new ThreadStart(ThreadingDemo.threadLoop));
            Thread t2 = new Thread(new ThreadStart(ThreadingDemo.threadLoop));

            t1.Start();
            t2.Start();
        }
    }
}

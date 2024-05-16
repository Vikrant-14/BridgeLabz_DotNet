using System;
using System.Threading;

namespace Synchronization_example
{
    public class MonitorDemo
    {
        public static readonly Object locker = new Object();

        public static void PrintTable()
        {
            Monitor.Enter(locker);

            try
            {
                for (int i = 0; i <= 10; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(500); 
                }
            }
            finally 
            { 
                Monitor.Exit(locker); 
            }
        }
        public static void Main()
        {
            Thread t1 = new Thread(PrintTable);
            Thread t2 = new Thread(PrintTable);

            t1.Start();
            t2.Start();

        }
    }
}

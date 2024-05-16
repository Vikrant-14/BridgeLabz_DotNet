using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskBasedAsynchronousProgramming
{
    class Program
    {
        public static void PrintCounter()
        {
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");

            for (int count = 1; count <= 5; count++)
            {
                Console.WriteLine($"count value: {count}");
            }

            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Started");

            Task t1 = Task.Factory.StartNew(PrintCounter);

            Task t2 = Task.Run(() => { PrintCounter();  });
            t1.Wait(); //stops the execution of other threads util task t1 completes its execution
            
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
        }
    }
}
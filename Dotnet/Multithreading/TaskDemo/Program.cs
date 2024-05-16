using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asynchronous_example
{
    public class TaskDemo
    {
        static void PrintCounter()
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

            Action actionDelegate = new Action(PrintCounter);
            Task task1 = new Task(actionDelegate);
            
            //You can directly pass the PrintCounter method as its signature is same as Action delegate
            //Task task1 = new Task(PrintCounter);
            
            task1.Start();
            
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
            Console.ReadKey();
        }


        public void PrintTable()
        {
            Console.WriteLine("Current Thread : " + Thread.CurrentThread.ManagedThreadId  + " started");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Current Thread : " + Thread.CurrentThread.ManagedThreadId + " ended");
        }

        public async Task PrintTableAsync()
        {
            Console.WriteLine("Current Thread : " + Thread.CurrentThread.ManagedThreadId + " started");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Current Thread : " + Thread.CurrentThread.ManagedThreadId + " ended");
        }

        static async Task Main1()
        {
            TaskDemo taskDemo = new TaskDemo();
            Console.WriteLine("Main Thread started");

            Task t1 = Task.Run(() => taskDemo.PrintTable());
            
            Task t2 = Task.Factory.StartNew(() => taskDemo.PrintTable());
            Task t3 = taskDemo.PrintTableAsync();

            t3.Wait();

           await Task.WhenAll(t1, t2, t3);

            Console.WriteLine("Main Thread ended");
        }
    }
}

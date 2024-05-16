using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_example
{
    public class TaskDemo
    {
        public static void PrintCounter()
        {
            Console.WriteLine("Child Thread : " + Thread.CurrentThread.ManagedThreadId + " started");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Child Thread : " + Thread.CurrentThread.ManagedThreadId + " ended");
        }
        static void Main()
        {
            Console.WriteLine("Main Thread : " + Thread.CurrentThread.ManagedThreadId + " started");

            //Creating Task using Method
            Task t1 = new Task(PrintCounter);
            t1.Start();
            // t1.Wait();

            //Creating Task using Anonymous Method
            Task t2 = new Task(delegate ()
            {
                Console.WriteLine("Child Thread : " + Thread.CurrentThread.ManagedThreadId + " started");

                Task.Delay(200);

                Console.WriteLine("Child Thread : " + Thread.CurrentThread.ManagedThreadId + " ended");
            });
            t2.Start();
             t2.Wait();

            //Creating Task using Lamdba Expression
            Task t3 = new Task(() => {
                Console.WriteLine("Child Thread : " + Thread.CurrentThread.ManagedThreadId + " started");

                Task.Delay(200);

                Console.WriteLine("Child Thread : " + Thread.CurrentThread.ManagedThreadId + " ended");
            });
            t3.Start();

            Console.WriteLine("=======================================================================");

            //Creating Task using Method
            Task t4 = Task.Factory.StartNew(PrintCounter);

            //Creating Task using Anonymous Method
            Task t5 = Task.Factory.StartNew(delegate ()
            {
                Console.WriteLine("Child Thread : " + Thread.CurrentThread.ManagedThreadId + " started");

                Task.Delay(200);

                Console.WriteLine("Child Thread : " + Thread.CurrentThread.ManagedThreadId + " ended");
            });

            //Creating Task using Lamdba Expression
            Task t6 = Task.Factory.StartNew(() => {
                Console.WriteLine("Child Thread : " + Thread.CurrentThread.ManagedThreadId + " started");

                Task.Delay(200);

                Console.WriteLine("Child Thread : " + Thread.CurrentThread.ManagedThreadId + " ended");
            });

            Console.WriteLine("=======================================================================");

            //Creating Task using Method
            Task t7 = Task.Run(PrintCounter);

            //Creating Task using Anonymous Method
            Task t8 = Task.Run(delegate ()
            {
                Console.WriteLine("Child Thread : " + Thread.CurrentThread.ManagedThreadId + " started");

                Task.Delay(200);

                Console.WriteLine("Child Thread : " + Thread.CurrentThread.ManagedThreadId + " ended");
            });

            //Creating Task using Lamdba Expression
            Task t9 = Task.Run(() => {
                Console.WriteLine("Child Thread : " + Thread.CurrentThread.ManagedThreadId + " started");

                Task.Delay(200);

                Console.WriteLine("Child Thread : " + Thread.CurrentThread.ManagedThreadId + " ended");
            });
            t9.Wait();

            Console.WriteLine("Main Thread : " + Thread.CurrentThread.ManagedThreadId + " ended");
        }
    }
}
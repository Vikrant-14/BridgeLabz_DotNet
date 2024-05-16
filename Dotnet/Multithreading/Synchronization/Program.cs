using System;
using System.Threading;

namespace MultiThreading_synchronization_example
{
    public class SynchronizationDemo
    {
        public void PrintTable()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
        }


        // using lock keyword -> so that at a time only one thread can access the resource
        public void DisplayTable()
        {
            lock(this)
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(1000);
                }
            }
        }

        //Synchronous Behaviour
        public static void Main()
        {
            Console.WriteLine("Main() begins");

            SynchronizationDemo s1 = new();

            Thread t1 = new(new ThreadStart(s1.DisplayTable));
            Thread t2 = new(new ThreadStart(s1.DisplayTable));

            t1.Start();
            t2.Start();

            Console.WriteLine("Main ends");

        }

        //Asynchronous Behaviour
        public static void Main1()
        {
            Console.WriteLine("Main() begins");

            SynchronizationDemo s1 =  new();

            Thread t1 = new(new ThreadStart(s1.PrintTable));
            Thread t2 = new(new ThreadStart(s1.PrintTable));

            t1.Start();
            t2.Start();

            Console.WriteLine("Main ends");

        }
    }
}
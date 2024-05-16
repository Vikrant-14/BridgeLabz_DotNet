using System;
using System.Threading;

namespace MultiThreading_Examples
{
    public class ThreadDemo
    {
        public void Show()
        {
            Console.WriteLine("Show()");
        }

        public void Display()
        {
            Console.WriteLine("Display()");
        }

        public void Print()
        {
            Console.WriteLine("Print()");
        }

        public static void Main() 
        {
            Console.WriteLine("Main() begins");

            ThreadDemo td1 = new ThreadDemo();

            Thread t1 = new Thread(td1.Show);
            t1.Name = "thread1";

            Thread t2 = new Thread(td1.Display);
            t2.Name = "thread2";

            Thread t3 = new Thread(new ThreadStart(td1.Print));
            t3.Name = "thread3";

            

            t3.Priority = ThreadPriority.Highest;

            t1.Start();
            t2.Start();
            t3.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main()");
                Thread.Sleep(1000);
            }

            
            t3.Join(); // Main thread waits for thread3 to complete its execution

            Console.WriteLine("Main() ends");
        }


        //Normal thread creation
        public static void Main1()
        {
            Console.WriteLine("Main() begins");

            ThreadDemo td1 = new ThreadDemo();

            Thread t1 = new Thread(td1.Show);
            Thread t2 = new Thread(td1.Display);
            Thread t3 = new Thread(td1.Print);

            t1.Start();
            t2.Start();
            t3.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main()");
            }

            Console.WriteLine("Main() ends");
        }
    }
}
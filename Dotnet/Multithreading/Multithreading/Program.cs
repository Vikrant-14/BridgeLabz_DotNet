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
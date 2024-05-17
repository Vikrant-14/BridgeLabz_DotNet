using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgrammingDemo
{
    public class Program
    {

        static void Main()
        {
            Console.WriteLine("Standard For loop");

            int number = 10;

            for (int i = 0; i <= number; i++)
            {
                Console.WriteLine($"value of count = {i}, thread = {Thread.CurrentThread.ManagedThreadId}");
                //Sleep the loop for 10 miliseconds
                Thread.Sleep(10);
            }

            Console.WriteLine("------------------------");
            Console.WriteLine("Parallel For Loop");

            Parallel.For(1,number+1, count =>
            {
                Console.WriteLine($"value of count = {count}, thread = {Thread.CurrentThread.ManagedThreadId}");
                //Sleep the loop for 10 miliseconds
                Thread.Sleep(10);
            });
        }

        static void Main1(string[] args)
        {
            Console.WriteLine("Standard For loop");

            for (int i = 0; i <= 10 ; i++)
            {
                Console.WriteLine(i); // output is predicatable
            }

            Console.WriteLine("------------------------");
            Console.WriteLine("Parallel For Loop");
            
            Parallel.For(1,11, number =>  Console.WriteLine(number)); // output is unpredicatable since each task/(iteration) is performed independently on various cores

        }
    }
}
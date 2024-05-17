using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel_programming
{
    public class Program
    {
        static long DoSomethingLongTask()
        {
            long total = 0;

            for (int i = 0; i < 1000000000; i++)
            {
                total += i;
            }

            return total;
        }

        static void Main()
        {
            Stopwatch sw = new Stopwatch();

            Console.WriteLine("Parallel Foreach Loop Started");

            sw.Start();

            List<int> list = Enumerable.Range(1, 10).ToList();

            Parallel.ForEach(list, (i) =>
            {
                long total = DoSomethingLongTask();
                Console.WriteLine("{0} - {1}", i, total);
            });


            Console.WriteLine("Parallel Foreach Loop Ended");
            sw.Stop();

            Console.WriteLine($"Time Taken by Parallel Foreach Loop in Miliseconds {sw.ElapsedMilliseconds}");
            Console.ReadLine();
        }
        static void Main1(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            Console.WriteLine("Standard Foreach Loop Started");

            sw.Start();

            List<int> list = Enumerable.Range(1,10).ToList();

            foreach (var i in list)
            {
                long total = DoSomethingLongTask();
                Console.WriteLine("{0} - {1}", i, total);
            }


            Console.WriteLine("Standard Foreach Loop Ended");
            sw.Stop();

            Console.WriteLine($"Time Taken by Standard Foreach Loop in Miliseconds {sw.ElapsedMilliseconds}");
            Console.ReadLine();
        }
    }
}

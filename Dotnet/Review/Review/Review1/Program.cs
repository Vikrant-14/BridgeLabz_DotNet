using System;
using System.Collections.Generic;

class HelloWorld
{
    public static void CountOccurence(int[] arr)
    {
        SortedList<int, int> list = new SortedList<int, int>();

        foreach (var i in arr)
        {
            int count = 1;

            if (!list.ContainsKey(i))
            {
                list.Add(i, count);
            }
            else
            {
                list[i]++;
            }
        }

        foreach (var j in list)
        {
            Console.WriteLine(j);
        }

    }

    static void Main()
    {
        int[] arr = { 1, 1, 2, 2, 3, 4, 5 };

        CountOccurence(arr);
    }
}
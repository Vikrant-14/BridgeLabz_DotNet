using System;
class HelloWorld
{

    public static void GetMiddle(string word)
    {
        int stringLength = word.Length;

        if (stringLength % 2 == 0)
        {
            Console.WriteLine($"{word.ElementAt((stringLength / 2)-1)}" + $"{word.ElementAt((stringLength / 2))}");
        }
        else if (stringLength == 1)
        {
            Console.WriteLine(word);
        }
        else
        {
            Console.WriteLine(word.ElementAt(stringLength / 2));
        }
    }

    public static void SumSmallest(long [] arr)
    {
        Array.Sort(arr);

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > 0)
            {
                Console.WriteLine(arr[i] + arr[i+1]);
                break;
            }
        }
    }

    static void Main()
    {
        GetMiddle("test");
        GetMiddle("testing");
        GetMiddle("middle");
        GetMiddle("A");

        Console.WriteLine("------------------------");

        long [] arr = { 19, 5, 42, 2, 77 };
        long [] arr2 = { 10, 343445353, 3453445, 3453545353453 };
        long[] arr3 = { 2, 9, 6, -1 };
        SumSmallest(arr);
        SumSmallest(arr2);
        SumSmallest(arr3);
    }
}
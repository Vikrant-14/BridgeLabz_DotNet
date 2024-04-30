using System;
using System.Collections.Generic;
class LamdbaExample
{
    static void Main()
    {
        Action<int, int> obj1 = (int a, int b) => {
            Console.WriteLine(a + b);
        };
        obj1(5, 4);

        Action<string> obj2 = (string input) => {
            Console.WriteLine(input);
        };
        obj2("Hello");

        Func<int, int, int> func1 = (int a, int b) => {
            return a + b;
        };
        Console.WriteLine(func1(8, 9));

        Func<string, string> func2 = (string input) => {
            return input;
        };
        Console.WriteLine(func2("Function Delegate"));

        Func<int> func3 = () => {
            return 100;
        };
        Console.WriteLine(func3());

        Predicate<int> pred1 = (int a) => {
            return true;
        };
        Console.Write(pred1(10));

        // Action<> obj3 = Func;
        // obj3();
    }
}

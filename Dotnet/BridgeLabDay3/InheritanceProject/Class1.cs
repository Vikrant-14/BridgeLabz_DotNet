using System;

namespace Inheritance
{
    internal class Class1
    {

        public Class1(int i) 
        {
            Console.WriteLine("Constructor of Class1 called. : " + i);
        }

        public void Test1()
        {
            Console.WriteLine("Method Test1 Called.");
        }

        public void Test2()
        { 
            Console.WriteLine("Method Test2 Called.");
        }
    }
}
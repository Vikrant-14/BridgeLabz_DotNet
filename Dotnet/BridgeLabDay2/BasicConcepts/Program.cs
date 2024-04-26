using System;

namespace BasicClassConcpets
{

    class Class1
    {
        int i;
        int y;
    }
    class BasicConcept
    {
        int x; // instance variable
        string str; // instance variable of type

        BasicConcept()
        { //Parameterless Constructor
            x = 10;
            str = "Hello";
        }

        BasicConcept(int x, string str)
        { //Parameterized Constructor
            this.x = x;
            this.str = str;
        }

        public void Display()
        {
            Console.WriteLine("Value of x : "+ this.x);
            Console.WriteLine("Value of str : "+ this.str);
        }

        static void Main()
        {
            BasicConcept b1 = new BasicConcept();
            b1.Display();

            Console.WriteLine("\n");

            BasicConcept b2 = new BasicConcept(20, "Dotnet");
            b2.Display();
        }
    }
}
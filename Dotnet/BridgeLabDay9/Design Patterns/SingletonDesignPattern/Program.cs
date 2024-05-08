using System;

namespace DesignPattern
{
    public class Singleton
    {
        private static Singleton? instance;

        private Singleton() 
        {
            Console.WriteLine("Singleton Instance is initialized");
        }

        public static Singleton GetInstance()
        {
            if( instance == null)
            {
                instance = new Singleton();
            }

            return instance;
        }

        public void Display()
        {
            Console.WriteLine("Instance : " + instance.GetHashCode());
        }
    }

    public class Program
    {
        static void Main()
        {
            Singleton obj1 = Singleton.GetInstance();
            obj1.Display(); //Instance : 43942917

            Singleton obj2 = Singleton.GetInstance();
            obj2.Display(); //Instance : 43942917
        }
    }
}

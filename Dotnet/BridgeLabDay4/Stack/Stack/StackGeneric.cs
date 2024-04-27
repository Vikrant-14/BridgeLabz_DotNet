using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StackDemo1
{
    internal class StackGeneric
    {
        Stack<int> s ;

        public void AddElement() 
        {
            Console.WriteLine("Add Element : ");
            int value = Convert.ToInt32(Console.ReadLine());

            this.s.Push(value);

            Console.WriteLine("Value added Successfully.");
        }

        public void RemoveElement()
        {
            Console.WriteLine($"Element removed  : {this.s.Pop()}");
        }

        public void PeekElement()
        {
            if (this.s.Count != 0)
                Console.WriteLine($"Element At Top of Stack  : {this.s.Peek()}");
            else
                Console.WriteLine("Stack is Empty");
        }

        public void ClearStack()
        {
            this.s.Clear();
            Console.WriteLine("All elements removed Successfully");
        }

        public void Display()
        {
            foreach (var stack in this.s)    
            {
                Console.WriteLine(stack);
            }
        }

        public static int MenuDriven()
        {
            int choice = 0;

            Console.WriteLine("=====================");
            Console.WriteLine("0. Enter Zero to exit.");
            Console.WriteLine("1. Enter One to add element");
            Console.WriteLine("2. Enter two to remove element");
            Console.WriteLine("3. Enter three to peek element");
            Console.WriteLine("4. Enter four to clear status");
            Console.WriteLine("5. Enter Five to Display elements");
            Console.WriteLine("=====================");

            choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }
        public static void Generic()
        {
            StackGeneric stack = new StackGeneric();
            stack.s = new Stack<int>();

            int choice = 0;

            while ((choice = MenuDriven()) != 0)
            {
                switch (choice)
                {
                    case 1:
                        stack.AddElement();
                        break;

                    case 2:
                        stack.RemoveElement();
                        break;

                    case 3:
                        stack.PeekElement();
                        break;

                    case 4:
                        stack.ClearStack();
                        break;

                    case 5:
                        stack.Display();
                        break;
                }
            }
        }
    }
}

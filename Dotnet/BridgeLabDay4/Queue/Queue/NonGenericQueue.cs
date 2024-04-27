using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueDemo
{
    internal class NonGenericQueue
    {
        Queue q;

        public void AddElement() {
            Console.WriteLine("Add Element : ");
            var element = Convert.ToInt32(Console.ReadLine());

            this.q.Enqueue(element);

            Console.WriteLine("Element added Successfully.");     
        }

        public void RemoveElement() 
        {
            Console.WriteLine($"Element removed  : {this.q.Dequeue()}");
        }

        public void PeekElement()
        {
            if (this.q.Count != 0)
                Console.WriteLine($"Element At Top of Stack  : {this.q.Peek()}");
            else
                Console.WriteLine("Stack is Empty");
        }

        public void ClearQueue()
        {
            this.q.Clear();
            Console.WriteLine("All elements removed Successfully");
        }

        public void Display()
        {
            if(this.q.Count != 0)
            {
                foreach (var item in q)
                {
                    Console.WriteLine(item);
                }
            }
            else { Console.WriteLine("Queue is empty."); }
        }

        public static int MenuDriven()
        {
            int choice = 0;

            Console.WriteLine("=====================");
            Console.WriteLine("0. Enter Zero to exit.");
            Console.WriteLine("1. Enter One to add element");
            Console.WriteLine("2. Enter two to remove element");
            Console.WriteLine("3. Enter three to peek element");
            Console.WriteLine("4. Enter four to clear Queue");
            Console.WriteLine("5. Enter Five to Display elements");
            Console.WriteLine("=====================");

            choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }
        public static void NonGeneric()
        {
            NonGenericQueue queue = new NonGenericQueue();
           queue.q = new Queue();

            int choice = 0;

            while ((choice = MenuDriven()) != 0)
            {
                switch (choice)
                {
                    case 1:
                        queue.AddElement();
                        break;

                    case 2:
                        queue.RemoveElement();
                        break;

                    case 3:
                        queue.PeekElement();
                        break;

                    case 4:
                        queue.ClearQueue();
                        break;

                    case 5:
                        queue.Display();
                        break;
                }
            }
        }

    }
}

using System;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SortedListDemo
{
    internal class NonGenericSortedList
    {
        SortedList sortedList;
        public void AddElement()
        {
            Console.WriteLine("Add key : ");
            int key = Convert.ToInt32(Console.ReadLine()); 
            Console.WriteLine("Add Element : ");
            int value = Convert.ToInt32(Console.ReadLine());
            
            if(!this.sortedList.ContainsKey(key)) 
            {
                this.sortedList.Add(key, value);
                Console.WriteLine("Element added Successfully.");
            }
            else
            {
                Console.WriteLine("Key Already Existed");
            }
        }

        public void RemoveElement()
        {
            Console.WriteLine("Enter Key : ");
            int key = Convert.ToInt32(Console.ReadLine());
            this.sortedList.Remove(key);
        }

        public void ClearList()
        {

            this.sortedList.Clear();
            Console.WriteLine("All elements removed Successfully");

        }

        public void Display()
        {
            if (this.sortedList.Count != 0)
            {
                foreach (DictionaryEntry item in sortedList)
                {
                    Console.WriteLine(item.Key + " : "  + item.Value);
                }
            }
            else { Console.WriteLine("Dictionary is empty."); }
        }

        public static int MenuDriven()
        {
            int choice = 0;

            Console.WriteLine("=====================");
            Console.WriteLine("0. Enter Zero to exit.");
            Console.WriteLine("1. Enter One to add element");
            Console.WriteLine("2. Enter two to remove element");
            Console.WriteLine("3. Enter three to clear list");
            Console.WriteLine("4. Enter four to Display elements");
            Console.WriteLine("=====================");

            choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }

        public static void NonGeneric()
        {
            NonGenericSortedList sl = new NonGenericSortedList();
            sl.sortedList = new SortedList();

            int choice = 0;

            while ((choice = MenuDriven()) != 0)
            {
                switch (choice)
                {
                    case 1:
                        sl.AddElement();
                        break;

                    case 2:
                        sl.RemoveElement();
                        break;

                    case 3:
                        sl.ClearList();
                        break;

                    case 4:
                        sl.Display();
                        break;
                }
            }
        }

    }
}

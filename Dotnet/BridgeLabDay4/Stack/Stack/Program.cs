using StackDemo1;
using System;
using System.Collections;
class StackDemo 
{
    Stack stack;
    public void AddElement() 
    {
        Console.WriteLine("Enter the integer value : ");
        int value = Convert.ToInt32(Console.ReadLine());
        this.stack.Push(value);
        Console.WriteLine("Value Added Successfully");
    }
    public void RemoveElement()
    {
        Console.WriteLine($"Element removed  : {this.stack.Pop()}");
    }

    public void PeekElement() 
    {
        Console.WriteLine($"Element At Top of Stack  : {this.stack.Peek()}");
    }

    public void ClearStack() 
    {
        this.stack.Clear();
        Console.WriteLine("All elements removed Successfully");
    }

    public void Display()
    {
        foreach (var stack in this.stack)
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

    public static void NonGeneric()
    {
        StackDemo s1 = new StackDemo();
        s1.stack = new Stack();

        int choice = 0;

        while ((choice = MenuDriven()) != 0)
        {
            switch (choice)
            {
                case 1:
                    s1.AddElement();
                    break;

                case 2:
                    s1.RemoveElement();
                    break;

                case 3:
                    s1.PeekElement();
                    break;

                case 4:
                    s1.ClearStack();
                    break;

                case 5:
                    s1.Display();
                    break;
            }
        }
    }
    
    static void Main() 
    {
        //NonGeneric();
        StackGeneric.Generic();
    }
}

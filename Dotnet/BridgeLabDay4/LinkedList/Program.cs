using System;
using System.ComponentModel;
public class LinkedList
{
    Node head;
    public class Node
    {
        public int data;
        public Node next;

        public Node(int data)
        {
            this.data = data;
            this.next = null;
        }
    }

    //Method to count the number of nodes
    public void Count() 
    {
        int count = 0;
        Node n = this.head;
        
        while (n != null)
        {
            n = n.next;
            count++;
        }

        Console.WriteLine(count);
    }

    //Methods to Add Node to the List
    public void InsertAtFront(int data)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            head = newNode;
        }

        newNode.next = head;
        head = newNode;
    }

    public void InsertAtEnd(int data)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node temp = head;

        while (temp.next != null)
        {
            temp = temp.next;
        }

        temp.next = newNode;
    }

    public void InsertAtPosition(int position, int data)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node temp = head;

        if (position == 0)
        {
            newNode.next = head;
            head = newNode;
            return;
        }

        for (int i = 0; temp != null && i < position - 1; i++)
        {
            temp = temp.next;
        }

        if (temp != null)
        {
            newNode.next = temp.next;
            temp.next = newNode;
        }
    }

    //Removing Node from the list
    public void RemoveNode(int data) 
    {
        if (head == null) 
        {
            Console.WriteLine("List is Empty");
            return; 
        }

        if ( head.data == data) //if data is at 1st position
        {
            head = head.next;
            return;
        }

        Node temp = head;
        Node prev = null;

        while( temp.data != data )
        {
            prev = temp;
            temp = temp.next;
        }

        prev.next = temp.next;

    }

    public void RemoveFromPosition(int position) 
    {
        if(head == null)
        {
            Console.WriteLine("List is Empty");
            return;
        }

        Node temp = head;
        Node prev = null;

        for(int i = 0; temp != null && i < position ; i++)
        {
            prev = temp;
            temp = temp.next;
        }

        prev.next = temp.next;
    }

    public Node FirstNode() 
    { 
        if(head == null)
        {
            Console.WriteLine("List is Empty");
            return null;
        }

        return head;
    }

    public Node LastNode() 
    {
        if (head == null)
        {
            Console.WriteLine("List is Empty");
            return null;
        }

        Node tempNode = head;

        while( tempNode.next != null)
        {
            tempNode = tempNode.next;
        }

        return tempNode;
    }

    public void Display() 
    {
        Node n = head;
        while (n != null) 
        {
            Console.Write(n.data  + " ");
            n = n.next;
        }
        Console.WriteLine();
    }

    public static void Main()
    {
        LinkedList l1 = new LinkedList();
        l1.head = new Node(1);
        l1.head.next = new Node(2);
        l1.head.next.next = new Node(3);

        l1.Display();
        Console.WriteLine("-------");

        l1.InsertAtFront(4);
        l1.InsertAtFront(5);
        l1.InsertAtFront(6);

        l1.Display() ;


        LinkedList l2 = new LinkedList();
        l2.InsertAtEnd(1);
        l2.InsertAtEnd(2);
        l2.InsertAtEnd(3);
        l2.InsertAtEnd(4);
        l2.InsertAtEnd(5);

        Console.WriteLine("-------");
        
        l2.Display();

        l2.InsertAtPosition(2, 6);
        l2.InsertAtPosition(7, 9);

        Console.WriteLine("-------");


        l2.Display();

        Console.WriteLine("-------");
        //l2.RemoveNode(6);
        //l2.RemoveNode(1);
        //l2.RemoveNode(5);
        l2.RemoveFromPosition(2);
        l2.Display() ;
        l2.Count();

    }
}
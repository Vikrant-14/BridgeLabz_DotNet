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

    public void Display() 
    {
        Node n = head;
        while (n != null) 
        {
            Console.WriteLine(n.data);
            n = n.next;
        }
    }

    public static void Main()
    {
        LinkedList l1 = new LinkedList();
        l1.head = new Node(1);
        l1.head.next = new Node(2);
        l1.head.next.next = new Node(3);

        l1.Display();

    }
}
internal class GenericList<T>
{
    private Node? head;
    private class Node
    {
        private T data;
        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        private Node? next;
        public Node? Next
        {
            get { return  next; }
            set { next = value; }
        }

        public Node(T data)
        {
            this.data = data;
            this.next = null;
        }
    }

    public GenericList()
    {
        this.head = null;
    }

    public void AddHead(T  data)
    {
        Node n = new Node(data);
        n.Next = head;
        head = n;
    }

    public void Display()
    {
        Node n = head;
        while (n != null)
        {
            Console.Write(n.Data + " ");
            n = n.Next;
        }
        Console.WriteLine();
    }
}

public class TestGenericList
{
    static void Main()
    {
        GenericList<int> list = new GenericList<int>();

        for(int i = 0; i < 10; i++)
        {
            list.AddHead(i+10);
        }

        list.Display();

        GenericList<string> list2 = new GenericList<string>();

        list2.AddHead("a");
        list2.AddHead("b");
        list2.AddHead("c");

        list2.Display();

       
    }
}

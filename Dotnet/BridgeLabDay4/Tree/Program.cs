using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class TreeDemo
{
    public Node root;

    public class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int data)
        {
            this.data = data;
            this.left = this.right = null;
        }

    }

    public TreeDemo()
    {
        this.root = null;
    }

    public TreeDemo(int data)
    {
        this.root = new Node(data);
    }

    public Node Insert(Node root, int data)
    {
        if (root == null)
        {
            root = new Node(data);
            return root;
        }

        if (data <= root.data)
        {
            root.left = Insert(root.left, data);
        }
        else
        {
            root.right = Insert(root.right, data);
        }

        return root;
    }

    public void InsertData(int data)
    {
       root = Insert(root, data);
    }

    public void PrintInorder(Node root)
    {
        if (root == null)
        {
            return;
        }

        PrintInorder(root.left);
        Console.WriteLine(root.data);
        PrintInorder(root.right);
    }

    public void Inorder()
    {
        PrintInorder(root);
    }

    public bool Search(Node root, int data)
    {
        if (root != null)
        {
            if (root.data == data)
            {
                return true;
            }

            if (data < root.data)
            {
                 return Search(root.left, data);
            }
            else if (data > root.data)
            {
                 return Search(root.right, data);
            }
        }
       
        return false;
        
    }

    static void Main()
    {
        TreeDemo t1 = new TreeDemo(50);
        //t1.root = new Node(50);
        t1.root.left = new Node(50);
        t1.root.right = new Node(60);

        t1.Inorder();
        Console.WriteLine("---------");

        t1.InsertData(45);
        t1.InsertData(65);
        t1.InsertData(89);
        t1.InsertData(30);

        t1.Inorder();

        if(t1.Search(t1.root, 55))
        {
            Console.WriteLine("Found");
        }
        else
        {
            Console.WriteLine("Not found");
        }
    }
}
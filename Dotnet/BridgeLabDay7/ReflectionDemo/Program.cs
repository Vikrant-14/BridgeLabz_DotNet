using System;
using System.Reflection;

namespace ReflectionExamlpe
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Customer()
        {
            this.Id = 0;
            this.Name = string.Empty;
        }

        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void PrintID()
        {
            Console.WriteLine("ID = {0}", this.Id);
        }

        public void PrintName()
        {
            Console.WriteLine("NAme = {0}", this.Name);
        }
    }

    internal class Program
    { 
        public static void Main(string[] args)
        {
            //Type t = Type.GetType("ReflectionExamlpe.Customer");
            Type t = typeof(Customer);

            Console.WriteLine("Full Name = {0}" , t.FullName);
            Console.WriteLine("Name = {0}", t.Name);
            Console.WriteLine("Namespace = {0}", t.Namespace);

            //Properties in Customer
            Console.WriteLine("------------------\nProperties in Customer\n-----------------");

            PropertyInfo[] p = t.GetProperties();
            foreach (PropertyInfo pi in p)
            {
                Console.WriteLine(pi.PropertyType.Name + " " +  pi.Name);
            }

            //Methods in Customer
            Console.WriteLine("------------------\nMethods in Customer\n-----------------");

            MethodInfo[] m = t.GetMethods();
            foreach (var mi in m)
            {
                Console.WriteLine(mi.ReturnType.Name + " " + mi.Name);
            }

            //Constructors in Customer
            Console.WriteLine("------------------\nConstructors in Customer\n-----------------");

            ConstructorInfo[] c = t.GetConstructors();
            foreach (var ci in c)
            {
                Console.WriteLine(ci.ToString());
            }

            Customer c1 = new();
            Console.WriteLine(c1.GetType().Name);
        }
    }

  

}
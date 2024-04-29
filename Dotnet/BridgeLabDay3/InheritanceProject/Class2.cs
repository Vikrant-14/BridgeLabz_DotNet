using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Class2 : Class1
    {
        public Class2(int a) : base(a)
        {
            Console.WriteLine("Constructor of Class2 called. : " + a );
        }
        public static void Main() { 
            Class2 class2 = new Class2(20);

            Console.WriteLine(class2.GetType());
        }
    }
}

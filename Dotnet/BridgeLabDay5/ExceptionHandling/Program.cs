using System;

namespace ExceptionHandling 
{

    public class Class1
    {
        public int P1 { get; set; }
    }

    internal class ExceptionDemo 
    {

        static void Main4() //Base class try catch() block and finally block
        {
            Console.WriteLine("Exception Handling\n------------------");

            Class1 obj = new Class1();
            obj = null;

            try
            {
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = 100 / x;
                int result = 100 / x;

                Console.WriteLine("Result : " + obj.P1);
                Console.WriteLine("Result : " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Finally block Executed!!!");
            }

            Console.WriteLine("------------------\nOutside Catch Block");
        }

        static void Main3() //Multiple try catch() block
        {
            Console.WriteLine("Exception Handling\n------------------");

            Class1 obj = new Class1();
            obj = null;

            try
            {
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = 100 / x;
                int result = 100 / x;

                Console.WriteLine("Result : " + obj.P1);
                Console.WriteLine("Result : " + result);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Exception Occured : Attempt to divide by zero!!!");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Exception Occured : Null Reference Exception!!!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Exception Occured : Format Exception!!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("------------------\nOutside Catch Block");
        }


        static void Main2() //Single try catch() block
        {
            Console.WriteLine("Exception Handling\n------------------");

            Class1 obj = new Class1();
            obj = null;

            try
            {
                int x = Convert.ToInt32(Console.ReadLine());
                //obj.P1 = 100 / x;
                int result = 100 / x;

                Console.WriteLine("Result : " + result);
            }
            catch(DivideByZeroException ex) 
            {
                Console.WriteLine("Exception Occured : Attempt to divide by zero!!!");
            }

            Console.WriteLine("Outside Catch Block");
        }

        static void Main1() //Without try catch() block
        {
            Console.WriteLine("Exception Handling\n------------------");

            Class1 obj = new Class1();
            obj = null;

            int x = Convert.ToInt32(Console.ReadLine());

            obj.P1 = 100 / x;

            Console.WriteLine("Result : " + obj.P1);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling2
{
    public class Class1
    {
        private int p1;
        public int P1
        {
            get { return p1; }
            set
            {
                if (value < 100)
                {
                    p1 = value;
                }
                else
                {
                    throw new InvalidP1Exception("Exception Occurred : Invalid P1 Exception , number should be less than 100!!!");
                }
            }
        }
    }
    internal class UserDefinedException
    {
        public static void Main() 
        {
            Console.WriteLine("Exception Handling\n------------------");

            Class1 obj = new();

            try
            {
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = x;
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
            catch(InvalidP1Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw new InvalidP1Exception("Exception Occured : Invalid P1 Exception , number should be less than 100!!!");
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
    }

    public class InvalidP1Exception : ApplicationException 
    {
        string message;

        public InvalidP1Exception(string message) : base(message)
        {
            this.message = message;
        }
    }
}

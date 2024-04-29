using System;
using System.Text.RegularExpressions;

namespace RegexDemo
{
    internal class RegexExample1
    {
        string email , password, number;
        public void AcceptRecord()
        {
            Console.Write("Enter your Email : ");
             this.email = Console.ReadLine();

            Console.Write("Enter password : ");
             this.password = Console.ReadLine();

            Console.Write("Enter phone number : ");
            this.number = Console.ReadLine();
        }

        public void CheckRegex()
        {
            var emailPattern = @"[a-z].{5,}\d@(gmail|yahoo|[a-z]+)+.(com|co|in)";

            Regex reg1 = new Regex(emailPattern);

            if (reg1.IsMatch(this.email))
            {
                Console.WriteLine($"Your Email Id : {this.email}");
            }
            else
            {
                Console.WriteLine("Invalid Email format!!!");
            }


            var passwordPattern = @"(?=.*[A-Z])(?=.*[!@#$%^&*()])(?=.*[0-9]).{8,}";

            Regex reg2 = new Regex(passwordPattern);

            if (reg2.IsMatch(this.password))
            {
                Console.WriteLine($"Your passowrd : {this.password}");
            }
            else
            {
                Console.WriteLine("Invalid password");
            }

            var phonePattern = @"([+]\d{2})?\d{10}";

            Regex reg3 = new Regex(phonePattern);

            if (reg3.IsMatch(this.number))
            {
                Console.WriteLine($"Your Phone number : {this.number}");
            }
            else
            {
                Console.WriteLine("Invalid Number");
            }
        }
        static void Main()
        {
            RegexExample1 reg = new RegexExample1();

            reg.AcceptRecord();
            reg.CheckRegex();

        }
    }
}

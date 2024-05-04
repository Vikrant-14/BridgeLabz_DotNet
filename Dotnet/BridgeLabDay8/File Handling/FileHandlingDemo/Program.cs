using System;
using System.Diagnostics;
using System.IO;

namespace FileHandling_Demo
{
    public class FileHandle
    {

        public static void Main()
        {
            string filePath = "C:\\Users\\kirti\\Vikrant\\CDAC\\Bridge Labz\\Dotnet\\BridgeLabDay8\\File Handling\\DemoDirectory1";

            if(!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
                Console.WriteLine("New Directory Created.");
            }
            else
            {
                Console.WriteLine("Directory Already Existed");
            }

            string filePath2 = "C:\\Users\\kirti\\Vikrant\\CDAC\\Bridge Labz\\Dotnet\\BridgeLabDay8\\File Handling\\DemoDirectory1\\main.txt";

            if (!File.Exists(filePath2))
            {
                File.Create(filePath2);
                Console.WriteLine("File Created");
            }
            else
            {
                Console.WriteLine("File Already Existed");
            }

            if(File.Exists(filePath2))
            {
                string[] strings = { "A", "B", "C", "D" };
                File.AppendAllLines(filePath2, strings);
                Console.WriteLine("Data Inserted");
            }
            else
            {
                Console.WriteLine("File Does Not Exists");
            }

            Console.WriteLine(File.ReadAllText(filePath2));
        }

        //Appending and writing in the file
        public static void Main2()
        {
            string filePath = "C:\\Users\\kirti\\Vikrant\\CDAC\\Bridge Labz\\Dotnet\\BridgeLabDay8\\File Handling\\DemoTest2.txt";

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
                Console.WriteLine("File Created Successfully.");
            }
            else
            {
                Console.WriteLine("File Already Existed");
            }

            string[] str = { "Hello Everyone", "Good Afternoon" };
            File.AppendAllLines(filePath, str);

            Console.WriteLine(File.ReadAllText(filePath));

        }

        //Reading File
        public static void Main1()
        {
            string filePath = "C:\\Users\\kirti\\Vikrant\\CDAC\\Bridge Labz\\Dotnet\\BridgeLabDay8\\File Handling\\DemoTest1.txt"; 

            if(!File.Exists(filePath))
            {
                File.Create(filePath );
                Console.WriteLine("File Created Successfully.");
            }
            else
            {
                Console.WriteLine("File Already Existed");
            }



            Console.WriteLine(File.ReadAllText(filePath));

            string[] fileReader = File.ReadAllLines(filePath);

            foreach (var item in fileReader)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}

using System;

namespace StreamDemo
{
    public class Program
    {
        //Writing content to the Stream
        static void Main()
        {
            try
            {
                string filePath = "C:\\Users\\kirti\\Vikrant\\CDAC\\Bridge Labz\\Dotnet\\BridgeLabDay8\\File Handling\\DemoTest2.txt";
                
                using(StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine("Hello C#");
                    sw.Flush();
                    sw.Close();

                    Console.WriteLine(File.ReadAllText(filePath));
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.ToString());   
            }
        }

        //Reading file from the Stream
        static void Main1()
        {
            try
            {
                string filePath = "C:\\Users\\kirti\\Vikrant\\CDAC\\Bridge Labz\\Dotnet\\BridgeLabDay8\\File Handling\\DemoTest1.txt";

                string s;

                using (StreamReader sr = new(filePath))
                {
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }           
        }
    }
}
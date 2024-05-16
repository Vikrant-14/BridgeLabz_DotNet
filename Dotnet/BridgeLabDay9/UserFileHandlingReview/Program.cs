using System;
using System.Globalization;
using System.Xml.Serialization;

namespace FileHandlingReview
{
    public class UserFileHandling
    {
        public static int MenuDriven()
        {
            int choice = 0;
            try
            {

                Console.WriteLine("====================");
                Console.WriteLine("1. Enter One to Create a File.");
                Console.WriteLine("2. Enter two to Read the contents of an existing file");
                Console.WriteLine("3. Enter three to Update the contents of an existing file");
                Console.WriteLine("4. Enter four to Delete an existing file");
                Console.WriteLine("0. Enter Zero to Exit the application");
                Console.WriteLine("====================");
            
                 choice = Convert.ToInt32(Console.ReadLine());
  
            }
            catch(FormatException e)
            {
                Console.WriteLine("Invalid input");
            }

            return choice;
        }

        public void CreateFile(string filePath)
        {
            if(!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                Console.WriteLine("File Created Successfully");
                
                
            }
            else
            {
                throw new UserFileException("File already exists");
            }
        }

        public void ReadFile(string filePath)
        {
            if(File.Exists(filePath))
            {
                try
                {
                    Console.WriteLine(File.ReadAllText(filePath));
                }
                catch(IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                throw new UserFileException("File doesnot exists");
            }
        }

        public void UpadteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                String? content = Console.ReadLine();

                File.AppendAllText(filePath, content);

                Console.WriteLine("File Updated successfully");
            }
            else
            {
                throw new UserFileException("File doesnot exists");
            }
        }

        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine("File Deleted Successfully.");
            }
            else
            {
                throw new UserFileException("File doesnot exists");
            }
        }

        public static void Main()
        {
            int choice;
            String fileName;
            string filePath;

            UserFileHandling u1 =new UserFileHandling();

            while ((choice = MenuDriven()) != 0)
            {
                switch (choice)
                {
                    case 1:
                        try
                        {
                            Console.Write("Enter the name the file : ");
                            fileName = Console.ReadLine();

                            if (fileName == "")
                            {
                                throw new UserFileException("File Name should not be null");
                               
                            }

                            filePath = $"C:\\Users\\kirti\\Vikrant\\CDAC\\Bridge Labz\\Dotnet\\BridgeLabDay9\\{fileName}.txt";

                            u1.CreateFile(filePath);
                        }
                        catch (UserFileException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    case 2:
                        try
                        {
                            Console.Write("Enter the name the file : ");
                            fileName = Console.ReadLine();

                            if (fileName == "")
                            {
                                throw new UserFileException("File Name should not be null");
                            }

                            filePath = $"C:\\Users\\kirti\\Vikrant\\CDAC\\Bridge Labz\\Dotnet\\BridgeLabDay9\\{fileName}.txt";

                            Console.WriteLine("Reading Content from file " + fileName);

                            u1.ReadFile(filePath);
                        }
                        catch(UserFileException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    case 3:
                        try
                        {
                            Console.Write("Enter the name the file : ");
                            fileName = Console.ReadLine();

                            if (fileName == "")
                            {
                                throw new UserFileException("File Name should not be null");
                            }

                            filePath = $"C:\\Users\\kirti\\Vikrant\\CDAC\\Bridge Labz\\Dotnet\\BridgeLabDay9\\{fileName}.txt";

                            u1.UpadteFile(filePath);
                        }
                        catch(UserFileException ex)
                        {
                            Console.WriteLine (ex.Message);
                        }

                        break;

                    case 4:
                        try
                        {
                            Console.Write("Enter the name the file to delete : ");
                            fileName = Console.ReadLine();

                            if (fileName == "")
                            {
                                throw new UserFileException("File Name should not be null");
                            }

                            filePath = $"C:\\Users\\kirti\\Vikrant\\CDAC\\Bridge Labz\\Dotnet\\BridgeLabDay9\\{fileName}.txt";

                            u1.DeleteFile(filePath);

                        }
                        catch (UserFileException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                }
            }
        }
       
    }

    public class UserFileException : Exception
    {
        public UserFileException(string message) : base(message) 
        {
            
        }
    }
}

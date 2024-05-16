using DiscconnectedCRUD;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Disconnected_Example
{
    public class DisconnectedCRUD
    {
        static string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AddressBook_Practice;User Id=sa;Password=cdac123;";
        static  SqlDataAdapter? adapter;
        static DataSet? dataset;

        public void UpdateDatebase()
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(dataset,"Contacts");
            Console.WriteLine("Data updated successfully");
        }

        public void Select()
        {
            Console.WriteLine("Contact List : \n--------------------");

            DataTable dt = dataset.Tables["Contacts"];

            foreach(DataRow row in dt.Rows)
            {
                Console.WriteLine("First Name : {0}\r\nLast Name : {1}\r\nEmail : {2}\r\nAddress : {3}\r\nCity : {4}\r\nState : {5}\r\nZip Code : {6}\r\nPhone Number : {7}", row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7]);
                Console.WriteLine("------------");
            }
        }
        public void Insert()
        {
            DataTable dt = dataset.Tables["Contacts"];

            DataRow newRow = dt.NewRow();

            Contact contact = new Contact();
            contact.AcceptContactRecord();

            newRow["first_name"] = contact.FirstName;
            newRow["last_name"] = contact.LastName;
            newRow["email"] = contact.Email;
            newRow["address"] = contact.Address;
            newRow["city"] = contact.City;
            newRow["state"] = contact.State;
            newRow["zip"] = contact.Zip;
            newRow["phone_number"] = contact.PhoneNumber;

            dt.Rows.Add(newRow);
            UpdateDatebase();
        }

        public void UpdateRecord()
        {
            Console.Write("Enter the first name : ");
            string name = Console.ReadLine();

            DataTable dt = dataset.Tables["Contacts"];
            DataRow[] rows = dt.Select($"first_name = '{name}'");

            if(rows.Length == 1)
            {
                DataRow row = rows[0];

                Console.Write("Enter Phone number to be updated : ");
                long newPhoneNumber = Convert.ToInt64(Console.ReadLine());

                row["phone_number"] = newPhoneNumber;

                using(SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();

                    string updateQuery = "UPDATE Contacts SET phone_number = @newPhoneNumber WHERE first_name = @firstName";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, con);
                    updateCommand.Parameters.AddWithValue("@newPhoneNumber", newPhoneNumber);
                    updateCommand.Parameters.AddWithValue("@firstName", name);

                    updateCommand.ExecuteNonQuery();

                    Console.WriteLine("Contact updated successfully.");

                    con.Close();
                }

                UpdateDatebase() ;  
            }
            else
            {
                Console.WriteLine("Contact not found");
            }
        }

        public void Delete()
        {
            Console.Write("Enter First Name : ");
            string name = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                
                string query = "Delete from Contacts where first_name = @FirstName";
                
                SqlCommand deleteCommand = new SqlCommand(query, con);
                deleteCommand.Parameters.AddWithValue("@FirstName", name);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.DeleteCommand = deleteCommand;

                DataTable dt = dataset.Tables["Contacts"];
                DataRow[] rows = dt.Select($"first_name = '{name}'");

                if (rows.Length > 0)
                {
                    foreach (DataRow row in rows)
                    {
                        row.Delete();
                    }
                    Console.WriteLine("Data deleted Successfully");
                }
                else
                {
                    Console.WriteLine("Contact does not exists.");
                }
                UpdateDatebase();

            }
        }

        public static int MenuDriven()
        {
            int choice;
            Console.WriteLine("==================================");
            Console.WriteLine("Enter 0 to Exit the Application");
            Console.WriteLine("Enter 1 to Display the Records");
            Console.WriteLine("Enter 2 to Insert the Record");
            Console.WriteLine("Enter 3 to Update the Record");
            Console.WriteLine("Enter 4 to Delete the Record");
            Console.WriteLine("==================================");
            choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }

        public static void Main()
        {
            adapter = new SqlDataAdapter("select * from contacts", _connectionString);
            dataset = new DataSet();

            adapter.Fill(dataset, "Contacts");

            DisconnectedCRUD d1 = new();

            int choice;

            while ((choice = MenuDriven()) != 0)
            {
                switch (choice)
                {
                    case 1:
                        d1.Select();
                        break;

                    case 2:
                        d1.Insert();
                        break;

                    case 3:
                        d1.UpdateRecord();
                        break;

                    case 4:
                        d1.Delete();
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}
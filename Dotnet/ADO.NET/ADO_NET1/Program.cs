using System;
using System.Data;
using System.Data.SqlClient;

namespace ADO.NETExamples
{
    public class Program
    {
        public static void Connection()
        {
            string cs = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ado_net_practice;User Id=sa;Password=cdac123;";
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(cs))
                {
                    con.Open();

                    if (con.State == ConnectionState.Open)
                    {
                        Console.WriteLine("Connection establish.");
                    }
                    else
                    {
                        Console.WriteLine("Error Occured.");
                    }
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }
        public static void Main()
        {
            Program.Connection();
        }
    }
}

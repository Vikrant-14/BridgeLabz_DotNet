using System;
using System.Data.SqlClient;

namespace ADO.NETExamples
{
    public class Program
    {
        public static void Main()
        {
            Program.Connection();
        }
        public static void Connection()
        {
            string cs = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Test1;User Id=sa;Password=cdac123;";
            SqlConnection con = null;

            try
            {
                using(con = new SqlConnection(cs))
                {
                    string query = "select * from customers";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Console.WriteLine(dr["Name"]  + " " + dr["Address"] + " " + dr["Phone"]);
                    }
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            { 
                con.Close(); 
            }
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;

namespace DisconnectedArchitecture
{
    public class Program
    {
        static void Main()
        {
            string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=test1;User Id=sa;Password=cdac123;";
            SqlConnection con = null;

            try
            {
                using( con = new SqlConnection( _connectionString ) )
                {
                    string query = "select * from customers";

                    SqlDataAdapter adapter = new(query,con);
                    
                    DataTable dataTable = new();

                    adapter.Fill(dataTable);

                    foreach(DataRow row in dataTable.Rows)
                    {
                        Console.WriteLine(row["customer_id"] + " : "+ row["name"] + " - " + row["phone"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        static void Main1()
        {
            string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=test1;User Id=sa;Password=cdac123;";
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(_connectionString))
                {
                    string query = "select * from Customers";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query,con);

                    string query2 = "select * from Orders";
                    SqlDataAdapter dataAdapter2 = new SqlDataAdapter(query2, con);

                    DataSet dataset = new DataSet();



                    dataAdapter.Fill(dataset);
                    dataAdapter2.Fill(dataset);

                    //Console.WriteLine(dataset.GetXml());
                    dataset.Tables[0].TableName = "Customers";
                    DataTable dt = dataset.Tables["Customers"];

                    foreach (DataRow row in dataset.Tables[0].Rows)
                    {
                        Console.WriteLine("{0} {1}", row[0], row[1]);
                    }
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
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

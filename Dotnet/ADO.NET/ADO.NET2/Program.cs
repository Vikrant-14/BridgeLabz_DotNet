using System;
using System.Data.SqlClient;

namespace ADO.NETExamples
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }

    }

    public class Program
    {

        public static void Update1(Customer obj)
        {
            string cs = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Test1;User Id=sa;Password=cdac123;";
            SqlConnection con = null;

            try
            {
                using (con = new SqlConnection(cs))
                {
                    Console.Write("Enter Name to be updated : ");
                    string name = Console.ReadLine();

                    string query = "update Customers set name = @CustomerName where email = @CustomerEmail;";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@CustomerName", name);
                    cmd.Parameters.AddWithValue("@CustomerEmail", obj.Email);

                    con.Open();

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Query Executed");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public static void Update()
        {
            string cs = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Test1;User Id=sa;Password=cdac123;";
            SqlConnection con = null;

            try
            {
                using(con = new SqlConnection(cs))
                {
                    string query = "update Customers set name = 'Saurav' where Customer_ID = 4;";

                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Query Executed");
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
        public static void GetSingleValue()
        {
            string cs = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Test1;User Id=sa;Password=cdac123;";
            SqlConnection con = null;

            try
            {
                using (con = new SqlConnection(cs))
                {
                    string query = "select name from customers where customer_id = 2";

                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();

                    Object c1 = cmd.ExecuteScalar();

                    Console.WriteLine(c1);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public static void Insert2(Customer obj)
        {
            string cs = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Test1;User Id=sa;Password=cdac123;";
            SqlConnection con = null;

            try
            {
                using (con = new SqlConnection(cs))
                {
                    string query = $"insert into customers(name,email,phone,address) values(@CustomerName,@CustomerEmail,@CustomerPhone,@CustomerAddress)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@CustomerName", obj.Name);
                    cmd.Parameters.AddWithValue("@CustomerEmail", obj.Email);
                    cmd.Parameters.AddWithValue("@CustomerPhone", obj.Phone);
                    cmd.Parameters.AddWithValue("@CustomerAddress", obj.Address);

                    con.Open();

                    int rows = cmd.ExecuteNonQuery();

                    Console.WriteLine($"Number of rows affected : {rows}");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        
        public static void Insert1(Customer obj)
        {
            string cs = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Test1;User Id=sa;Password=cdac123;";
            SqlConnection con = null;

            try
            {
                using(con = new SqlConnection(cs))
                {
                    string query = $"insert into customers(name,email,phone,address) values('{obj.Name}','{obj.Email}',{obj.Phone},'{obj.Address}')";

                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                   
                    int rows = cmd.ExecuteNonQuery();

                    Console.WriteLine($"Number of rows affected : {rows}");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public static void Insert()
        {
            string cs = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Test1;User Id=sa;Password=cdac123;";
            SqlConnection con = null;

            try
            {
                using( con = new SqlConnection(cs))
                {
                    string query = "insert into customers(name,email,phone,address) values('shubham','shubham@gmail.com',8457693217,'a/45, Resolute height, Kalva')";

                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();

                    Console.WriteLine($"Number of rows affected : {rows}");

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

        public static void Main()
        {
            //Program.Connection();
            //Program.Insert();

            Customer c1 = new Customer() { 
                 Name = "Sakshi",
                 Email = "sakshi@gmail.com",
                 Phone = 6598742318,
                 Address = "GauriSuta, Panvel"
            };

            //Program.Insert1(c1);

            Customer c2 = new Customer()
            {
                Name = "Renuka",
                Email = "renuka@gmail.com",
                Phone = 8457123698,
                Address = "Ganesh Apt., Khar"
            };

            //Program.Insert2(c2);

            //Program.GetSingleValue();

            //Program.Update();

            Program.Update1(c1);
        }
    }
}

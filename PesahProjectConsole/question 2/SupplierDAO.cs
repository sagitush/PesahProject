using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace question_2
{
    class SupplierDAO
    {
        private static string dbName = @"Data Source=LAPTOP-IMU119RQ\MSSQLSERVER02;Initial Catalog=PesahProject;Integrated Security=True";

        public static Supplier FindSupplier()
        {
            Console.WriteLine("Hello supplier, what is your user name?");

            string user = Console.ReadLine();

            Console.WriteLine("what is your password?");

            string password = Console.ReadLine();

            using (SqlConnection conn = new SqlConnection(dbName))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM SUPPLIERS WHERE USER_NAME='{user}' AND PASSWORD='{password}'", conn);

                cmd.Connection.Open();

                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                if (reader.Read() == true)

                {
                   
                    Supplier s = new Supplier 
                    {
                        IdSupplier = (Int32)reader["ID_SUPPLIER"],
                        User = (string)reader["USER_NAME"],
                        Password =(string) reader["PASSWORD"],
                        CompanyName =(string) reader["COMPANY_NAME"],
                    };

                    cmd.Connection.Close();

                    return s;
                }
                else
                {
                    Console.WriteLine("there is no supplier with this user name or password");

                    return null;
                }

            }
        }

        public static void AddProduct(Int32 ids)
        {
            Console.WriteLine("Which product would you like to add?");

            string name = Console.ReadLine();

            SqlCommand cmd1 = new SqlCommand();

            cmd1.Connection = new SqlConnection(dbName);

            cmd1.Connection.Open();

            cmd1.CommandType = CommandType.Text;

            cmd1.CommandText = $"SELECT * FROM PRODUCTS1 WHERE PRODUCT_NAME='{name}'";

            SqlDataReader reader = cmd1.ExecuteReader(CommandBehavior.Default);

            if (reader.Read() == true)
            {

                Product p = new Product
                {
                    IdProduct = (Int32)reader["ID_PRODUCT"],
                    ProductName = (string)reader["PRODUCT_NAME"],
                    SupplierNumber = (int)reader["SUPPLIER_NUMBER"],
                    Price = (int)reader["PRICE"],
                    Quantity = (int)reader["QUANTITY"]
                };

                if (p.SupplierNumber != ids)
                {

                    Console.WriteLine("There is other supplier to this product");

                }
                else
                {

                    Console.WriteLine("What is the amount?");

                    int amount = Convert.ToInt32(Console.ReadLine());

                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = new SqlConnection(dbName);

                    cmd.Connection.Open();

                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = $"UPDATE PRODUCTS1 SET QUANTITY={p.Quantity+amount} WHERE PRODUCT_NAME='{name}'";

                    cmd.ExecuteNonQuery();

                    cmd.Connection.Close();

                }

            }
            else
            {
                Console.WriteLine("What is the price of the product?");

                int price = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("What is the amount?");

                int amount = Convert.ToInt32(Console.ReadLine());

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = new SqlConnection(dbName);

                cmd.Connection.Open();

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = $"INSERT INTO PRODUCTS1 (PRODUCT_NAME,SUPPLIER_NUMBER,PRICE,QUANTITY) VALUES('{name}',{ids},{price},{amount})";

                cmd.ExecuteNonQuery();

                cmd.Connection.Close();
            }
            
        }

        public static void SelectAllProductsS(Int64 ids)
        {
            SqlCommand cmd1 = new SqlCommand();

            cmd1.Connection = new SqlConnection(dbName);

            cmd1.Connection.Open();

            cmd1.CommandType = CommandType.Text;

            cmd1.CommandText = $"SELECT * FROM PRODUCTS1 WHERE SUPPLIER_NUMBER={ids}";

            SqlDataReader reader = cmd1.ExecuteReader(CommandBehavior.Default);

            while (reader.Read() == true)
            {
                Product p = new Product
                {
                    IdProduct = (Int32)reader["ID_PRODUCT"],
                    ProductName = (string)reader["PRODUCT_NAME"],
                    SupplierNumber = (int)reader["SUPPLIER_NUMBER"],
                    Price = (int)reader["PRICE"],
                    Quantity = (int)reader["QUANTITY"]
                };

                Console.WriteLine(p);
            }
            
            cmd1.Connection.Close();
        }

        public static void NewSupplier()
        {
            Console.WriteLine("Welcome to our website, to provide us products , you have to answer this questions:");

            Console.WriteLine("Choose a user name:");

            string user = Console.ReadLine();

            Console.WriteLine("Choose a password:");

            string password = Console.ReadLine();

            Console.WriteLine("What is your company name?");

            string name = Console.ReadLine();

            SqlCommand cmd1 = new SqlCommand();

            cmd1.Connection = new SqlConnection(dbName);

            cmd1.Connection.Open();

            cmd1.CommandType = CommandType.Text;

            cmd1.CommandText = $"INSERT INTO SUPPLIERS (USER_NAME,PASSWORD,COMPANY_NAME) VALUES('{user}','{password}','{name}')";

            cmd1.ExecuteNonQuery();

            cmd1.Connection.Close();

        }



    }
}
    

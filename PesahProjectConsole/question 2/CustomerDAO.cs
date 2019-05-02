using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace question_2
{
    class CustomerDAO
    {
        
        private static string dbName =@"Data Source=LAPTOP-IMU119RQ\MSSQLSERVER02;Initial Catalog=PesahProject;Integrated Security=True";

        public static Customer FindCustomer()
        {
            Console.WriteLine("Hello customer, what is your user name?");

            string user = Console.ReadLine();

            Console.WriteLine("what is your password?");

            string password = Console.ReadLine();

            using (SqlConnection conn = new SqlConnection(dbName))
            {
                SqlCommand cmd= new SqlCommand($"SELECT * FROM CUSTOMERS WHERE USER_NAME='{user}' AND PASSWORD='{password}'",conn);

                cmd.Connection.Open();

                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                if (reader.Read() == true)

                {
                    Customer c = new Customer
                    {
                        IdCustomer = (Int32)reader["ID_CUSTOMER"],
                        User = (string)reader["USER_NAME"],
                        Password = (string)reader["PASSWORD"],
                        FirstName = (string)reader["FIRST_NAME"],
                        LastName = (string)reader["LAST_NAME"],
                        CreditNumber = (int)reader["CREDIT_NUMBER"]
                    };

                    cmd.Connection.Close();

                    return c;
                    }
                else
                {
                    Console.WriteLine("there is no customer with this user name or password");

                    return null;
                }

            }
                


        }
        public static void SelectShoppinList(Int32 id)
        {
            SqlCommand cmd1 = new SqlCommand();

            cmd1.Connection = new SqlConnection(dbName);

            cmd1.Connection.Open();

            cmd1.CommandType = CommandType.Text;

            cmd1.CommandText = $"SELECT * FROM ORDERS WHERE CUSTOMER_NUMBER={id}";

            SqlDataReader reader = cmd1.ExecuteReader(CommandBehavior.Default);

            int amount = 0;

            while (reader.Read() == true)
            {
                Order o = new Order
                {
                    IdOrder = (Int32)reader["ID_ORDER"],
                    CustomerNumber = (int)reader["CUSTOMER_NUMBER"],
                    ProductNumber = (int)reader["PRODUCT_NUMBER"],
                    Qty = (int)reader["QTY"],
                    TotalPrice = (int)reader["TOTAL_PRICE"]
                };
                Console.WriteLine(o);
                amount = amount + o.TotalPrice;
            }

            Console.WriteLine($"The amount of {id} purchase is:{amount}");

            cmd1.Connection.Close();

        }

        public static void SelectAllProductsC()
        {
            SqlCommand cmd1 = new SqlCommand();

            cmd1.Connection = new SqlConnection(dbName);

            cmd1.Connection.Open();

            cmd1.CommandType = CommandType.Text;

            cmd1.CommandText = $"SELECT * FROM PRODUCTS1";

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
        public static void OrderProduct(Int32 id)
        {
            Console.WriteLine("Which product would you like to order?");

            string name = Console.ReadLine();

            SqlCommand cmd1 = new SqlCommand();

            cmd1.Connection = new SqlConnection(dbName);

            cmd1.Connection.Open();

            cmd1.CommandType = CommandType.Text;

            cmd1.CommandText = $"SELECT * FROM PRODUCTS1 WHERE PRODUCT_NAME='{name}'";

            SqlDataReader reader = cmd1.ExecuteReader(CommandBehavior.Default);

            if (reader.Read() == true)
            {

                Console.WriteLine("How much do you want?");

                int amount = Convert.ToInt32(Console.ReadLine());

                Product p = new Product
                {
                    IdProduct = (Int32)reader["ID_PRODUCT"],
                    ProductName = (string)reader["PRODUCT_NAME"],
                    SupplierNumber = (int)reader["SUPPLIER_NUMBER"],
                    Price = (int)reader["PRICE"],
                    Quantity = (int)reader["QUANTITY"]
                };

                if(amount>p.Quantity)
                {
                    Console.WriteLine("Lacking in stock");

                }
                else
                {
                    SqlCommand cmd2 = new SqlCommand();

                    cmd2.Connection = new SqlConnection(dbName);

                    cmd2.Connection.Open();

                    cmd2.CommandType = CommandType.Text;

                    cmd2.CommandText = $"INSERT INTO ORDERS (CUSTOMER_NUMBER,PRODUCT_NUMBER,QTY,TOTAL_PRICE) VALUES({id},{p.IdProduct},{amount},{p.Price*amount})";

                    cmd2.ExecuteNonQuery();

                    cmd2.Connection.Close();

                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = new SqlConnection(dbName);

                    cmd.Connection.Open();

                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = $"UPDATE PRODUCTS1 SET QUANTITY={p.Quantity - amount} WHERE PRODUCT_NAME='{name}'";

                    cmd.ExecuteNonQuery();

                    cmd.Connection.Close();

                }

            }
            else
            {
                Console.WriteLine($"there is no product {name}");

            }

            cmd1.Connection.Close();

        }

        public static void NewCustomer()
        {
            Console.WriteLine("Welcome to our website, for shopping, you have to answer this questions:");

            Console.WriteLine("Choose a user name:");

            string user = Console.ReadLine();

            Console.WriteLine("Choose a password:");

            string password = Console.ReadLine();

            Console.WriteLine("What is your first name?");

            string name= Console.ReadLine();

            Console.WriteLine("what is your last name?");

            string lastName= Console.ReadLine();

            Console.WriteLine("Please type your credit number:");

            int credit = Convert.ToInt32(Console.ReadLine());

            SqlCommand cmd1 = new SqlCommand();

            cmd1.Connection = new SqlConnection(dbName);

            cmd1.Connection.Open();

            cmd1.CommandType = CommandType.Text;

            cmd1.CommandText = $"INSERT INTO CUSTOMERS (USER_NAME,PASSWORD,FIRST_NAME,LAST_NAME,CREDIT_NUMBER) VALUES('{user}','{password}','{name}','{lastName}',{credit})";

            cmd1.ExecuteNonQuery();

            cmd1.Connection.Close();

        }


    }

 }


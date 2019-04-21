using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PesahProjectConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int x;
            int y;
            do
            {
                Console.WriteLine("please choose 2 numbers:");

                x = Convert.ToInt32(Console.ReadLine());

                y = Convert.ToInt32(Console.ReadLine());

                SqlCommand cmd1 = new SqlCommand();

                cmd1.Connection = new SqlConnection(@"Data Source=LAPTOP-IMU119RQ\MSSQLSERVER02;Initial Catalog=PesahProject;Integrated Security=True");

                cmd1.Connection.Open();

                cmd1.CommandType = CommandType.Text;

                cmd1.CommandText = $"INSERT INTO XTable VALUES({x})";

                cmd1.CommandText = $"INSERT INTO YTable VALUES({y})";

            }
            while (x > 0 && y > 0);

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = new SqlConnection(@"Data Source=LAPTOP-IMU119RQ\MSSQLSERVER02;Initial Catalog=PesahProject;Integrated Security=True");
            
            cmd.Connection.Open();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = $"INSERT INTO ResultTable(x,operation,y) SELECT * FROM XTable cross join OperationTable1 cross join YTable";

            cmd.CommandText = "SELECT * FROM ResultTable";

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            
            while (reader.Read() == true)

            {
                switch (reader["Operation"])
                {
                    case "-":
                        cmd.CommandText = "update ResultTable set Result= x -y";
                        break;
                    case "+":
                        cmd.CommandText = "update ResultTable set Result= x +y";
                        break;
                    case "*":
                        cmd.CommandText = "update ResultTable set Result= x *y";
                        break;
                    case "/":
                        cmd.CommandText = "update ResultTable set Result= x /y";
                        break;
                }
                      
            }

            cmd.Connection.Close();

        }

    }

}  




        
    


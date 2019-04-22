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

                if (x > 0 && y > 0)
                {
                    SqlCommand cmd1 = new SqlCommand();

                    cmd1.Connection = new SqlConnection(@"Data Source=LAPTOP-IMU119RQ\MSSQLSERVER02;Initial Catalog=PesahProject;Integrated Security=True");

                    cmd1.Connection.Open();

                    cmd1.CommandType = CommandType.Text;

                    cmd1.CommandText = $"INSERT INTO XTable VALUES({x})";

                    cmd1.ExecuteNonQuery();

                    cmd1.Connection.Close();

                    SqlCommand cmd2 = new SqlCommand();

                    cmd2.Connection = new SqlConnection(@"Data Source=LAPTOP-IMU119RQ\MSSQLSERVER02;Initial Catalog=PesahProject;Integrated Security=True");

                    cmd2.Connection.Open();

                    cmd2.CommandType = CommandType.Text;

                    cmd2.CommandText = $"INSERT INTO YTable VALUES({y})";

                    cmd2.ExecuteNonQuery();

                    cmd2.Connection.Close();
                }

            }
            while (x > 0 && y > 0);

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = new SqlConnection(@"Data Source=LAPTOP-IMU119RQ\MSSQLSERVER02;Initial Catalog=PesahProject;Integrated Security=True");
            
            cmd.Connection.Open();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "INSERT INTO ResultTable(x,operation,y) SELECT * FROM XTable cross join OperationTable1 cross join YTable";

            cmd.ExecuteNonQuery();

            cmd.Connection.Close();

            SqlCommand cmd3 = new SqlCommand();

            cmd3.Connection = new SqlConnection(@"Data Source=LAPTOP-IMU119RQ\MSSQLSERVER02;Initial Catalog=PesahProject;Integrated Security=True");

            cmd3.Connection.Open();

            cmd3.CommandType = CommandType.Text;

            cmd3.CommandText = "SELECT * FROM ResultTable";

            SqlDataReader reader = cmd3.ExecuteReader(CommandBehavior.Default);
            
            while (reader.Read() == true)

            {
                SqlCommand cmd4 = new SqlCommand();

                cmd4.Connection = new SqlConnection(@"Data Source=LAPTOP-IMU119RQ\MSSQLSERVER02;Initial Catalog=PesahProject;Integrated Security=True");

                cmd4.Connection.Open();

                cmd4.CommandType = CommandType.Text;

                cmd4.CommandText = $"update ResultTable set Result=x+y where Operation='+'";

                cmd4.ExecuteNonQuery();

                cmd4.Connection.Close();

                SqlCommand cmd5 = new SqlCommand();

                cmd5.Connection = new SqlConnection(@"Data Source=LAPTOP-IMU119RQ\MSSQLSERVER02;Initial Catalog=PesahProject;Integrated Security=True");

                cmd5.Connection.Open();

                cmd5.CommandType = CommandType.Text;

                cmd5.CommandText = $"update ResultTable set Result=x-y where Operation='-'";

                cmd5.ExecuteNonQuery();

                cmd5.Connection.Close();

                SqlCommand cmd6 = new SqlCommand();

                cmd6.Connection = new SqlConnection(@"Data Source=LAPTOP-IMU119RQ\MSSQLSERVER02;Initial Catalog=PesahProject;Integrated Security=True");

                cmd6.Connection.Open();

                cmd6.CommandType = CommandType.Text;

                cmd6.CommandText = $"update ResultTable set Result=x*y where Operation='*'";

                cmd6.ExecuteNonQuery();

                cmd6.Connection.Close();

                SqlCommand cmd7 = new SqlCommand();

                cmd7.Connection = new SqlConnection(@"Data Source=LAPTOP-IMU119RQ\MSSQLSERVER02;Initial Catalog=PesahProject;Integrated Security=True");

                cmd7.Connection.Open();

                cmd7.CommandType = CommandType.Text;

                cmd7.CommandText = $"update ResultTable set Result=x/y where Operation='/'";

                cmd7.ExecuteNonQuery();

                cmd7.Connection.Close();



            }


            cmd3.Connection.Close();
            

        }

    }

}  




        
    


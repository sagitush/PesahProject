using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PesahProjectConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlGlobalDBConnection"].ConnectionString)) 
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
                        SqlCommand cmd1 = new SqlCommand($"INSERT INTO XTable VALUES({x})", conn);

                        cmd1.Connection.Open();

                        cmd1.CommandType = CommandType.Text;

                        cmd1.ExecuteNonQuery();

                        cmd1.Connection.Close();

                        SqlCommand cmd2 = new SqlCommand($"INSERT INTO YTable VALUES({y})",conn);

                        cmd2.Connection.Open();

                        cmd2.CommandType = CommandType.Text;

                        cmd2.ExecuteNonQuery();

                        cmd2.Connection.Close();
                    }

                }
                while (x > 0 && y > 0);

                SqlCommand cmd = new SqlCommand("INSERT INTO ResultTable(x,operation,y) SELECT * FROM XTable cross join OperationTable1 cross join YTable",conn);

                cmd.Connection.Open();

                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();

                cmd.Connection.Close();

                SqlCommand cmd4 = new SqlCommand("update ResultTable set Result=x+y where Operation='+'",conn);

                cmd4.Connection.Open();

                cmd4.CommandType = CommandType.Text;

                cmd4.ExecuteNonQuery();

                cmd4.Connection.Close();

                SqlCommand cmd5 = new SqlCommand("update ResultTable set Result=x-y where Operation='-'",conn);

                cmd5.Connection.Open();

                cmd5.CommandType = CommandType.Text;

                cmd5.ExecuteNonQuery();

                cmd5.Connection.Close();

                SqlCommand cmd6 = new SqlCommand("update ResultTable set Result=x*y where Operation='*'",conn);

                cmd6.Connection.Open();

                cmd6.CommandType = CommandType.Text;

                cmd6.ExecuteNonQuery();

                cmd6.Connection.Close();

                SqlCommand cmd7 = new SqlCommand("update ResultTable set Result=x/y where Operation='/'",conn);

                cmd7.Connection.Open();

                cmd7.CommandType = CommandType.Text;

                cmd7.ExecuteNonQuery();

                cmd7.Connection.Close();

            }
        }

    }

}  




        
    


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace BlackRain.Helpers
{
    class SQLHelper
    {
        private string url = "50.115.175.42";

        private SqlConnection connect() 
        {
            SqlConnection con = new SqlConnection("user id=void;" +
                                       "password=l3tm31n;server=" + url +";" +
                                       "Trusted_Connection=yes;" +
                                       "database=void; " +
                                       "connection timeout=30");

            try
            {
                con.Open();
                Console.WriteLine("ServerVersion: " + con.ServerVersion + "\nState: " + con.State.ToString());
                return con;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        private SqlDataReader getInfo(String command, SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand(command, con);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        private void setInfo(String command, SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand(command, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void disconnect(SqlConnection con)
        {
            con.Close();
        }
    }
}

using System;
using System.Xml.Schema;
using MySql.Data.MySqlClient;


namespace insertDB
{
    class Program
    {

        MySqlConnection con;

        static void Main(string[] args)
        {
            string connectionstring = null;

            connectionstring =
                @"Server = 127.0.0.1;" +
                @"Userid = Arnold;" +
                @"Pwd = 1234;" +
                @"Database = highscore;";




            MySqlConnection con = null;
            //MySqlDataReader Object
            MySqlDataReader reader = null;
            try

            {
                con = new MySqlConnection(connectionstring);
                con.Open(); //open the connection
//Insert query
//via this command
                String cmdText = "INSERT INTO HIGHSCORE (nickName, score) VALUES('Sander', '105000')";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);

                reader = cmd.ExecuteReader(); //execure the reader
/*The Read() method points to the next record It return false if there are no more records else returns true.*/
                while (reader.Read())
                {
/*reader.GetString(0) will get the value of the first column of the table myTable because we selected all columns using SELECT * (all); the first loop of the while loop is the first row; the next loop will be the second row and so on...*/
                    Console.WriteLine(@"Name: { 0} Score: { 1}", reader.GetString(0), reader.GetString(1));
                };
                
            }
            catch (

                MySqlException err)
            {
                Console.WriteLine
                ("Error: " +
                 err.ToString
                     ());
            }
            finally
            {
                if (
                    reader != null)
                {
                    reader.Close
                        ();
                }
                if (
                    con != null)
                {
                    con.Close
                        (); //close the connection
                }
            }
        }
    }
}

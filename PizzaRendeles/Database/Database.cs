using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace PizzaRendeles.Database
{
    public static class Database
    {
        public static MySqlConnection CreateConnection()
        {
            string ConnectionString = "Server=127.0.0.1;Port=3306;Database=pizzagirl;Uid=root;";
            MySqlConnection connection = new MySqlConnection(ConnectionString);

            try
            {
                connection.Open();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return connection;
        }

        public static void LoginAdmin(string username, string password, out int id)
        {
            id = -1;

            try
            {
                MySqlConnection connection = CreateConnection();

                string query = $"SELECT * FROM administrators WHERE Username = @UserName AND Password = @UserPassword";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@UserPassword", password);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    if (reader.HasRows)
                    {
                        id = Convert.ToInt32(reader["ID"]);
                        break;
                    }
                }

                reader.Close();
                connection.Close();
            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }

        public static void DisplayAndSearch(string query, DataGrid dg)
        {
            try
            {
                MySqlConnection connection = CreateConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "LoadDataBinding");
                dg.DataContext = ds;
                connection.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }
    }
}

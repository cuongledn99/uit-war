using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace uit_war
{
    public class SQLConnection
    {
        SqlConnection connection;
        bool isOpenedConnection;
        public SQLConnection(string databasePath)
        {
            //ket noi csdl bang Sqlconnection
            connection = new SqlConnection(databasePath);
            try
            {
                //Mo ket noi
                connection.Open();
                isOpenedConnection = true;
            }
            catch
            {
                isOpenedConnection = false;
            }
        }
        public static string GetDatabasePath(string servername, string databasename, string username, string password)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //builder.DataSource = "192.168.137.1,6969";
            //builder.InitialCatalog = "doan";
            //builder.UserID = "admin";
            //builder.Password = "cuong123";
            builder.DataSource = servername;
            builder.InitialCatalog = databasename;
            builder.UserID = username;
            builder.Password = password;
            return builder.ToString();
        }
        public SqlDataReader Query(string query)
        {
            //try to open connection if not opened yet
            if (!isOpenedConnection)
                try
                {
                    //Mo ket noi
                    connection.Open();
                    isOpenedConnection = true;
                }
                catch
                {
                    isOpenedConnection = false;
                }

            //query
            try
            {
                //Tao mot Sqlcommand de thuc hien cau lenh truy van da chuan bi voi ket noi hien tai
                SqlCommand command = new SqlCommand(query, connection);
                //Thuc hien cau truy van va nhan ve mot doi tuong reader ho tro do du lieu
                return command.ExecuteReader();

            }
            catch { }

            return null;
        }
        public void AddRemoveAlter(string sqlCommand)
        {
            //try to open connection if not opened yet
            if (!isOpenedConnection)
                try
                {
                    //Mo ket noi
                    connection.Open();
                    isOpenedConnection = true;
                }
                catch
                {
                    isOpenedConnection = false;
                }

            //start command
            try
            {
                //Tao mot Sqlcommand de thuc hien cau lenh truy van da chuan bi voi ket noi hien tai
                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.ExecuteNonQuery();
            }
            catch
            {

            }
        }
        public void Close()
        {
            connection.Close();
        }
    }
}


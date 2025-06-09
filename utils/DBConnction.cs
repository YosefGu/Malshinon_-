using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Malshinon_.utils
{
    internal class DBConnection
    {
        private static DBConnection _instance;

        private static readonly object _lock = new object();

        private MySqlConnection _connection;
        private DBConnection()
        {
            string connStr = "server=127.0.0.1;uid=root;password=;database=Malshinon";

            _connection = new MySqlConnection(connStr);
            _connection.Open();
        }
        public static DBConnection GetInstance(string cs = null)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DBConnection();
                    }
                }
            }

            return _instance;
        }

        public MySqlConnection GetConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();

            return _connection;
        }
    }
}

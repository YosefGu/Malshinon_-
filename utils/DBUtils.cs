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
    internal class DBUtils
    {
        //המרת מחורזת לפקודת SQL
        private static MySqlCommand Command(string sql, MySqlConnection conn)
        {
            return new MySqlCommand 
            { 
                CommandText = sql,
                Connection = conn
            };
        }

        //שליחת בקשת לשרת SELECT
        private static MySqlDataReader SendReader(MySqlCommand cmd)
        {
            return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }


        //שליחת בקשת לשרת INSERT, UPDATE, DELETE
        private static int SendNonQuery(MySqlCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }

        //המרת התשובה מהשרת למילון קריא
        private static List<Dictionary<string, object>> Parse(MySqlDataReader rdr)
        {
            var rows = new List<Dictionary<string, object>>();
            using (rdr)
            {
                while (rdr.Read())
                {
                    var row = new Dictionary<string, object>(rdr.FieldCount);
                    for (int i = 0; i < rdr.FieldCount; i++)
                        row[rdr.GetName(i)] = rdr.IsDBNull(i) ? null : rdr.GetValue(i);

                    rows.Add(row);
                }
            }
            return rows;
        }

        //ביצוע הקריאה לשרת והחזרת הנתונים תוך שימוש במתודות לעיל
        public static List<Dictionary<string, object>> Execute(string sql)
        {

            var conn = DBConnection.GetInstance().GetConnection();
            var cmd = Command(sql, conn);

            string lowered = sql.Trim().ToLower();

            if (lowered.StartsWith("select"))
            {
                var red = SendReader(cmd);
                return Parse(red);
            }
            else
            {
                int affectedRows = SendNonQuery(cmd);

                return new List<Dictionary<string, object>>
                {
                    new Dictionary<string, object>
                    {
                        { "status", "ok" },
                        {"rows_affected", affectedRows}
                    }
                };
            }
        }

        //הדפסת השורות
        public static void PrintResult(List<Dictionary<string, object>> keyValuePairs)
        {
            if (keyValuePairs.Count == 0)
            {
                Console.WriteLine("No results found.");
                return;
            }

            foreach (var row in keyValuePairs)
            {
                foreach (var kv in row)
                    Console.WriteLine($"{kv.Key}: {kv.Value}");
                Console.WriteLine("---");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon_.DAL
{
    internal class UsersDAL
    {
        public static string CreateUser(string full_name, int secret_code)
        {
            return  $"INSERT INTO users (full_name, secret_code) VALUES ('{full_name}', '{secret_code}');";
        }

        public static string GetUserByFullname(string full_name)
        {
            return $"SELECT * FROM users where users.full_name = '{full_name}';";
        }

        public static string GetUserBySecretCode(int secret_code)
        {
            return $"SELECT * FROM users where users.secret_code = '{secret_code}';";
        }

        public static string UpdateUserName(string full_name, int secret_code)
        {
            return $"UPDATE users set full_name = '{full_name}' WHERE users.secret_code = '{secret_code}';";
        }


        


    }
}

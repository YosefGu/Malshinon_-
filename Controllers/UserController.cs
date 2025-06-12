using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon_.DAL;
using Malshinon_.utils;

namespace Malshinon_.Controllers
{
    internal class UserController
    {

        public static List<Dictionary<string, object>> CreateUser(string full_name)
        {
            try {
                int secret_code = GenerateSecretCode();
                List<Dictionary<string, object>> response = DBUtils.Execute(UsersDAL.CreateUser(full_name, secret_code));
                return response;

            } catch (Exception e) {
                Console.WriteLine($"Create user error: {e}");
                return new List<Dictionary<string, object>>();
            }
        }

        public static List<Dictionary<string, object>> GetUserByCode(int code)
        {
            List<Dictionary<string, object>> response = DBUtils.Execute(UsersDAL.GetUserBySecretCode(code));
            return response;
        }

        public static List<Dictionary<string, object>> GetUserByName(string full_name)
        {
            List<Dictionary<string, object>> response = DBUtils.Execute(UsersDAL.GetUserByFullname(full_name));
            return response;
        }

        private static int GenerateSecretCode()
        {
            Random rand = new Random();
            int secret_code = rand.Next(10000, 100000);
            return secret_code;
        }
    }
}

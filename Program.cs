using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon_.App;
using Malshinon_.DAL;
using Malshinon_.utils;
using MySql.Data.MySqlClient;

namespace Malshinon_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainApp.StartApp();
            //var add = DBUtils.Execute(UsersDAL.CreateUser("David T", GenerateSecretCode()));
            //var user = DBUtils.Execute(UsersDAL.GetUserBySecretCode(13702));
            //var data = DBUtils.Execute("SELECT * FROM users");

            //DBUtils.PrintResult(user);
            //Console.WriteLine(data);
            //DBUtils.PrintResult(add);
            //DBUtils.PrintResult(data);
        }

        //move to controllers
        
    }
}

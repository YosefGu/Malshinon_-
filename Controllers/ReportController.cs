using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon_.DAL;
using Malshinon_.utils;

namespace Malshinon_.Controllers
{
    internal class ReportController
    {
        public static bool AddReport(string reporter, string target, string message)
        {
            try
            {
                List<Dictionary<string, object>> dictReporter = GetDictUser(reporter);
                if (!dictReporter.Any())
                {
                    if (IsCode(reporter))
                        throw new Exception(@"Reporter code is not registered in the system.");
                    UserController.CreateUser(reporter);
                    dictReporter = UserController.GetUserByName(reporter);
                }

                List<Dictionary<string, object>> dictTarget = GetDictUser(target);
                if (!dictTarget.Any())
                {
                    if (IsCode(target))
                        throw new Exception(@"Target code is not registered in the system.");
                    UserController.CreateUser(target);
                    dictTarget = UserController.GetUserByName(target);
                }
                
                int reporterCode = int.Parse(dictReporter[0]["secret_code"].ToString());
                int targetCode = int.Parse(dictTarget[0]["secret_code"].ToString());

                return SendReport(reporterCode, targetCode, message);
            } catch (Exception e) 
            {
                Console.WriteLine($"Error adding report: {e}");
                return false;
            }
        }

        private static bool IsCode(string nameOrCode)
        {
            int intCode;
            if (int.TryParse(nameOrCode, out intCode))
                return true;
            return false;
        }

        private static List<Dictionary<string, object>> GetDictUser(string nameOrCode)
        {
            if (IsCode(nameOrCode))
            {
                return UserController.GetUserByCode(int.Parse(nameOrCode));      
            }
            else
            {
                return UserController.GetUserByName(nameOrCode);
            }
        }

        private static bool SendReport(int reporterCode, int targetCode, string message)
        {
            List<Dictionary<string, object>> response = DBUtils.Execute(Reports.CreateNewReport(reporterCode, targetCode, message));
            StatisticController.UpdateStatistic(reporterCode, targetCode, message);
            AlertController.CheckForAlert(targetCode);
            return true;
        }

    }
}

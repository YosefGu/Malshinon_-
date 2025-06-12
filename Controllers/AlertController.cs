using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon_.DAL;
using Malshinon_.utils;

namespace Malshinon_.Controllers
{
    internal class AlertController
    {
        public static void ShowAllAlerts()
        {
            List<Dictionary<string, object>> alertsDict = DBUtils.Execute(Alerts.GetAllAlerts());

            if (alertsDict.Any())
            {
                Console.WriteLine("Alerts: ");
                DBUtils.PrintResult(alertsDict);
            }
            else 
            {
                Console.WriteLine("Alerts not found.");
            }
        }

        public static void CheckForAlert(int targetCode)
        {
            string description = "";
            List<Dictionary<string, object>> targetDict = DBUtils.Execute(Statistic.GetUserBySecretCode(targetCode));
            List<Dictionary<string, object>> userDict = DBUtils.Execute(UsersDAL.GetUserBySecretCode(targetCode));

            //DBUtils.PrintResult(targetDict);
            //DBUtils.PrintResult(userDict);
            //return;

            int resiveReport = Convert.ToInt32(targetDict[0]["receivd_reports"]);
            string fullName = userDict[0]["full_name"].ToString();

            if (resiveReport > 20)
            {
                description = $@"The target with name: {fullName}
                    and secret code: {targetCode} 
                    resive {resiveReport} reports.";
            }

            List<Dictionary<string, object>> last15Dict = DBUtils.Execute(Reports.TargetLast15Minut(targetCode));
            int mentioned = Convert.ToInt32(last15Dict[0]["count"]);

            if (mentioned > 3) 
            {
                description = description + $"\nAnd mentioned {mentioned} times.";
            }

            if (description.Length > 0) 
            {
                DBUtils.Execute(Alerts.CreateAlert(targetCode, description));
                Console.WriteLine(description);
            }
        }
    };

}

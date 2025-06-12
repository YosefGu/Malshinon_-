using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon_.DAL;
using Malshinon_.utils;

namespace Malshinon_.Controllers
{
    internal class StatisticController
    {

        public static void UpdateStatistic(int reporterCode, int targetCode, string message) 
        {
            List<Dictionary<string, object>> reporterDict = DBUtils.Execute(Statistic.GetUserBySecretCode(reporterCode));
            if (!reporterDict.Any())
            {
                DBUtils.Execute(Statistic.CreatePerson(reporterCode));
            }
            DBUtils.Execute(Statistic.UpdateReporter(reporterCode, message.Count()));

            List<Dictionary<string, object>> targetDict = DBUtils.Execute(Statistic.GetUserBySecretCode(targetCode));
            if (!targetDict.Any())
            {
                DBUtils.Execute(Statistic.CreatePerson(targetCode));
            }
            DBUtils.Execute(Statistic.UpdateTargetPerson(targetCode));
        }

        public static void ShowPotentialCandidates()
        {
            List<Dictionary<string, object>> CandidateesDict = DBUtils.Execute(Statistic.GetIntendedsForRecruitment());
            if (!CandidateesDict.Any()) 
            {
                Console.WriteLine("No potential candidates were found for recruitment.");
            } else
            {
                Console.WriteLine("Potential candidates for recruitment: ");
                DBUtils.PrintResult(CandidateesDict);
            }
        }

        public static void ShowPotentialDangerous()
        {
            List<Dictionary<string, object>> DangerousDict = DBUtils.Execute(Statistic.GetIntendedsForRecruitment());
            if (!DangerousDict.Any())
            {
                Console.WriteLine("No potential hazards found.");
            }
            else
            {
                Console.WriteLine("Potential dangers: ");
                DBUtils.PrintResult(DangerousDict);
            }
        }


    }
}

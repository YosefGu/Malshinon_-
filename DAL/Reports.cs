using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon_.DAL
{
    internal class Reports
    {
        public static string CreateNewReport(int reporter, int target, string message)
        {
            return $"INSERT INTO reports (reporter, target, message) VALUES ({reporter}, {target}, '{message}');";
        }

        public static string TargetLast15Minut()
        {
            return $"SELECT target, COUNT(*) FROM reports WHERE time_report >= NOW() - INTERVAL 15 MINUT;";
        }
    }
}

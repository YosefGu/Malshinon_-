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

        public static string TargetLast15Minut(int targetCode)
        {
            return $"SELECT target, COUNT(*) as count FROM reports WHERE target = {targetCode} AND time_report >= NOW() - INTERVAL 15 MINUTE;";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon_.DAL
{
    internal class Alerts
    {
        public static string CreateAlert(int targetCode, string description)
        {
            return $"INSERT INTO alerts (target, message) VALUES ({targetCode}, {description}); ";
        }

        public static string GetAllAlerts()
        {
            return "SELECT * FROM alerts";
        }
    }
}

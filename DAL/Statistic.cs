using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon_.DAL
{
    internal class Statistic
    {
        public static string CreatePerson(int secret_code)
        {
            return $@"
                INSERT INTO statistics 
                (secret_code, submitted_reports, receivd_reports, count_message_char) 
                VALUES ({secret_code}, 0, 0, 0);";
        }

        public static string UpdateTargetPerson(int secret_code)
        {
            return $@"
                UPDATE statistics 
                set 
                receivd_reports = receivd_reports + 1 
                WHERE secret_code = {secret_code};";
        }

        public static string UpdateReporter(int secret_code, int message_char)
        {
            return $@"
                UPDATE statistics 
                set 
                submitted_reports = submitted_reports + 1, 
                count_message_char = count_message_char + '{message_char}'  
                WHERE secret_code = {secret_code};";
        }

        public static string GetUserBySecretCode(int secret_code)
        {
            return $@"
                SELECT * 
                FROM statistics 
                WHERE secret_code = {secret_code};";
        }

        public static string GetDangerousTarget()
        {
            return @"
                SELECT * 
                FROM statistics 
                WHERE receivd_reports >= 20";
        }

        public static string GetIntendedsForRecruitment()
        {
            return @"
                SELECT * 
                FROM statistics 
                WHERE submitted_reports >= 10 
                AND 
                count_message_char / submitted_reports >= 100";
        }




    }
}

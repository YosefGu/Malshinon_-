using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon_.App.Menu;
using Malshinon_.Controllers;

namespace Malshinon_.App
{
    internal class MainApp
    {
        public static void StartApp()
        {
            bool exit = false;
            while (!exit)
            {
                PrintMenu();
                string select = Console.ReadLine();
                if (IsValidSelect(select))
                {
                    int intSelect = int.Parse(select);
                    switch (intSelect)
                    {
                        case 1:
                            Report.AddReport();
                            break;
                        case 2:
                            StatisticController.ShowPotentialCandidates();
                            break;
                        case 3:
                            StatisticController.ShowPotentialDangerous();
                            break;
                        case 4:
                            AlertController.ShowAllAlerts();
                            break;
                        case 5:
                            exit = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect choice, please choose a number between 1-5");
                }
            }
            Console.WriteLine("Goodby :)");

        }

        private static void PrintMenu()
        {
            Console.WriteLine("1. Enter report");
            Console.WriteLine("2. Potential candidates for recruitment");
            Console.WriteLine("3. Potential dangerous targets");
            Console.WriteLine("4. Notifications");
            Console.WriteLine("5. Exit");
        }

        private static bool IsValidSelect(string select)
        {
            int intSelect;
            if (int.TryParse(select, out intSelect))
            {
                if (intSelect > 0 && intSelect <= 5)
                    return true;
            }
            return false;

        }



    }
}

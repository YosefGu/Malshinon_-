using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon_.App.Menu
{
    internal class Report
    {
        public static bool AddReport()
        {
            bool exit = false;
            Console.WriteLine("In order for us to begin...");
            while (!exit) 
            {
                string ReporterNameOrCode = GetNameOrCode();
                if (IsValidNameOrCode(ReporterNameOrCode))
                {
                    string TargetNameOrCode = GetNameOrCode();
                    if (IsValidNameOrCode(TargetNameOrCode))
                    {
                        string message = GetMessage();
                        if (IsValidMessage(message))
                        {
                            Console.WriteLine("Your message has been received successfully."); 
                        }

                    }

                }
                exit = AskForExit();   
            }
            return exit;
        }

        private static string GetNameOrCode()
        {
            Console.Write("Please enter full name or secret code: ");
            return Console.ReadLine();
        }

        private static bool IsValidNameOrCode(string nameOrCode)
        {
            int code;
            if (int.TryParse(nameOrCode, out code))
            {
                if (code >= 10000 && code <= 100000)
                    return true;
                else
                {
                    Console.WriteLine(@"
                    The code you entered is incorrect,
                    it should be between 10,000 -100,000.");
                    return false;

                }                    
            }
            if (nameOrCode.Length > 50)
            {
                Console.WriteLine("The name you entered is too long.");
                return false;
            }
            return true;
        }

        private static string GetMessage()
        {
            Console.WriteLine("Please enter your message: ");
            return Console.ReadLine();
        }

        private static bool IsValidMessage(string message)
        { 
            if (message.Length > 500)
            {
                Console.WriteLine(@"
                    Please shorten your message. 
                    Maximum allowed is 500 characters.");
                return false;
            }
            if (string.IsNullOrEmpty(message)) 
                return false;
            return true;
        }

        private static bool AskForExit()
        {
            bool goodAnswer = false;
            bool exit = false;
            while (!goodAnswer)
            {
                Console.WriteLine("Do you want to cancel sending a message? (Yes,No)");
                string response = Console.ReadLine();

                if (response == "Yes")
                {
                    goodAnswer = true;
                    exit = true;
                }
                else if (response == "No")
                {
                    goodAnswer = true;
                }
                Console.WriteLine("Incorrect answer.");

            }
            return exit;



        }

    }
}

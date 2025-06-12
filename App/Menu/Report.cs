using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon_.Controllers;

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
                try 
                {
                    string error; 
                    string reporterNameOrCode = GetNameOrCode();
                    if (!IsValidNameOrCode(reporterNameOrCode, out error))
                        throw new Exception(error);
                    
                    Console.WriteLine("now for the target");
                    string targetNameOrCode = GetNameOrCode();
                    if (!IsValidNameOrCode(targetNameOrCode, out error))
                        throw new Exception(error);

                    string message = GetMessage();
                    if (!IsValidMessage(message, out error))
                        throw new Exception(error);

                    bool response = ReportController.AddReport(reporterNameOrCode, targetNameOrCode, message);
                    if (response)
                    {
                        Console.WriteLine("Your message has been received successfully.");
                    }
                    else
                    {
                        Console.WriteLine("There was an issue submitting your report.");
                    }

                } catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
                
                exit = AskForExit();   
            }
            return false;
        }

        private static string GetNameOrCode()
        {
            Console.Write("Please enter full name or secret code: ");
            return Console.ReadLine();
        }

        private static bool IsValidNameOrCode(string nameOrCode, out string errorMessage)
        {
            errorMessage = "";
            int code;
            if (int.TryParse(nameOrCode, out code))
            {
                if (code >= 10000 && code <= 100000)
                    return true;
                else
                {
                    errorMessage = "The code name you entered is not recognized in system.";
                    return false;
                }                    
            }
            if (nameOrCode.Length > 50)
            {
                errorMessage = "The name you entered is too long.";
                return false;
            }
            return true;
        }

        private static string GetMessage()
        {
            Console.WriteLine("Please enter your message: ");
            return Console.ReadLine();
        }

        private static bool IsValidMessage(string message, out string errorMessage)
        {
            errorMessage = "";
            if (message.Length > 500)
            {
                errorMessage = "Please shorten your message. \nMaximum allowed is 500 characters.";
                return false;
            }
            if (string.IsNullOrEmpty(message))
            {
                errorMessage = "The message is empty.";
                return false;
            }  
            return true;
        }

        private static bool AskForExit()
        {
            bool goodAnswer = false;
            bool exit = false;
            while (!goodAnswer)
            {
                Console.WriteLine("Do you want to continue sending a messages? (Yes,No)");
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
                else
                {
                    Console.WriteLine("Incorrect answer.");
                }
            }
            return exit;
        }
    }
}

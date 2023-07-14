using System.Configuration;
using System.Globalization;

namespace cSharpAcademy_Coding_Tracker
{
    internal static class Validation
    {
        internal static string Integer(string userInput)
        {
            while (string.IsNullOrEmpty(userInput) || !Int32.TryParse(userInput, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try again");
                userInput = Console.ReadLine();
            }
            return userInput;
        }

        internal static DateTime GetValidDateFromUserInput(string userInput)
        {
            DateTime date;
            while (!DateTime.TryParseExact(userInput, ConfigurationManager.AppSettings.Get("dateFormat"), CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                Console.WriteLine("This is not a valid date. Please try again.");
                userInput = Console.ReadLine();
            }
            return date;
        }
    }
}

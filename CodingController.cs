using ConsoleTableExt;
using cSharpAcademy_Coding_Tracker.Model;
using cSharpAcademy_Coding_Tracker1;
using Microsoft.Data.Sqlite;
using System.Configuration;

namespace cSharpAcademy_Coding_Tracker
{
    internal static class CodingController
    {
        internal static void Insert()
        {
            Console.WriteLine($"Please insert start date. Date format: {ConfigurationManager.AppSettings.Get("dateFormat")}");
            DateTime startDate = Validation.GetValidDateFromUserInput(Console.ReadLine());
            Console.WriteLine($"Please insert end date. Date format: {ConfigurationManager.AppSettings.Get("dateFormat")}");
            DateTime endDate = Validation.GetValidDateFromUserInput(Console.ReadLine());
            string duration = Helpers.CalculateDuration(startDate, endDate);

            using (var connection = new SqliteConnection(ConfigurationManager.AppSettings.Get("dbConnectionString")))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = $"INSERT INTO coding_tracker(StartDate, EndDate, Duration) VALUES('{startDate}', '{endDate}', '{duration}')";

                tableCmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        internal static void ReadAll()
        {
            Console.WriteLine("All records:");
            using (var connection = new SqliteConnection(ConfigurationManager.AppSettings.Get("dbConnectionString")))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = "SELECT * FROM coding_tracker";

                using (var reader = tableCmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        List<Coding> codingList = new List<Coding>();

                        while (reader.Read())
                        {
                            codingList.Add(new Coding
                            {
                                Id = reader.GetInt32(0),
                                StartDate = reader.GetString(1),
                                EndDate = reader.GetString(2),
                                Duration = Helpers.DisplayTime(Convert.ToInt32(reader.GetString(3)))
                            });
                        }

                        ConsoleTableBuilder
                                 .From(codingList)
                                 .ExportAndWriteLine();
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                }
                connection.Close();
            }
        }
    }
}

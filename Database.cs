using Microsoft.Data.Sqlite;
using System.Configuration;

namespace cSharpAcademy_Coding_Tracker
{
    internal static class Database
    {
        internal static void CheckIfDbTableExist()
        {
            using (var connection = new SqliteConnection(@"Data Source=coding_tracker.db"))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS coding_tracker (
                        Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                        StartDate TEXT NOT NULL,
                        EndDate TEXT NOT NULL,
                        Duration TEXT NOT NULL           
                    )";

                tableCmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

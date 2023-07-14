using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpAcademy_Coding_Tracker1
{
    internal static class Helpers
    {
        internal static string CalculateDuration(DateTime startDate, DateTime endDate)
        {
            TimeSpan duration = endDate - startDate;
            return duration.TotalMilliseconds.ToString();
        }

        internal static string DisplayTime(int milliseconds)
        {
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(milliseconds);
            string time = $"Hours: {timeSpan.Hours}, Minutes: {timeSpan.Minutes}, Seconds: {timeSpan.Seconds}";
            return time;
        }
    }
}

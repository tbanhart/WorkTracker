using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WorkTracker2.Utilities
{
    static class Constants
    {
        public static string seperator = "\\";
        public static string jsonPath = Directory.GetCurrentDirectory() + seperator + "Data" + seperator;
        public static List<string> letterValues = new List<string> { "date", "encorr", "user", "client", "tracking", "status", "type", "DCName" };
        public static string documentString = $"C:\\Users\\{Environment.UserName}\\Documents\\WorkTracker\\";
        public static string defaultExcelPath = documentString;
    }
}

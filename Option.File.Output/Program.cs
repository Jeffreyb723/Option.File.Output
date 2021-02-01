using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Option.File.Output
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string user = Environment.UserName;
            string splm = @"splm11";
            const string version = @"16\.0";
            
            string licenseFileLocation = $@"C:\temp\{splm}.lic";
            const string optionFileLocation = @"C:\temp\ugslmd.opt";

            string licenseFile = System.IO.File.ReadAllText(licenseFileLocation);
            StringBuilder stringBuilder = new StringBuilder($"GROUPCASEINSENSITIVE ON \n\nUSER {user}\n\n");

            foreach (Match match in Regex.Matches(licenseFile, @"(?<=PACKAGE )(.*)(?= ugslmd " + version + ")"))
            {
                _ = stringBuilder.Append($"INCLUDE {match.Value} USER {user} \n\n");
            }

            System.IO.File.WriteAllText(optionFileLocation, stringBuilder.ToString());
        }
    }
}

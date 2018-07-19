using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailUITestFramework.Browser
{
    public class Configuration
    {
        public static string GetEnvironmentalVar(string var, string defaultValue)
        {
            return ConfigurationManager.AppSettings[var] ?? defaultValue;
        }

        public static string ElementTimeout => GetEnvironmentalVar("ElementTimeout", "30");
        public static string Browser => GetEnvironmentalVar("Browser", "Chrome");
        public static string StartUrl => GetEnvironmentalVar("StartUrl", "https://mail.google.com");
    }
}

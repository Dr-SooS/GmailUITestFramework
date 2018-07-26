using System.Configuration;

namespace CoreFramework.Browser
{
    public class Configuration
    {
        public static string GetEnvironmentalVar(string var, string defaultValue)
        {
            return ConfigurationManager.AppSettings[var] ?? defaultValue;
        }

        public static string ElementTimeout => GetEnvironmentalVar("ElementTimeout", "30");
        public static string Browser => GetEnvironmentalVar("Browser", "FireFox");
        public static string StartUrl => GetEnvironmentalVar("StartUrl", "https://mail.google.com");
    }
}

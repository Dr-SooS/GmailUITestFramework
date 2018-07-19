using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace GmailUITestFramework.Browser
{
    public class Browser
    {
        private static Browser _currentInstance;
        private static IWebDriver _driver;
        public static BrowserFactory.BrowserType CurreBrowser;
        public static int ImplWait;
        public static double TimeoutForElement;
        private static string _browser;

        private Browser()
        {
            InitParams();
            _driver = BrowserFactory.GetDriver(CurreBrowser, ImplWait);
        }

        private static void InitParams()
        {
            ImplWait = Convert.ToInt32(Configuration.ElementTimeout);
            TimeoutForElement = Convert.ToDouble(Configuration.ElementTimeout);
            _browser = Configuration.Browser;
            Enum.TryParse(_browser, out CurreBrowser);
        }

        public static Browser Instance => _currentInstance ?? (_currentInstance = new Browser());

        public static void WindowMaximize()
        {
            _driver.Manage().Window.Maximize();
        }

        public static void NamvigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public static IWebDriver GetDriver()
        {
            return _driver;
        }

        public static void Quit()
        {
            _driver.Quit();
            _currentInstance = null;
            _driver = null;
            _browser = null;
        }
    }
}

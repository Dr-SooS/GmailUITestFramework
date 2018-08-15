using System;
using OpenQA.Selenium;

namespace CoreFramework.Browser
{
    /// <summary>
    /// Browser singleton wrapper 
    /// </summary>
    public class Browser
    {
        private static Browser _currentInstance;
        private static IWebDriver _driver;
        public static BrowserFactory.BrowserType CurrentBrowser;
        public static int ImplWait;
        public static double TimeoutForElement;
        private static string _browser;

        private Browser()
        {
            InitParams();
            _driver = BrowserFactory.GetDriver(CurrentBrowser, ImplWait);
        }

        private static void InitParams()
        {
            ImplWait = Convert.ToInt32(Configuration.ElementTimeout);
            TimeoutForElement = Convert.ToDouble(Configuration.ElementTimeout);
            _browser = Configuration.Browser;
            Enum.TryParse(_browser, out CurrentBrowser);
        }

        /// <summary>
        /// Returns current instance 
        /// </summary>
        public static Browser Instance => _currentInstance ?? (_currentInstance = new Browser());

        /// <summary>
        /// Maximize browser window
        /// </summary>
        public static void WindowMaximize()
        {
            _driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Nvaigates to Url
        /// </summary>
        /// <param name="url">Url to navigate</param>
        public static void NamvigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Returns IWebDriver instance
        /// </summary>
        /// <returns></returns>
        public static IWebDriver GetDriver()
        {
            return _driver;
        }


        /// <summary>
        /// Closes the browser and cleanup
        /// </summary>
        public static void Quit()
        {
            _driver.Quit();
            _currentInstance = null;
            _driver = null;
            _browser = null;
        }
    }
}

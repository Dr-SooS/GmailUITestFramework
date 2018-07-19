using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace GmailUITestFramework.Browser
{
    public class BrowserFactory
    {
        public enum BrowserType
        {
            Crome,
            FireFox
        }

        public static IWebDriver GetDriver(BrowserType type, int timeOutSec)
        {
            IWebDriver driver = null;
            switch (type)
            {
                case BrowserType.Crome:
                {
                    var service = ChromeDriverService.CreateDefaultService();
                    var options = new ChromeOptions();
                    driver = new ChromeDriver(service, options, TimeSpan.FromSeconds(timeOutSec));
                    break;
                }
                case BrowserType.FireFox:
                {
                    var service = FirefoxDriverService.CreateDefaultService();
                    var options = new FirefoxOptions();
                    driver = new FirefoxDriver(service, options, TimeSpan.FromSeconds(timeOutSec));
                    break;
                }
            }
            return driver;
        }
    }
}
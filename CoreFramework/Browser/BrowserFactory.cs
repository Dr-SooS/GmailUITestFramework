﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace CoreFramework.Browser
{
    /// <summary>
    /// Browser factory
    /// </summary>
    public class BrowserFactory
    {
        public enum BrowserType
        {
            Crome,
            FireFox
        }

        /// <summary>
        /// Setup IWebDriver
        /// </summary>
        /// <param name="type">Type of browser e.g. Chrome, FireFox</param>
        /// <param name="timeOutSec">Default browser timeout</param>
        /// <returns></returns>
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
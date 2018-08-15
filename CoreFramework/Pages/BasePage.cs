using System.Diagnostics;
using CoreFramework.Elements;
using OpenQA.Selenium;

namespace CoreFramework.Pages
{
    /// <summary>
    /// Base page model
    /// </summary>
    public class BasePage
    {
        /// <summary>
        /// Locator for base element on page
        /// </summary>
        protected By IndicatorLocator;
        protected string PageName;

        public BasePage(By indicatorLocator, string pageName)
        {
            IndicatorLocator = indicatorLocator;
            PageName = pageName;
        }

        public BasePage(string pageName)
        {
            PageName = pageName;
        }

        /// <summary>
        /// Vaits for page loaded by waiting base element on page to be visible
        /// </summary>
        /// <returns>Current page instance</returns>
        public virtual BasePage WaitForPageLoaded()
        {
            var label = new ElementWithLogger(new Element(IndicatorLocator, $"{PageName} base element"));
            label.WaitForElementIsVisible();
            return this;
        }

        /// <summary>
        /// Vaits for page loaded by waiting base element on page to be visible
        /// </summary>
        /// <param name="locator">Locator for base element on page</param>
        /// <returns></returns>
        public virtual BasePage WaitForPageLoaded(By locator)
        {
            var label = new ElementWithLogger(new Element(locator, $"{PageName} base element"));
            label.WaitForElementIsVisible();
            return this;
        }
    }
}

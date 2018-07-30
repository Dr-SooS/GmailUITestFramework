using System.Diagnostics;
using CoreFramework.Elements;
using OpenQA.Selenium;

namespace CoreFramework.Pages
{
    public class BasePage
    {
        protected By IndicatorLocator;
        protected string PageName;

        protected BasePage(By indicatorLocator, string pageName)
        {
            IndicatorLocator = indicatorLocator;
            PageName = pageName;
        }

        public BasePage WaitForPageLoaded()
        {
            var label = new ElementWithLogger(new Element(IndicatorLocator, $"{PageName} base element"));
            label.WaitForElementIsVisible();
            return this;
        }
    }
}

using System.Diagnostics;
using CoreFramework.Elements;
using OpenQA.Selenium;

namespace CoreFramework.Pages
{
    public class BasePage
    {
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

        public virtual BasePage WaitForPageLoaded()
        {
            var label = new ElementWithLogger(new Element(IndicatorLocator, $"{PageName} base element"));
            label.WaitForElementIsVisible();
            return this;
        }
    }
}

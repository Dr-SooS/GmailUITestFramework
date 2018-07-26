using OpenQA.Selenium;

namespace CoreFramework.Pages
{
    public class BasePage
    {
        protected By IndicatorLocator;

        protected BasePage(By indicatorLocator)
        {
            IndicatorLocator = indicatorLocator;
        }

        public BasePage WaitForPageLoaded()
        {
            var label = new BaseElement(IndicatorLocator);
            label.WaitForElementIsVisible();
            return this;
        }
    }
}

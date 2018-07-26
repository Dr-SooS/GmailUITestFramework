using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CoreFramework
{
    public class BaseElement
    {

        protected string Name;
        protected By Locator;
        protected IWebElement Element;

        public BaseElement(By locator, string name)
        {
            Locator = locator;
            Name = name == "" ? this.GetText() : name;
        }

        public BaseElement(By locator)
        {
            this.Locator = locator;
        }

        public string GetText()
        {
            this.WaitForElementIsVisible();
            return this.GetElement().Text;
        }

        public IWebElement GetElement()
        {
            try
            {
                this.Element = CoreFramework.Browser.Browser.GetDriver().FindElement(this.Locator);
            }
            catch (Exception e)
            {
                throw;
            }
            return this.Element;
        }

        public void WaitForElementIsVisible()
        {
            new WebDriverWait(CoreFramework.Browser.Browser.GetDriver(), TimeSpan.FromSeconds(CoreFramework.Browser.Browser.TimeoutForElement)).Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = CoreFramework.Browser.Browser.GetDriver().FindElement(Locator);
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }
    }
}

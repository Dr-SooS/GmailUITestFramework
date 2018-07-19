using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GmailUITestFramework.Browser
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
                this.Element = Browser.GetDriver().FindElement(this.Locator);
            }
            catch (Exception e)
            {
                throw;
            }
            return this.Element;
        }

        public void WaitForElementIsVisible()
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(Browser.TimeoutForElement)).Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = Browser.GetDriver().FindElement(Locator);
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

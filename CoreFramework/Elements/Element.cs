using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CoreFramework.Elements
{
    /// <summary>
    /// Implementation of BaseElement methods
    /// </summary>
    public class Element: BaseElement
    {

        public Element(By locator, string name): base(locator, name)
        {
        }

        public override string GetText()
        {
            WaitForElementIsVisible();
            return GetElement().Text;
        }

        public override IWebElement GetElement()
        {
            try
            {
                Element = Browser.Browser.GetDriver().FindElement(Locator);
            }
            catch (Exception e)
            {
                throw;
            }
            return Element;
        }

        public override void WaitForElementIsVisible()
        {
            new WebDriverWait(Browser.Browser.GetDriver(), TimeSpan.FromSeconds(Browser.Browser.TimeoutForElement)).Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = GetElement();
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

        public override void SendKeys(string text)
        {
            WaitForElementIsVisible();
            GetElement().SendKeys(text);
        }

        public override void Click()
        {
            WaitForElementIsVisible();
            GetElement().Click();
        }

        public override void JsClick()
        {
            WaitForElementIsVisible();
            ((IJavaScriptExecutor)Browser.Browser.GetDriver()).ExecuteScript("arguments[0].click();", GetElement());
        }
    }
}

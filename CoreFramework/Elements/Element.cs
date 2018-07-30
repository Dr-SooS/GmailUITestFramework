using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CoreFramework.Elements
{
    public class Element: BaseElement
    {

        public Element(By locator, string name): base(locator, name)
        {
        }

        public override string GetText()
        {
            this.WaitForElementIsVisible();
            return this.GetElement().Text;
        }

        public override IWebElement GetElement()
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

        public override void WaitForElementIsVisible()
        {
            new WebDriverWait(CoreFramework.Browser.Browser.GetDriver(), TimeSpan.FromSeconds(CoreFramework.Browser.Browser.TimeoutForElement)).Until(condition =>
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
    }
}

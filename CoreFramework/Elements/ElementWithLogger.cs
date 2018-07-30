using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CoreFramework.Elements
{
    public class ElementWithLogger: BaseElement
    {

        protected BaseElement BaseElement;

        public ElementWithLogger(BaseElement element): base(element.Locator, element.Name)
        {
            BaseElement = element;
        }

        public override IWebElement GetElement()
        {

            Logger.LogInfo($"Getting element \"{BaseElement.Name}\"");
            return BaseElement.GetElement();
        }

        public override string GetText()
        {
            Logger.LogInfo($"Get element \"{BaseElement.Name}\" text");
            return BaseElement.GetText();
        }

        public override void WaitForElementIsVisible()
        {
            Logger.LogInfo($"Waiting for element is visible \"{BaseElement.Name}\"");
            BaseElement.WaitForElementIsVisible();
        }

        public override void SendKeys(string text)
        {
            Logger.LogInfo($"Writing \"{text}\" to \"{BaseElement.Name}\"");
            BaseElement.SendKeys(text);
        }

        public override void Click()
        {
            Logger.LogInfo($"Click on \"{BaseElement.Name}\"");
            BaseElement.Click();
        }
    }
}

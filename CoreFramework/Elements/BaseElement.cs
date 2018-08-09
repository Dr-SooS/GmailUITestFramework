using System;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CoreFramework.Elements
{
    public abstract class BaseElement
    {

        public string Name { get; protected set; }
        public By Locator { get; protected set; }
        protected IWebElement Element;

        protected BaseElement(By locator, string name)
        {
            Locator = locator;
            Name = name == "" ? this.GetText() : name;
        }

        public abstract string GetText();

        public abstract IWebElement GetElement();

        public abstract void WaitForElementIsVisible();

        public abstract void SendKeys(string text);

        public abstract void Click();

        public abstract void JsClick();
    }
}

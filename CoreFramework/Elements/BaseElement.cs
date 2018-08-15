using System;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CoreFramework.Elements
{
    /// <summary>
    /// Abstrac wrapper on IWebElement
    /// </summary>
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

        /// <summary>
        /// Returns element text
        /// </summary>
        /// <returns></returns>
        public abstract string GetText();

        /// <summary>
        /// Returns current instance of IWebElement
        /// </summary>
        /// <returns></returns>
        public abstract IWebElement GetElement();

        /// <summary>
        /// Waits for visibility of element
        /// </summary>
        public abstract void WaitForElementIsVisible();


        /// <summary>
        /// Writes text to elements
        /// </summary>
        /// <param name="text">Text to write</param>
        public abstract void SendKeys(string text);


        /// <summary>
        /// Clicks the element using IWebDriver
        /// </summary>
        public abstract void Click();

        /// <summary>
        /// Clicks the element using JSExecutor
        /// </summary>
        public abstract void JsClick();
    }
}

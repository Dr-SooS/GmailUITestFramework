using System;
using System.Collections.Generic;
using CoreFramework.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CoreFramework.Pages
{
    public class SentPage : BasePage
    {
        private readonly BaseElement _checkAllSent = new ElementWithLogger(new Element(
            By.XPath(
                "//span[@role='checkbox' and not(ancestor::div[contains(@style,'display:none')]) and not(ancestor::div[contains(@style,'display: none')])]"),
            "Check all sent"));

        private readonly BaseElement _deleteSentButton =
            new Element(
                By.XPath(
                    "//div[@aria-label='Удалить' and not(ancestor::div[contains(@style,'display:none')]) and not(ancestor::div[contains(@style,'display: none')])]"),
                "delete sent button");

        public SentPage() : base("sent page")
        {
        }

        public IList<IWebElement> GetMailsList()
        {
            return Browser.Browser.GetDriver().FindElements(By.XPath("//td/div[contains(text(), 'Кому: ')][2]"));
        }

        public HomePage DeleteAll()
        {
            if (GetMailsList().Count > 0)
            {
                _checkAllSent.Click();
                _deleteSentButton.Click();
                ((ConfirmDeleteModal) new ConfirmDeleteModal().WaitForPageLoaded()).ConfirmDelete();
            }

            return new HomePage();
        }
    }
}
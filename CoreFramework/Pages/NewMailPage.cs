using System;
using CoreFramework.Elements;
using CoreFramework.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CoreFramework.Pages
{
    /// <summary>
    /// POM for mail creating form
    /// </summary>
    public class NewMailPage: BasePage
    {

        private static readonly By NewMailLabel = By.CssSelector("div.aYF");

        private readonly BaseElement ToField = new ElementWithLogger(new Element(By.Name("to"), "to field"));
        private readonly BaseElement TopicField = new ElementWithLogger(new Element(By.Name("subjectbox"), "topic field"));
        private readonly BaseElement MessageArea = new ElementWithLogger(new Element(By.CssSelector("div.Am.Al.editable.LW-avf"), "message field"));

        private readonly BaseElement CloseButton = new ElementWithLogger(new Element(By.CssSelector("img[aria-label='Сохранить и закрыть']"), "save draft button"));
        private readonly BaseElement SubmitButton = new ElementWithLogger(new Element(By.XPath("//div[text()='Отправить']"), "send email button"));

        public NewMailPage() : base(NewMailLabel, "New mail page") { }


        /// <summary>
        /// Fills form fields with data
        /// </summary>
        /// <param name="to">Send to parameter</param>
        /// <param name="topic"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public HomePage CreateDraft(string to, string topic, string message)
        {
            ToField.SendKeys(to);
            TopicField.SendKeys(topic);
            MessageArea.SendKeys(message);
            CloseButton.Click();
            return new HomePage();
        }

        /// <summary>
        /// Confirms sending email
        /// </summary>
        /// <returns></returns>
        public HomePage SendMail()
        {
            new WebDriverWait(Browser.Browser.GetDriver(), TimeSpan.FromSeconds(Browser.Browser.TimeoutForElement))
                .Until(
                    condition =>
                    {
                        try
                        {
                            return new ElementWithLogger(new Element(By.CssSelector("div.oL.aDm.az9 span"), "send mail")).GetText() != "";
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

            SubmitButton.Click();
            return new HomePage();
        }

        /// <summary>
        /// Gets values of form fields
        /// </summary>
        /// <returns>Message model</returns>
        public MessageData GetDraftData()
        {
            new WebDriverWait(Browser.Browser.GetDriver(), TimeSpan.FromSeconds(Browser.Browser.TimeoutForElement))
                .Until(
                    condition =>
                    {
                        try
                        {
                            var text = ((IJavaScriptExecutor) Browser.Browser.GetDriver()).ExecuteScript(
                                "return arguments[0].value;", TopicField.GetElement()).ToString();
                            return text != "";
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
            var topic = ((IJavaScriptExecutor)Browser.Browser.GetDriver()).ExecuteScript(
                "return arguments[0].value;", TopicField.GetElement()).ToString();
            return new MessageData()
            {
                To = new ElementWithLogger(new Element(By.CssSelector("div.oL.aDm.az9 span"), "to field")).GetText(),
                Topic = topic,
                Message = MessageArea.GetText()
            };
        }
    }
}

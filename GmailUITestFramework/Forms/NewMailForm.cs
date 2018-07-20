using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GmailUITestFramework.Browser;
using GmailUITestFramework.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GmailUITestFramework.Forms
{
    public class NewMailForm: BaseForm
    {

        private static readonly By NewMailLabel = By.CssSelector("div.aYF");

        private readonly BaseElement ToField = new BaseElement(By.Name("to"));
        private readonly BaseElement TopicField = new BaseElement(By.Name("subjectbox"));
        private readonly BaseElement MessageArea = new BaseElement(By.CssSelector("div.Am.Al.editable.LW-avf"));

        private readonly BaseElement CloseButton = new BaseElement(By.CssSelector("img[aria-label='Сохранить и закрыть']"));
        private readonly BaseElement SubmitButton = new BaseElement(By.XPath("//div[text()='Отправить']"));

        public NewMailForm() : base(NewMailLabel) { }

        public HomePage CreateDraft(string to, string topic, string message)
        {
            ToField.GetElement().SendKeys(to);
            TopicField.GetElement().SendKeys(topic);
            MessageArea.GetElement().SendKeys(message);
            CloseButton.GetElement().Click();
            return new HomePage();
        }

        public HomePage SendMail()
        {
            SubmitButton.GetElement().Click();
            return new HomePage();
        }

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
                To = new BaseElement(By.CssSelector("div.oL.aDm.az9 span")).GetText(),
                Topic = topic,
                Message = MessageArea.GetText()
            };
        }
    }
}

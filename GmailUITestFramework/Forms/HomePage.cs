using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GmailUITestFramework.Browser;
using OpenQA.Selenium;

namespace GmailUITestFramework.Forms
{
    public class HomePage: BaseForm
    {
        private static readonly By HomePageLabel = By.CssSelector("div.aKh");

        private readonly BaseElement createMessageButton = new BaseElement(By.XPath("//div[text()='НАПИСАТЬ']"));
        private readonly BaseElement openDraftsButton = new BaseElement(By.CssSelector("a[href='https://mail.google.com/mail/u/0/#drafts']"));
        private readonly BaseElement openSentButton = new BaseElement(By.CssSelector("a[href='https://mail.google.com/mail/u/0/#sent']"));

        public HomePage() : base(HomePageLabel) { }

        public NewMailForm OpenNewMessageForm()
        {
            createMessageButton.GetElement().Click();
            return (NewMailForm) new NewMailForm().WaitForPageLoaded();
        }

        public DraftsPage OpenDrafts()
        {
            openDraftsButton.GetElement().Click();
            return (DraftsPage) new DraftsPage().WaitForPageLoaded();
        }

        public SentPage OpenSent()
        {
            openSentButton.GetElement().Click();
            return (SentPage) new SentPage().WaitForPageLoaded();
        }

    }
}

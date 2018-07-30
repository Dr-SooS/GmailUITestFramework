using CoreFramework.Elements;
using OpenQA.Selenium;

namespace CoreFramework.Pages
{
    public class HomePage: BasePage
    {
        private static readonly By HomePageLabel = By.CssSelector("div.aKh");

        private readonly BaseElement createMessageButton = new ElementWithLogger(new Element(By.XPath("//div[text()='НАПИСАТЬ']"), "create message button"));
        private readonly BaseElement openDraftsButton = new ElementWithLogger(new Element(By.CssSelector("a[href='https://mail.google.com/mail/u/0/#drafts']"), "open draft button"));
        private readonly BaseElement openSentButton = new ElementWithLogger(new Element(By.CssSelector("a[href='https://mail.google.com/mail/u/0/#sent']"), "open sent button"));

        public HomePage() : base(HomePageLabel, "Home Page") { }

        public NewMailPage OpenNewMessageForm()
        {
            createMessageButton.Click();
            return (NewMailPage) new NewMailPage().WaitForPageLoaded();
        }

        public DraftsPage OpenDrafts()
        {
            openDraftsButton.Click();
            return (DraftsPage) new DraftsPage().WaitForPageLoaded();
        }

        public SentPage OpenSent()
        {
            openSentButton.Click();
            return (SentPage) new SentPage().WaitForPageLoaded();
        }

    }
}

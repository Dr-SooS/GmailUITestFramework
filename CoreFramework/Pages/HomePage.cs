using OpenQA.Selenium;

namespace CoreFramework.Pages
{
    public class HomePage: BasePage
    {
        private static readonly By HomePageLabel = By.CssSelector("div.aKh");

        private readonly BaseElement createMessageButton = new BaseElement(By.XPath("//div[text()='НАПИСАТЬ']"));
        private readonly BaseElement openDraftsButton = new BaseElement(By.CssSelector("a[href='https://mail.google.com/mail/u/0/#drafts']"));
        private readonly BaseElement openSentButton = new BaseElement(By.CssSelector("a[href='https://mail.google.com/mail/u/0/#sent']"));

        public HomePage() : base(HomePageLabel) { }

        public NewMailPage OpenNewMessageForm()
        {
            createMessageButton.GetElement().Click();
            return (NewMailPage) new NewMailPage().WaitForPageLoaded();
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

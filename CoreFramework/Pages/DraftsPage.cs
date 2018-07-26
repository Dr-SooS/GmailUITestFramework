using OpenQA.Selenium;

namespace CoreFramework.Pages
{
    public class DraftsPage: BasePage
    {
        private static readonly By DraftsPageLabel = By.XPath("//span[text()='Test Message']");

        private readonly BaseElement DraftLine = new BaseElement(By.XPath("//span[text()='Test Message']"));

        public DraftsPage() : base(DraftsPageLabel) { }

        public NewMailPage OpenDraft()
        {
            DraftLine.GetElement().Click();
            return (NewMailPage) new NewMailPage().WaitForPageLoaded();
        }

    }
}

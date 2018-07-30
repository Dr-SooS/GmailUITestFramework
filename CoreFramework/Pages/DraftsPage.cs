using CoreFramework.Elements;
using OpenQA.Selenium;

namespace CoreFramework.Pages
{
    public class DraftsPage: BasePage
    {
        private static readonly By DraftsPageLabel = By.XPath("//span[text()='Test Message']");

        private readonly BaseElement _draftLine = new ElementWithLogger(new Element(By.XPath("//span[text()='Test Message']"), "Draft page link"));

        public DraftsPage() : base(DraftsPageLabel, "Draft Page") { }

        public NewMailPage OpenDraft()
        {
            _draftLine.Click();
            return (NewMailPage) new NewMailPage().WaitForPageLoaded();
        }

    }
}

using CoreFramework.Elements;
using OpenQA.Selenium;

namespace CoreFramework.Pages
{
    public class DraftsPage: BasePage
    {

        private readonly BaseElement _draftLine = new ElementWithLogger(new Element(By.XPath("//span[text()='Test Message']"), "Draft page link"));

        public DraftsPage() : base("Draft Page") { }

        public NewMailPage OpenDraft()
        {
            _draftLine.Click();
            return (NewMailPage) new NewMailPage().WaitForPageLoaded();
        }

    }
}

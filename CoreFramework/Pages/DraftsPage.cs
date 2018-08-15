using CoreFramework.Elements;
using OpenQA.Selenium;

namespace CoreFramework.Pages
{
    /// <summary>
    /// POM for Drafts tab
    /// </summary>
    public class DraftsPage: BasePage
    {

        private readonly BaseElement _draftLine = new ElementWithLogger(new Element(By.XPath("//span[text()='Test Message']"), "Draft page link"));

        public DraftsPage() : base("Draft Page") { }

        /// <summary>
        /// Opens draft to edit
        /// </summary>
        /// <returns>POM for mail form</returns>
        public NewMailPage OpenDraft()
        {
            _draftLine.Click();
            return (NewMailPage) new NewMailPage().WaitForPageLoaded();
        }

    }
}

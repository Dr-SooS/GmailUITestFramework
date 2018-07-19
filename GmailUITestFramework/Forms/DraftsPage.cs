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
    public class DraftsPage: BaseForm
    {
        private static readonly By DraftsPageLabel = By.XPath("//span[text()='Test Message']");

        private readonly BaseElement DraftLine = new BaseElement(By.XPath("//span[text()='Test Message']"));

        public DraftsPage() : base(DraftsPageLabel) { }

        public NewMailForm OpenDraft()
        {
            DraftLine.GetElement().Click();
            return (NewMailForm) new NewMailForm().WaitForPageLoaded();
        }

    }
}

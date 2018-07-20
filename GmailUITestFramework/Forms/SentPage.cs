using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GmailUITestFramework.Browser;
using OpenQA.Selenium;

namespace GmailUITestFramework.Forms
{
    public class SentPage: BaseForm
    {
        private static readonly By SentPageLabel = By.XPath("//td/div[contains(text(), 'Кому: ')][2]");

        //private readonly BaseElement SentLine = new BaseElement(By.XPath("//div[contains(text(), 'Кому:')]"));

        public SentPage() : base(SentPageLabel) { }

        public IList<IWebElement> GetMailsList()
        {
            return Browser.Browser.GetDriver().FindElements(By.XPath("//td/div[contains(text(), 'Кому: ')][2]"));
        }
    }
}

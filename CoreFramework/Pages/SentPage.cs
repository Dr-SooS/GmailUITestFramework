using System.Collections.Generic;
using OpenQA.Selenium;

namespace CoreFramework.Pages
{
    public class SentPage: BasePage
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

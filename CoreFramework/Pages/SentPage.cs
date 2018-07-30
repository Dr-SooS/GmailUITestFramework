using System.Collections.Generic;
using OpenQA.Selenium;

namespace CoreFramework.Pages
{
    public class SentPage: BasePage
    {
        private static readonly By SentPageLabel = By.XPath("//td/div[contains(text(), 'Кому: ')][2]");
        

        public SentPage() : base(SentPageLabel, "sent page") { }

        public IList<IWebElement> GetMailsList()
        {
            return Browser.Browser.GetDriver().FindElements(By.XPath("//td/div[contains(text(), 'Кому: ')][2]"));
        }
    }
}

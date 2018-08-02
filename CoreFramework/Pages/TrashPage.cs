using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.Elements;
using OpenQA.Selenium;

namespace CoreFramework.Pages
{
    public class TrashPage: BasePage
    {

        private static readonly By TrashPageLabel = By.XPath("//div[contains(text(), '(письма, находящиеся в корзине более 30 дней, удаляются автоматически)')]");

        private readonly BaseElement _checkAllTrash = new ElementWithLogger(new Element(By.XPath("//span[@role='checkbox' and not(ancestor::div[contains(@style,'display:none')]) and not(ancestor::div[contains(@style,'display: none')])]"), "Check all sent"));
        private readonly BaseElement _deleteTrashButton = new Element(By.XPath("//div[text()='Удалить навсегда']"), "delete sent button");


        public TrashPage() : base(TrashPageLabel, "Trash page") {}

        public IList<IWebElement> GetTrashMailsList()
        {
            return Browser.Browser.GetDriver().FindElements(By.CssSelector("td.aqM.xY"));
        }

        public HomePage DeleteAll()
        {
            if (GetTrashMailsList().Count > 0)
            {
                _checkAllTrash.Click();
                _deleteTrashButton.Click();
            }
            return new HomePage();
        }
    }
}

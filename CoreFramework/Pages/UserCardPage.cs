using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.Elements;
using CoreFramework.Models;
using OpenQA.Selenium;

namespace CoreFramework.Pages
{
    /// <summary>
    /// User card with basic data
    /// </summary>
    public class UserCardPage: BasePage
    {
        private static readonly By UserCardPageLabel = By.XPath("//a[text()='Добавить аккаунт']");

        private readonly BaseElement Name =
            new ElementWithLogger(new Element(By.XPath("//div[@aria-label='Информация об аккаунте']/div/div/div[1]"),
                "Name"));

        private readonly BaseElement Email =
            new ElementWithLogger(new Element(By.XPath("//div[@aria-label='Информация об аккаунте']/div/div/div[2]"),
                "Name"));

        public UserCardPage() : base(UserCardPageLabel, "User Card") { }

        /// <summary>
        /// Gets user basic data 
        /// </summary>
        /// <returns>User data model</returns>
        public UserCreds GetUserData()
        {
            string[] names = Name.GetText().Split(' ');
            return new UserCreds() {Email = Email.GetText(), FirstName = names[0], LastName = names[1]};
        }
    }
}

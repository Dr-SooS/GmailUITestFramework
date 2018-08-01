using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.Elements;
using OpenQA.Selenium;

namespace CoreFramework.Pages
{
    public class ConfirmDeleteModal: BasePage
    {

        private static readonly By ModalLabel = By.XPath("//span[text()='Подтвердите удаление' and not(ancestor::div[contains(@style,'display:none')]) and not(ancestor::div[contains(@style,'display: none')])]");

        private readonly BaseElement _confirmDeleteButton = new ElementWithLogger(new Element(By.XPath("//button[@name='ok' and not(ancestor::div[contains(@style,'display:none')]) and not(ancestor::div[contains(@style,'display: none')])]"), "Confirm delete sent button"));

        public ConfirmDeleteModal() : base(ModalLabel, "Confirm delete modal") {}

        public HomePage ConfirmDelete()
        {
            _confirmDeleteButton.Click();
            return new HomePage();
        }
    }
}

﻿using System;
using CoreFramework.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace CoreFramework.Pages
{
    /// <summary>
    /// Pom for home page
    /// </summary>
    public class HomePage: BasePage
    {
        private static readonly By HomePageLabel = By.CssSelector("div.aKh");

        private readonly BaseElement createMessageButton = new ElementWithLogger(new Element(By.XPath("//div[text()='НАПИСАТЬ']"), "create message button"));
        private readonly BaseElement openDraftsButton = new ElementWithLogger(new Element(By.CssSelector("a[href='https://mail.google.com/mail/u/0/#drafts']"), "open draft button"));
        private readonly BaseElement openSentButton = new ElementWithLogger(new Element(By.CssSelector("a[href='https://mail.google.com/mail/u/0/#sent']"), "open sent button"));

        private readonly BaseElement moreButton = new ElementWithLogger(new Element(By.CssSelector("span.J-Ke.n4.ah9"), "more button"));
        private readonly BaseElement openTrashButton = new ElementWithLogger(new Element(By.CssSelector("a[href='https://mail.google.com/mail/u/0/#trash']"), "open trash button"));

        private readonly BaseElement openUserDataButton = new ElementWithLogger(new Element(By.XPath("//a[@href='https://accounts.google.com/SignOutOptions?hl=ru&continue=https://mail.google.com/mail&service=mail']"), "open user data button"));

        public HomePage() : base(HomePageLabel, "Home Page") { }

        public NewMailPage OpenNewMessageForm()
        {
            createMessageButton.Click();
            return (NewMailPage) new NewMailPage().WaitForPageLoaded();
        }

        /// <summary>
        /// Opens drafts tab
        /// </summary>
        /// <returns></returns>
        public DraftsPage OpenDrafts()
        {
            openDraftsButton.Click();
            try
            {
                return (DraftsPage) new DraftsPage().WaitForPageLoaded(By.XPath("(//font[text()='Черновик'])[2]"));
            }
            catch (Exception e)
            {
                return (DraftsPage)new DraftsPage().WaitForPageLoaded(By.XPath("//td[contains(text(), 'Нет сохраненных черновиков.')]"));
            }
        }

        /// <summary>
        /// Opens sent tab
        /// </summary>
        /// <returns></returns>
        public SentPage OpenSent()
        {
            openSentButton.Click();
            try
            {
                return (SentPage)new SentPage().WaitForPageLoaded(By.XPath("//td/div[contains(text(), 'Кому: ')][2]"));
            }
            catch (Exception e)
            {
                return (SentPage)new SentPage().WaitForPageLoaded(By.XPath("//td[contains(text(), 'Нет отправленных писем. ')]"));
            }
            
        }

        /// <summary>
        /// Opens trash tab
        /// </summary>
        /// <returns></returns>
        public TrashPage OpenTrash()
        {
            moreButton.JsClick();
            openTrashButton.JsClick();
            return (TrashPage) new TrashPage().WaitForPageLoaded();
        }

        /// <summary>
        /// Opens user card
        /// </summary>
        /// <returns></returns>
        public UserCardPage OpenUserCard()
        {
            openUserDataButton.Click();
            return (UserCardPage) new UserCardPage().WaitForPageLoaded();
        }

    }
}

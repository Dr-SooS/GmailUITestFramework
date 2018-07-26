﻿using CoreFramework.Browser;
using CoreFramework.Models;
using CoreFramework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GmailUITestFramework.StepDefenitions
{
    [Binding]
    public class GmailBDDTestsSteps
    {
        private static Browser Browser = Browser.Instance;
        private MessageData _messageData;

        [BeforeTestRun]
        public static void  Setup()
        {
            Browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NamvigateTo(Configuration.StartUrl);
        }

        [AfterTestRun]
        public static void Cleanup()
        {
            Browser.Quit();
        }

        [Given(@"I am logged in as ""(.*)"" user and ""(.*)"" password")]
        public void Login(string email, string password)
        {
            ((LoginPage) new LoginPage().WaitForPageLoaded()).Login(email, password);
        }

        [When(@"I create and save new message draft")]
        public void CrateDraft(Table table)
        {
            _messageData = table.CreateInstance<MessageData>();

            ((HomePage) new HomePage().WaitForPageLoaded())
                .OpenNewMessageForm()
                .CreateDraft(_messageData.To, _messageData.Topic, _messageData.Message)
                .OpenDrafts();
        }

        [When(@"I open draft")]
        public void WhenIOpenDraft()
        {
            ((DraftsPage) new DraftsPage().WaitForPageLoaded()).OpenDraft();
        }

        [When(@"I send message")]
        public void WhenISendMessage()
        {
            ((NewMailPage) new NewMailPage().WaitForPageLoaded()).SendMail().OpenSent();
        }

        [Then(@"message should be in sent folder")]
        public void ThenMessageShouldBeInSentFolder()
        {
            var list = ((SentPage) new SentPage().WaitForPageLoaded()).GetMailsList();
            Assert.IsTrue(list.Count > 0);
        }
    }
}
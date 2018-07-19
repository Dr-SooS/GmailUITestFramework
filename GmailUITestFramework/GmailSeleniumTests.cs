using System;
using System.Threading;
using GmailUITestFramework.Browser;
using GmailUITestFramework.Forms;
using GmailUITestFramework.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GmailUITestFramework
{
    [TestClass]
    public class GmailSeleniumTests: BaseTest
    {
        [TestMethod]
        public void EmailSendingTest()
        {
            var testMessageData = new MessageData
            {
                To = "testadres@gmail.com",
                Topic = "Test Message",
                Message = "Message Body\nMessage Body\nMessage Body\nMessage Body\nMessage Body\n"
            };

            var createdDraftForm = new LoginForm().Login("emailsendingtestuser@gmail.com", "testuserpassword")
                .OpenNewMessageForm()
                .CreateDraft(testMessageData.To, testMessageData.Topic, testMessageData.Message)
                .OpenDrafts()
                .OpenDraft()
                .SendMail()
                .OpenSent();
            

            //var topDraftData = createdDraftForm.GetDraftData();
            //Assert.AreEqual(testMessageData, topDraftData);

            //createdDraftForm.SendMail();

            Thread.Sleep(5000);
        }
    }
}

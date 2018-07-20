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
                To = "someadresfortest@gmail.com",
                Topic = "Test Message",
                Message = "Message Body\r\nMessage Body\r\nMessage Body\r\nMessage Body\r\nMessage Body"
            };

            var createdDraftForm = new LoginForm().Login("emailsendingtestuser@gmail.com", "testuserpassword")
                .OpenNewMessageForm()
                .CreateDraft(testMessageData.To, testMessageData.Topic, testMessageData.Message)
                .OpenDrafts()
                .OpenDraft();
            
            Assert.AreEqual(testMessageData, createdDraftForm.GetDraftData());

            var mailsList = createdDraftForm
                .SendMail()
                .OpenSent()
                .GetMailsList();

            Assert.IsTrue(mailsList.Count > 0);

            Thread.Sleep(5000);
        }
    }
}

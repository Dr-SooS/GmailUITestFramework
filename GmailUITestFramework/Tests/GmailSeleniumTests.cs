using System.Threading;
using CoreFramework;
using CoreFramework.Models;
using CoreFramework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GmailUITestFramework.Tests
{
    [TestClass]
    public class GmailSeleniumTests : BaseTest
    {
        MessageData testMessageData = new MessageData
        {
            To = "someadresfortest@gmail.com",
            Topic = "Test Message",
            Message = "Message Body\r\nMessage Body\r\nMessage Body\r\nMessage Body\r\nMessage Body"
        };

        private UserCreds userCreds = new UserCreds
        {
            Email = "emailsendingtestuser@gmail.com",
            Password = "testuserpassword"
        };

        [TestMethod]
        public void EmailSendingTest()
        {
            var createdDraftForm = new LoginPage().Login(userCreds.Email, userCreds.Password)
                .OpenNewMessageForm()
                .CreateDraft(testMessageData.To, testMessageData.Topic, testMessageData.Message)
                .OpenDrafts()
                .OpenDraft();

            var data = createdDraftForm.GetDraftData();

            Assert.AreEqual(testMessageData, createdDraftForm.GetDraftData());

            var mailsList = createdDraftForm
                .SendMail()
                .OpenSent()
                .GetMailsList();

            Assert.IsTrue(mailsList.Count > 0);
        }

        [TestMethod]
        public void EmailDeleetingTest()
        {
            var trashMailsList = new LoginPage().Login(userCreds.Email, userCreds.Password)
                .OpenNewMessageForm()
                .CreateDraft(testMessageData.To, testMessageData.Topic, testMessageData.Message)
                .OpenDrafts()
                .OpenDraft()
                .SendMail()
                .OpenSent()
                .DeleteAll()
                .OpenTrash()
                .GetTrashMailsList();

            Assert.IsTrue(trashMailsList.Count > 0);
        }
    }
}
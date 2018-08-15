using CoreFramework.Browser;
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
        private UserCreds _userData;

        public GmailBDDTestsSteps(UserCreds userData)
        {
            _userData = userData;
        }

        [Before]
        public static void  Setup()
        {
            Browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NamvigateTo(Configuration.StartUrl);
        }

        [After]
        public static void Cleanup()
        {
            new HomePage().OpenSent().DeleteAll();
            new HomePage().OpenTrash().DeleteAll();
            Browser.Quit();
        }

        [Given(@"I am logged in as ""(.*)"" user with ""(.*)"" email and ""(.*)"" password")]
        public void Login(string name, string email, string password)
        {
            string[] names = name.Split(' ');
            _userData.Email = email;
            _userData.Password = password;
            _userData.FirstName = names[0];
            _userData.LastName = names[1];

            ((LoginPage) new LoginPage().WaitForPageLoaded()).Login(email, password);
        }

        [When(@"I create and save new message draft")]
        public void CrateDraft(Table table)
        {
            _messageData = table.CreateInstance<MessageData>();

            new HomePage()
                .OpenNewMessageForm()
                .CreateDraft(_messageData.To, _messageData.Topic, _messageData.Message);
        }

        [When(@"I open draft")]
        public void WhenIOpenDraft()
        {
            new HomePage().OpenDrafts().OpenDraft();
        }

        [When(@"I send message")]
        public void WhenISendMessage()
        {
            ((NewMailPage) new NewMailPage().WaitForPageLoaded()).SendMail();
        }

        [Then(@"message should be in sent folder")]
        public void ThenMessageShouldBeInSentFolder()
        {
            var list = new HomePage().OpenSent().GetMailsList();
            Assert.IsTrue(list.Count > 0);
        }

        [When(@"I delete sent messages")]
        public void WhenIDeleteSentMessages()
        {
            new HomePage().OpenSent().DeleteAll();
        }

        [Then(@"message should be in trash folder")]
        public void ThenMessageShouldBeInTrashFolder()
        {
            var list = new HomePage().OpenTrash().GetTrashMailsList();
            Assert.IsTrue(list.Count > 0);
        }

    }
}
using System;
using CoreFramework.Models;
using CoreFramework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace GmailUITestFramework
{
    [Binding]
    public class GmailUserVerificationStepDefinitions
    {
        private UserCreds _userData;
        private UserCreds _displayedData;

        public GmailUserVerificationStepDefinitions(UserCreds userData)
        {
            _userData = userData;
        }

        [When(@"I open user details")]
        public void WhenIOpenUserDetails()
        {
            _displayedData = new HomePage().OpenUserCard().GetUserData();
        }
        
        [Then(@"correct user data should be displayed")]
        public void ThenDisplayedNameShouldBe()
        {
            Assert.AreEqual(_userData, _displayedData);
        }
    }
}

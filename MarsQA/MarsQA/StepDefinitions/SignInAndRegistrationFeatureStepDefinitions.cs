using MarsQA.Data;
using MarsQA.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace MarsQA.StepDefinitions
{
    [Binding]
    public class SignInAndRegistrationFeatureStepDefinitions
    {

        [Given(@"I registered into the Mars portal")]
        public void GivenIRegisteredIntoTheMarsPortal()
        {
            //Registering to Mars
            HomePage.Registration();
        }

        [Then(@"A user should be registered successfully")]
        public void ThenAUserShouldBeRegisteredSuccessfully()
        {
            string message = HomePage.GetRegistrationMessage();
            Assert.AreEqual("Registration successful", message, "Actual and expected message do not match.User not registered in successfully !!");
        }

        [Given(@"I logged into the Mars portal successfully")]
        public void GivenILoggedIntoTheMarsPortalSuccessfully()
        {
            //Signing in into Mars
            HomePage.Login();
        }

        [Then(@"A user should be taken to home page successfully")]
        public void ThenAUserShouldBeTakenToHomePageSuccessfully()
        {
            //Verify if user is taken to their home page upon login in to Mars 
            string expectedUserName = "Hi " + UserInformation.FirstName;
            string actualUserName = HomePage.GetUserName();
            Assert.AreEqual(expectedUserName, actualUserName, "Actual and expected username do not match.User not logged in successfully !!");
        }

    }
}

using MarsQA.Pages;
using System;
using TechTalk.SpecFlow;
using MarsQA.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Reflection.Emit;

namespace MarsQA.StepDefinitions
{
    [Binding]
    public class LanguageFeatureStepDefinitions 
    {
        [When(@"I added language '([^']*)' and level '([^']*)'")]
        public void WhenIAddedLanguageAndLevel(string language, string level)
        {
            //Adding a language
            ProfilePage.AddLanguage(language, level);
        }

        [Then(@"A language '([^']*)' added success message should be displayed")]
        public void ThenALanguageAddedSuccessMessageShouldBeDisplayed(string language)
        {
            //Verifying success message for addition of a language record
            string expectedMessage = language + " has been added to your languages";
            string actualMessage = ProfilePage.GetMessage();
            Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected message do not match. Language not added!!");
        }

        [Then(@"A language '([^']*)' and Level '([^']*)' record should be added successfully")]
        public void ThenALanguageAndLevelRecordShouldBeAddedSuccessfully(string language, string level)
        {
            //Verify the added language record in the table
            string newAddedLanguage = ProfilePage.GetLanguage();
            string newAddedLanguageLevel = ProfilePage.GetLanguageLevel();
            Assert.AreEqual(language, newAddedLanguage, "Actual and expected language do not match. Language not added!!");
            Assert.AreEqual(level, newAddedLanguageLevel, "Actual and expected language level do not match. Language level not added !!");
        }

        [When(@"I update language '([^']*)' and level '([^']*)' of an existing record")]
        public void WhenIUpdateLanguageAndLevelOfAnExistingRecord(string language, string level)
        {
            //Updating a language
            ProfilePage.UpdateLanguage(language, level);
        }

        [Then(@"A language '([^']*)' updated success message should be displayed")]
        public void ThenALanguageUpdatedSuccessMessageShouldBeDisplayed(string language)
        {
            //Verifying success message for updation of a language record
            string expectedMessage = language + " has been updated to your languages";
            string actualMessage = ProfilePage.GetMessage();
            Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected message do not match. Language not updated!!");
        }

        [Then(@"A language '([^']*)' and level '([^']*)' record should be updated successfully")]
        public void ThenALanguageAndLevelRecordShouldBeUpdatedSuccessfully(string language, string level)
        {
            //Verify the updated language record  in the table
            string updatedLanguage = ProfilePage.GetUpdatedLanguage();
            string updatedAddedLanguageLevel = ProfilePage.GetUpdatedLanguageLevel();
            Assert.AreEqual(language, updatedLanguage, "Actual and expected language do not match. Language not updated!!");
            Assert.AreEqual(level, updatedAddedLanguageLevel, "Actual and expected language level do not match. Language level not updated !!");
        }

        [When(@"I delete a language '([^']*)'  record")]
        public void WhenIDeleteALanguageRecord(string language)
        {
            //Deleting a language
            ProfilePage.DeleteLanguage(language);
        }

        [Then(@"A language '([^']*)' deleted success message should be displayed")]
        public void ThenALanguageDeletedSuccessMessageShouldBeDisplayed(string language)
        {
            //Verifying success message for deletion of a language record
            string expectedMessage = language + " has been deleted from your languages";
            string actualMessage = ProfilePage.GetMessage();
            Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected message do not match. Language not deleted!!");
        }

        [Then(@"A language '([^']*)' record should be deleted")]
        public void ThenALanguageRecordShouldBeDeleted(string language)
        {
            //Verify the language record deleted
            string result = ProfilePage.GetDeleteLanguageResult(language);
            Assert.AreEqual("Deleted", result, "Actual and expected result do not match. Language not deleted!!");
        }
    }
}

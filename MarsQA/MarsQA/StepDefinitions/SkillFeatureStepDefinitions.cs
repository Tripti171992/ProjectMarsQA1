using MarsQA.Pages;
using MarsQA.Utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace MarsQA.StepDefinitions
{
    [Binding]
    public class SkillFeatureStepDefinitions
    {
        [When(@"I added '([^']*)' and '([^']*)'")]
        public void WhenIAddedAnd(string skill, string skillLevel)
        {
            //Adding a skill
            ProfilePage.AddSkill(skill, skillLevel);
        }

        [Then(@"A skill '([^']*)' added success message should be displayed")]
        public void ThenASkillAddedSuccessMessageShouldBeDisplayed(string skill)
        {
            //Verifying success message for addition of a skill record
            string expectedMessage = skill + " has been added to your skills";
            string actualMessage = ProfilePage.GetMessage();
            Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected message do not match. Skill not added!!");
        }

        [Then(@"A '([^']*)' and '([^']*)' record should be added successfully")]
        public void ThenAAndRecordShouldBeAddedSuccessfully(string skill, string skillLevel)
        {
            //Verify the new skill record added in the table.
            string newAddedSkill = ProfilePage.GetSkill();
            string newAddedSkillLevel = ProfilePage.GetSkillLevel();
            Assert.AreEqual(skill, newAddedSkill, "Actual and expected skill do not match. Skill not added !!");
            Assert.AreEqual(skillLevel, newAddedSkillLevel, "Actual and expected skill level do not match. Skill Level not added !!");
        }

        [When(@"I update '([^']*)' and '([^']*)' of an existing record")]
        public void WhenIUpdateAndOfAnExistingRecord(string skill, string skillLevel)
        {
            //updating a skill
            ProfilePage.UpdateSkill(skill, skillLevel);
        }
        [Then(@"A skill '([^']*)' updated success message should be displayed")]
        public void ThenASkillUpdatedSuccessMessageShouldBeDisplayed(string skill)
        {
            //Verifying success message for updation of a skill record
            string expectedMessage = skill + " has been updated to your skills";
            string actualMessage = ProfilePage.GetMessage();
            Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected message do not match. Skill not updated!!");
        }

        [Then(@"A '([^']*)' and '([^']*)' of the existing record should be updated successfully")]
        public void ThenAAndOfTheExistingRecordShouldBeUpdatedSuccessfully(string skill, string skillLevel)
        {
            //Verify the updated skill record  in the table.
            string updatedSkill = ProfilePage.GetUpdatedSkill();
            string updatedSkillLevel = ProfilePage.GetUpdatedSkillLevel();
            Assert.AreEqual(skill, updatedSkill, "Actual and expected skill do not match after editting !!");
            Assert.AreEqual(skillLevel, updatedSkillLevel, "Actual and expected skill level do not match after editting !!");
        }

        [When(@"I delete a skill '([^']*)' record")]
        public void WhenIDeleteASkillRecord(string skill)
        {
            //Deleting a skill
            ProfilePage.DeleteSkill(skill);
        }

        [Then(@"A skill '([^']*)' deleted success message should be displayed")]
        public void ThenASkillDeletedSuccessMessageShouldBeDisplayed(string skill)
        {
            //Verifying success message for deletion of a skill record
            string expectedMessage = skill + " has been deleted";
            string actualMessage = ProfilePage.GetMessage();
            Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected message do not match. Skill not deleted!!");
        }

        [Then(@"A skill '([^']*)' record should be deleted")]
        public void ThenASkillRecordShouldBeDeleted(string skill)
        {
            //Verify the skill record deleted
            string result = ProfilePage.GetDeleteSKillResult(skill);
            Assert.AreEqual("Deleted", result, "Actual and expected result do not match. Skill not deleted!!");
        }

        [When(@"I cancelled adding a skill '([^']*)' and  level '([^']*)' reord")]
        public void WhenICancelledAddingASkillAndLevelReord(string skill, string skillLevel)
        {
            //Cancel Adding Skill
            ProfilePage.CancelSkillAddition(skill, skillLevel);
        }

        [Then(@"A skill '([^']*)' record addition should be cancelled")]
        public void ThenASkillRecordAdditionShouldBeCancelled(string skill)
        {
            //Verify the skill record not added on cancelling.
            string newSkill = ProfilePage.GetSkill();
            Assert.AreNotEqual(skill, newSkill, "Actual and expected skill match. Skill  added !!");
        }

        [When(@"I cancelled updating a skill '([^']*)' and a level '([^']*)'")]
        public void WhenICancelledUpdatingASkillAndALevel(string skill, string skillLevel)
        {
            //Cancel updatig Skill
            ProfilePage.CancelSkillUpdation(skill, skillLevel);
        }

        [Then(@"A skill '([^']*)' record updation should be cancelled")]
        public void ThenASkillRecordUpdationShouldBeCancelled(string skill)
        {
            //Verify the skill record not updated on cancelling.
            string updatedSkill = ProfilePage.GetUpdatedSkill();
            Assert.AreNotEqual(skill, updatedSkill, "Actual and expected skill match. Skill  updated !!");
        }
    }
}

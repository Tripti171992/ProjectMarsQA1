using MarsQA.Utilities;
using Microsoft.VisualBasic;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Time;

namespace MarsQA.Pages
{
    public class ProfilePage
    {
        private static IWebElement SkillTab => CommonDriver.driver.FindElement(By.XPath("//a[text()='Skills']"));
        private static IWebElement AddNewSkillButton => CommonDriver.driver.FindElement(By.XPath("//*[text()='Skill']/following-sibling::th[2]/div"));
        private static IWebElement SkillTextBox => CommonDriver.driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        private static IWebElement SkillLevelDropDown => CommonDriver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']"));
        private static IWebElement AddButton => CommonDriver.driver.FindElement(By.XPath("//input[@value='Add']"));
        private static IWebElement NewSkillAddedCell => CommonDriver.driver.FindElement(By.XPath("(//div[text()='Do you have any skills?']/parent::div/following-sibling::div//table/tbody)[last()]//td[1]"));
        private static IWebElement NewSkillLevelAddedCell => CommonDriver.driver.FindElement(By.XPath("(//div[text()='Do you have any skills?']/parent::div/following-sibling::div//table/tbody)[last()]//td[2]"));
        private static IWebElement UpdateSkillIconButton => CommonDriver.driver.FindElement(By.XPath("(//div[text()='Do you have any skills?']/parent::div/following-sibling::div//table/tbody)[last()]//td[3]/descendant::i[1]"));
        private static IWebElement UpdateButton => CommonDriver.driver.FindElement(By.XPath("//*[@value='Update']"));
        private static IWebElement UpdatedSkillCell => CommonDriver.driver.FindElement(By.XPath("(//div[text()='Do you have any skills?']/parent::div/following-sibling::div//table/tbody)[last()]//td[1]"));
        private static IWebElement UpdatedSkillLevelCell => CommonDriver.driver.FindElement(By.XPath("(//div[text()='Do you have any skills?']/parent::div/following-sibling::div//table/tbody)[last()]//td[2]"));
        private static IWebElement CancelButton => CommonDriver.driver.FindElement(By.XPath("//*[@value='Cancel']"));
        private static IWebElement AddNewLanguageButton => CommonDriver.driver.FindElement(By.XPath("//*[text()='Language']/following-sibling::th[2]/div"));
        private static IWebElement LanguageTextBox => CommonDriver.driver.FindElement(By.XPath("//*[@placeholder='Add Language']"));
        private static IWebElement LanguageLevelDropDown => CommonDriver.driver.FindElement(By.XPath("//select[@class='ui dropdown']"));
        private static IWebElement NewLanguageAddedCell => CommonDriver.driver.FindElement(By.XPath("//th[text()='Language']//ancestor::thead/following-sibling::tbody[last()]/descendant::td[1]"));
        private static IWebElement NewLanguageLevelAddedCell => CommonDriver.driver.FindElement(By.XPath("//th[text()='Language']//ancestor::thead/following-sibling::tbody[last()]/descendant::td[2]"));
        private static IWebElement UpdateLanguageIconButton => CommonDriver.driver.FindElement(By.XPath("//th[text()='Language']//ancestor::thead/following-sibling::tbody[last()]/tr/td[3]/span[1]/i"));
        private static IWebElement UpdatedLanguageCell => CommonDriver.driver.FindElement(By.XPath("//th[text()='Language']//ancestor::thead/following-sibling::tbody[last()]/descendant::td[1]"));
        private static IWebElement UpdatedLanguageLevelCell => CommonDriver.driver.FindElement(By.XPath("//th[text()='Language']//ancestor::thead/following-sibling::tbody[last()]/descendant::td[2]"));
        private static IWebElement Message => CommonDriver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        public static void AddLanguage(string language, string languageLevel)
        {
            //-----------Adding a language------------
            
            Thread.Sleep(3000);

            //Click on "Add New" button            
            AddNewLanguageButton.Click();

            //Enter language and select language level
            LanguageTextBox.SendKeys(language);

            SelectElement languageLevelOption = new SelectElement(LanguageLevelDropDown);
            languageLevelOption.SelectByText(languageLevel);

            //Click on "Add" button.
            AddButton.Click();
            Thread.Sleep(2000);
        }
        public static string GetLanguage()
        {
            //Return new added langauge
            return NewLanguageAddedCell.Text;
        }
        public static string GetLanguageLevel()
        {
            //Return new added langauge level
            return NewLanguageLevelAddedCell.Text;
        }
        public static void UpdateLanguage(string language, string languageLevel)
        {
            //---------updating a Language-----;

            Thread.Sleep(3000);

            //Click on edit icon button 
            UpdateLanguageIconButton.Click();

            //Change the language  and language  level.
            LanguageTextBox.Clear();
            LanguageTextBox.SendKeys(language);

            SelectElement editSkillLevelOption = new SelectElement(LanguageLevelDropDown);
            editSkillLevelOption.SelectByText(languageLevel);

            //Click on "Update" button.            
            UpdateButton.Click();
            Thread.Sleep(2000);
        }
        public static string GetUpdatedLanguage()
        {
            //Return updated language
            return UpdatedLanguageCell.Text;
        }
        public static string GetUpdatedLanguageLevel()
        {
            //Return updated language level
            return UpdatedLanguageLevelCell.Text;
        }
        public static void DeleteLanguage(string language)
        {
            //---Deleting a language-----
            Thread.Sleep(2000);

            //Click on delete icon button of  desired record.
            IWebElement languageDeleteIcon = CommonDriver.driver.FindElement(By.XPath("//td[text()='" + language + "']/following-sibling::td/span[2]/i"));
            languageDeleteIcon.Click();
            Thread.Sleep(2000);
        }
        public static string GetDeleteLanguageResult(string language)
        {
            //Return language deleted result
            var deleteIconList = CommonDriver.driver.FindElements(By.XPath("//td[text()='" + language + "']"));
            string result;
            if (deleteIconList.Count == 0)
            {
                result = "Deleted";
                return result;
            }
            else
            {
                result = "Not deleted";
                return result;
            }
        }
        public static void CancelLanguageAddition(string language, string languageLevel)
        {
            //----Cancel adding a language-----------

            Thread.Sleep(2000);

            //Click on "Add New" button
            AddNewLanguageButton.Click();

            //Enter language and select language level
            LanguageTextBox.SendKeys(language);

            SelectElement languageLevelOption = new SelectElement(LanguageLevelDropDown);
            languageLevelOption.SelectByText(languageLevel);

            //Click on "Cancel" button
            CancelButton.Click();
            Thread.Sleep(1000);
        }
        public static void CancelLanguageUpdation(string language, string languageLevel)
        {
            //--------Cancel updating a language--------
            Thread.Sleep(2000);

            //Click on edit icon button of desired record
            UpdateLanguageIconButton.Click();

            //Change the language  and language  level.
            LanguageTextBox.Clear();
            LanguageTextBox.SendKeys(language);

            SelectElement editSkillLevelOption = new SelectElement(LanguageLevelDropDown);
            editSkillLevelOption.SelectByText(languageLevel);

            //Click on "Cancel" button.            
            CancelButton.Click();
            Thread.Sleep(2000);
        }
        public static void AddSkill(string skill, string skillLevel)
        {
            //----Adding Skill------------

            Thread.Sleep(2000);

            //Click on "Skills" tab.
            SkillTab.Click();

            //Click on "Add New" button.
            AddNewSkillButton.Click();

            //Enter skill and select skill level
            SkillTextBox.SendKeys(skill);

            SelectElement skillLevelOption = new SelectElement(SkillLevelDropDown);
            skillLevelOption.SelectByText(skillLevel);

            //Click on "Add" button.
            AddButton.Click();
            Thread.Sleep(2000);
        }
        public static string GetSkill()
        {
            //Return new added skill
            return NewSkillAddedCell.Text;
        }
        public static string GetSkillLevel()
        {
            //Return new added skill level
            return NewSkillLevelAddedCell.Text;
        }
        public static void UpdateSkill(string skill, string skillLevel)
        {
            //-----------Updating a Skill--------

            Thread.Sleep(2000);

            //Click on "Skills" tab.       
            SkillTab.Click();

            //Click on edit icon button of  desired record.
            UpdateSkillIconButton.Click();

            //Change the skill and skill  level.
            SkillTextBox.Clear();
            SkillTextBox.SendKeys(skill);

            SelectElement skillLevelOption = new SelectElement(SkillLevelDropDown);
            skillLevelOption.SelectByText(skillLevel);

            //Click on "Update" button
            UpdateButton.Click();
            Thread.Sleep(2000);
        }
        public static string GetUpdatedSkill()
        {
            //Return updated skill
            return UpdatedSkillCell.Text;
        }
        public static string GetUpdatedSkillLevel()
        {
            //Return updated skill level
            return UpdatedSkillLevelCell.Text;
        }
        public static void DeleteSkill(string skill)
        {
            //---Deleting a skill-----
            Thread.Sleep(2000);
            //Click on "Skills" tab.
            SkillTab.Click();

            //Click on delete icon button of  desired record.
            IWebElement skillDeleteIcon = CommonDriver.driver.FindElement(By.XPath("//td[text()='" + skill + "']/following-sibling::td/span[2]/i"));
            skillDeleteIcon.Click();
            Thread.Sleep(2000);
        }
        public static string GetDeleteSKillResult(string skill)
        {
            //Return language deleted result
            var deleteIconList = CommonDriver.driver.FindElements(By.XPath("//td[text()='" + skill + "']"));
            string result;
            if (deleteIconList.Count == 0)
            {
                result = "Deleted";
                return result;
            }
            else
            {
                result = "Not deleted";
                return result;
            }
        }

        public static void CancelSkillAddition(string skill, string skillLevel)
        {
            //----Cancel adding skill------------

            Thread.Sleep(2000);

            //Click on "Skills" tab.
            SkillTab.Click();

            //Click on "Add New" button.
            AddNewSkillButton.Click();

            //Enter skill and select skill level.
            SkillTextBox.SendKeys(skill);

            SelectElement skillLevelOption = new SelectElement(SkillLevelDropDown);
            skillLevelOption.SelectByText(skillLevel);

            //Click on "Cancel" button
            CancelButton.Click();
            Thread.Sleep(2000);
        }
        public static void CancelSkillUpdation(string skill, string skillLevel)
        {
            //--------Cancel updating a Skill-------

            Thread.Sleep(2000);
            //Click on "Skills" tab.       
            SkillTab.Click();

            //Click on "Edit icon" button of  desired record.
            UpdateSkillIconButton.Click();

            //Change the skill and skill  level.
            SkillTextBox.Clear();
            SkillTextBox.SendKeys(skill);

            SelectElement updateSkillLevelOption = new SelectElement(SkillLevelDropDown);
            updateSkillLevelOption.SelectByText(skillLevel);

            //Click on Cancel button.
            CancelButton.Click();
            Thread.Sleep(2000);
        }

        public static string GetMessage()
        {
            //Returning error or success message
            return Message.Text;
        }
    }
}

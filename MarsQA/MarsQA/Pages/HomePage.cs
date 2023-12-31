﻿using MarsQA.Data;
using MarsQA.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA.Pages
{
    public class HomePage
    {
        private static IWebElement SignInButton = CommonDriver.driver.FindElement(By.XPath("//*[text()='Sign In']"));
        private static IWebElement EmailTextbox => CommonDriver.driver.FindElement(By.XPath("//*[@placeholder='Email address']"));
        private static IWebElement PasswordTextbox => CommonDriver.driver.FindElement(By.XPath("//*[@placeholder='Password']"));
        private static IWebElement LoginButton => CommonDriver.driver.FindElement(By.XPath("//*[text()='Login']"));
        private static IWebElement UserNameLable => CommonDriver.driver.FindElement(By.XPath("//a[text()=' Chat']/following-sibling::span"));
        private static IWebElement JoinButton => CommonDriver.driver.FindElement(By.XPath("//button[text()='Join']"));
        private static IWebElement FirstNameTextbox => CommonDriver.driver.FindElement(By.XPath("//input[@placeholder='First name']"));
        private static IWebElement LastNameTextbox => CommonDriver.driver.FindElement(By.XPath("//input[@placeholder='Last name']"));
        private static IWebElement ConfirmPasswordTextbox => CommonDriver.driver.FindElement(By.XPath("//input[@placeholder='Confirm Password']"));
        private static IWebElement Checkbox => CommonDriver.driver.FindElement(By.XPath("//input[@type='checkbox']"));
        private static IWebElement FinalJoinButton => CommonDriver.driver.FindElement(By.XPath("//*[@id='submit-btn']"));
        private static IWebElement RegisterationMessage => CommonDriver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        public static void Login()
        {
            //------Signing in into Mars--------

            //Click on "Sign In" button
            Wait.WaitToBeClickable(CommonDriver.driver, "XPath", "//*[text()='Sign In']", 4);
            try
            {
                SignInButton.Click();
            }
            catch (Exception ex)
            {
                SignInButton = CommonDriver.driver.FindElement(By.XPath("//*[text()='Sign In']"));
                SignInButton.Click();
            }

            //Enter the valid email address and password.
            EmailTextbox.SendKeys(UserInformation.EmailAddress);
            PasswordTextbox.SendKeys(UserInformation.Password);

            //Click on "Login" button
            LoginButton.Click();
        }
        public static string GetUserName()
        {
            //Return username
            Wait.WaitToExist(CommonDriver.driver, "XPath", "//a[text()=' Chat']/following-sibling::span", 3);
            return UserNameLable.Text;
        }
        public static void Registration()
        {
            //--------Registering into Mars--------

            //Click on "Join" button.
            Wait.WaitToBeClickable(CommonDriver.driver, "XPath", "//button[text()='Join']", 4);
            JoinButton.Click();

            //Enter new user information
            FirstNameTextbox.SendKeys(UserInformation.FirstName);
            LastNameTextbox.SendKeys(UserInformation.LastName);
            EmailTextbox.SendKeys(UserInformation.EmailAddress);
            PasswordTextbox.SendKeys(UserInformation.Password);
            ConfirmPasswordTextbox.SendKeys(UserInformation.ConfirmPassword);
            Checkbox.Click();
            FinalJoinButton.Click();
        }
        public static string GetRegistrationMessage()
        {
            //return registration message
            Wait.WaitToExist(CommonDriver.driver, "XPath", "//div[@class='ns-box-inner']", 6);
            return RegisterationMessage.Text;
        }

    }
}

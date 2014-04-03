﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using TestingProject.Framework;

namespace TestingProject.Pages
{
    public class LoginPage : BaseObject
    {
        [FindsBy(How = How.XPath, Using = USER_NAME_TEXT_FIELD)]
        public IWebElement userNameTextField;

        [FindsBy(How = How.XPath, Using = PASSWORD_TEXT_FIELD)]
        public IWebElement passwordTextField;

        [FindsBy(How = How.XPath, Using = LOGIN_BUTTON)]
        public IWebElement loginButton;

        public static LoginPage GetLoginPage()
        {
            LoginPage loginPage = new LoginPage();
            InitPage(loginPage, loginPage.baseUrl);
            return loginPage;
        }

        public LoginPage TypeUserName(string userName)
        {
            userNameTextField.SendKeys(userName);
            return GetLoginPage();
        }

        public LoginPage TypePassword(string password)
        {
            passwordTextField.SendKeys(password);

            return GetLoginPage();
        }

        public LandingPage ClickLoginButton()
        {
            loginButton.Click();
            return LandingPage.GetLandingPage();
        }

        public const string USER_NAME_TEXT_FIELD = "//input[@id='username']";
        public const string PASSWORD_TEXT_FIELD = "//input[@id='password']";
        public const string LOGIN_BUTTON = "//label[@id='loginbutton']/input";

        public string baseUrl = Utils.baseUrl + "/login";
    }
}

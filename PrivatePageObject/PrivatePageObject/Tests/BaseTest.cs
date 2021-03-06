﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using Selenium;
using OpenQA.Selenium.Remote;
using TestingProject.Framework;

namespace TestingProject
{
    public class BaseTest : BaseObject
    {
        [TestFixtureSetUp]
        public void beforeClass()
        {
            Driver = new FirefoxDriver();
            //Selenium = new WebDriverBackedSelenium(Driver, Utils.baseUrl);
            //Selenium.Start();
            //Selenium.WindowMaximize();
            Console.WriteLine("start browser!!!!");
        }

        [SetUp]
        public void beforeTest(string url)
        {
            Driver.Navigate().GoToUrl(url);
            Console.WriteLine("go to page");
        }

        [TestFixtureTearDown]
        public void afterClass()
        {
            Driver.Close();
            Selenium.Close();
        }        
    }
}

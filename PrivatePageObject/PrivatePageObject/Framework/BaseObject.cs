using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestingProject.Framework
{
    public class BaseObject
    {
        public static RemoteWebDriver Driver;
        public static DefaultSelenium Selenium;
        public static BaseTest preinstall = new BaseTest();

        public static void InitPage<T>(T pageClass, string url) where T : BaseObject
        {
            PageFactory.InitElements(Driver, pageClass);
            preinstall.beforeClass();
            preinstall.beforeTest(url);
        }

        public static void ClearingPage()
        {
            preinstall.afterClass();
        }
    }
}

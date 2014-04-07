using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;     // It added for hover links and buttons (08.06.2013 13:08)
using OpenQA.Selenium.Interactions.Internal;   // It added for hover links and buttons (08.06.2013 13:08)
using System.Xml.Linq;  // add it for xml parser (04.06  22:39)
using System.Xml;



namespace ClassLibrary1
{
    public class TestFramework
    {
        static RemoteWebDriver _WebDriver;
        public static string baseUrl = "https://stack1.overnightprints.com";

        public static RemoteWebDriver WebDriver
        {
            get
            {
                if (_WebDriver == null)
                {
                    _WebDriver = new FirefoxDriver();
                    WriteLog.WriteLogToFile("Open Firefox", true);
                }

                return _WebDriver;
            }
        }

        public static void OpenBrowser(string url) // function just open browser and use new FF driver (11:32 26.06)
        {
            _WebDriver = new FirefoxDriver();
            url = baseUrl + url;

            WebDriver.Manage().Window.Maximize();
            WriteLog.WriteLogToFile("Open Firefox", true);
            WebDriver.Navigate().GoToUrl(url);
            WriteLog.WriteLogToFile("Go to " + url + "page", true);
        }
        
        public static void CloseBrowser()               // This Function close coonection and turn off webdriver + browser (15:25 25.06.)  
        {
            WebDriver.Quit();
            WriteLog.WriteLogToFile("Closing the connection... Closing the browser.", true);
        }

        public static IWebElement FindElement(WebItem webItem)
            {
                int timeoutInSeconds = 10; // always use 10 second wait

                if (webItem.xPath != "")
                {
                    var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));

                    try
                    {
                        return wait.Until<IWebElement>((d) =>
                    {
                            return d.FindElement(By.XPath(webItem.xPath));

                    });
                    }
                    catch (WebDriverTimeoutException e)
                    {
                        WriteLog.WriteLogToFile("Exception: WebDriverTimeoutException ", false);
                        return null;
                    }
                }
                return null;
            }
    }

    public class WebItem  // Next step : We'll create test class WebItem, which help us with page's elements (Abdulin R.M. 22.00 28.05.2013)
    {
        public string ID;
        public string Name;
        public string xPath;

        public WebItem(string xPath)
        {
            this.xPath = xPath;
        }

        public void Click()
        {
            WriteLog.WriteLogToFile("Click on finding element with xPath:" + this.xPath, true);
            TestFramework.FindElement(this).Click();
        }

        public void SetValue(string Value)
        {
            TestFramework.FindElement(this).SendKeys(Value);
        }

        public void Hover()             // This function move to element and hover on this one (Adbulin 11:30 18.06.2013)
        {
            Actions builder = new OpenQA.Selenium.Interactions.Actions(TestFramework.WebDriver); // Edited 19:21 24.06
            IWebElement hoverElement = TestFramework.FindElement(this);
            builder.MoveToElement(hoverElement).Perform();
            WriteLog.WriteLogToFile("Hovering ..... next - a little delay (1 second)", true);
        }
    }
}


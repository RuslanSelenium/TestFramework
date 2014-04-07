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

        public static IWebElement FindElementByParameter(WebItem webItem)
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

    public class XmlWork  // This class was created for some options with XML file (04.06 22:45)
    {
        public static string XmlParseMajorCriteria(string filename, string criteria)   // This function takes a Main Tag of XML (04.06 22:45) (Edited 08.06 1:12)
        {
            XDocument doc = XDocument.Load(filename);  // need to add try catch for filename
            IEnumerable<XNode> dnas =
                from node in doc.DescendantNodes()
                select node;
            foreach (XNode node in dnas)
            {
                if ((node is XElement) && ((node as XElement).Name == criteria))
                {
                    return (node as XElement).Value;
                }
            }
            return ("Element " + "<" + criteria + ">" + " not found");
        }
    }
    
    public class WriteLog // This class was created for write some records in Log file (24.06. 17:30)
    {
        public static string ResultPath = XmlWork.XmlParseMajorCriteria("parameters.xml", "Result");

        public static void ClearLog(string fileTag)
        {
            string fileName = XmlWork.XmlParseMajorCriteria("parameters.xml", fileTag);
            System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, false);
            file.Write("");
            file.Close();

        }
        public static void WriteLogToFile(string line, Boolean flag)
        {
            string TClog = XmlWork.XmlParseMajorCriteria("parameters.xml", "TCLog"); // added for load path from parameters.xml
            string Errlog = XmlWork.XmlParseMajorCriteria("parameters.xml", "ErrLog");
            DateTime date = DateTime.UtcNow;
            DateTime dateOnly = date;//.Date;
            string dateString = dateOnly.ToString("MM/dd/yyyy HH:mm");
            System.IO.StreamWriter fileError = new System.IO.StreamWriter(Errlog, true);
            System.IO.StreamWriter fileTC = new System.IO.StreamWriter(TClog, true);
            if (flag == true)
                fileTC.WriteLine(dateString + ": " + line);
            else
                fileError.WriteLine(dateString + ": " + line);
            fileError.Close();
            fileTC.Close(); 
        }

        public static void WriteResult(string line) // This function was created for result logs (20:52 25.06)
        {
            DateTime date = DateTime.UtcNow;
            string dateString = date.ToString("MM/dd/yyyy HH:mm");
            System.IO.StreamWriter ResultFile = new System.IO.StreamWriter(ResultPath, true);
            ResultFile.WriteLine(dateString + ": " + line);
            ResultFile.Close();
        }

        public static string[] ReadResult()
        {
            System.IO.StreamReader ResultFile = new System.IO.StreamReader(ResultPath, true);
            int i = 0;
            string line;
            string[] lineArray = new string[50];// = { "asd", "asdasd" };
            while ((line = ResultFile.ReadLine()) != null)
            {
                lineArray[i] = line;
                i = i + 1;
            }
            return lineArray;
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
            TestFramework.FindElementByParameter(this).Click();
        }

        public void SetValue(string Value)
        {
            TestFramework.FindElementByParameter(this).SendKeys(Value);
        }

        public void Hover()             // This function move to element and hover on this one (Adbulin 11:30 18.06.2013)
        {
            Actions builder = new OpenQA.Selenium.Interactions.Actions(TestFramework.WebDriver); // Edited 19:21 24.06
            IWebElement hoverElement = TestFramework.FindElementByParameter(this);
            builder.MoveToElement(hoverElement).Perform();
            WriteLog.WriteLogToFile("Hovering ..... next - a little delay (1 second)", true);
        }
    }

    public class LoginAction  // Create LoginAction which do something for Log-in (Abdulin R.M. 22.30 28.05.2013)
    {
        public static void DoLogin()
        {
            string loginFile = XmlWork.XmlParseMajorCriteria("parameters.xml", "login");
            LoginWebItems.UserNameTextBox.SetValue(ClassLibrary1.XmlWork.XmlParseMajorCriteria(loginFile, "login_name"));
            LoginWebItems.PasswordTextBox.SetValue(ClassLibrary1.XmlWork.XmlParseMajorCriteria(loginFile, "login_password"));
            LoginWebItems.LoginButton.Click();

            //TestFramework.Delay();
        }
    }
}


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

        public static void OpenBrowser() // function just open browser and use new FF driver (11:32 26.06)
        {
            _WebDriver = new FirefoxDriver();
            WriteLog.WriteLogToFile("Open Firefox", true);
        }
        
        public static void CloseBrowser()               // This Function close coonection and turn off webdriver + browser (15:25 25.06.)  
        {
            WebDriver.Quit();
        }

        public static void OpenURL(string URL)
        {
            WebDriver.Navigate().GoToUrl(URL);
        }


       
            public static IWebElement FindElementByParameter(/*this IWebDriver driver,*/ WebItem webItem)
            {
                int timeoutInSeconds = 3; // always use 1 second wait
                
                if (webItem.ID != "") 
                {
                    var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
                    return wait.Until<IWebElement>((d) =>
                        {
                            return d.FindElement(By.Id(webItem.ID));
                        });
                }

                //if (webItem.Name != "")   // was commented cause it should be parameter name store name of webitem, not "name = smtg" of page element
                //{
                //    var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
                //    return wait.Until<IWebElement>((d) =>
                //    {
                //        return d.FindElement(By.Name(webItem.Name));
                //    });
                //}

                if (webItem.XPathQuery != "")
                {
                    var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));

                    try
                    {
                        return wait.Until<IWebElement>((d) =>
                    {
                            return d.FindElement(By.XPath(webItem.XPathQuery));

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
        
        //public static IWebElement FindWebElement(WebItem webItem) //This part of code must be commented, cause we add Wait method
        //{
        //    if (webItem.ID != "")
        //        return WebDriver.FindElementById(webItem.ID);

        //    if (webItem.Name != "")
        //        return WebDriver.FindElementByName(webItem.Name);

        //    if (webItem.XPathQuery != "")
        //        return WebDriver.FindElementByXPath(webItem.XPathQuery);

        //    return null;
        //}

        public static void Delay(int Seconds = 10)
        {
            System.Threading.Thread.Sleep(Seconds * 1000);
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

    public class VerifyClass  // This class was created for store verify methods (25.06 12:09)
    {
        public static string loginFile = XmlWork.XmlParseMajorCriteria("parameters.xml", "login");

        public static bool VerifyLoginText(string loginText)            // Function verify text on page after user logged with text on xml file (25.06 12:09)
        {
            if (loginText != XmlWork.XmlParseMajorCriteria(loginFile, "name"))
                return false;
            else
                return true;
        }

        public static bool VerifyElementDisplayed(WebItem webitem)      // Function verify element enabled or not (11:52 27.06)
        {
            IWebElement element = TestFramework.FindElementByParameter(webitem);
            if (element != null)
            {
                WriteLog.WriteResult("Verification successful : " + webitem.Name);
                return true;
            }
            else
            {
                WriteLog.WriteResult("Verification failed : " + webitem.Name);
                return false;
            }
        }
    }

    public class WebItem  // Next step : We'll create test class WebItem, which help us with page's elements (Abdulin R.M. 22.00 28.05.2013)
    {
        public string ID;
        public string Name;
        public string XPathQuery;

        public WebItem(string ID, string Name, string XPathQuery)
        {
            this.ID = ID;
            this.Name = Name;  // All elements ClassName was changed by Name (23:49 28.05.2013)
            this.XPathQuery = XPathQuery;
        }

        public void Click()
        {
            //TestFramework.FindWebElement(this).Click();
            TestFramework.FindElementByParameter(this).Click();
            WriteLog.WriteLogToFile("Click on finding element", true);
        }

        public void SetValue(string Value)
        {
            //TestFramework.FindWebElement(this).SendKeys(Value);
            TestFramework.FindElementByParameter(this).SendKeys(Value);
        }

        public void Hover()             // This function move to element and hover on this one (Adbulin 11:30 18.06.2013)
        {
            Actions builder = new OpenQA.Selenium.Interactions.Actions(TestFramework.WebDriver); // Edited 19:21 24.06
            IWebElement hoverElement = TestFramework.FindElementByParameter(this);
            builder.MoveToElement(hoverElement).Perform();
            WriteLog.WriteLogToFile("Hovering ..... next - a little delay (1 second)", true);
            TestFramework.Delay(1);
        }

        public string TakeElementText()          // Function return elements text
        {
            try
            {
                IWebElement element = TestFramework.FindElementByParameter(this);
                return element.Text;
            }
            catch (Exception e)
            {
                WriteLog.WriteLogToFile("Exception : " + e, false);
            }
            return "";
        }

        public static void ChooseDropDownMenuOption(string elementPosition)
        {
            System.Threading.Thread.Sleep(2000);
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> collectionSelector;
            collectionSelector = TestFramework.WebDriver.FindElementsByClassName("sbSelector");
            IWebElement[] elementArray = new IWebElement[5];
            collectionSelector.CopyTo(elementArray, 0);
            elementArray[1].Click();

            System.Threading.Thread.Sleep(2000);

            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> collectionOptoins;
            collectionOptoins = TestFramework.WebDriver.FindElementsByClassName("sbOptions");
            IWebElement[] elementArrayOptions = new IWebElement[5];
            collectionOptoins.CopyTo(elementArrayOptions, 0);

            string elementId = elementArrayOptions[1].GetAttribute("id");
            string elementXPath = ".//*[@id='" + elementId + "']/li[" + elementPosition + "]/a";
            TestFramework.WebDriver.FindElementByXPath(elementXPath).Click();

        }

        //public static void UseFile(string path)
        //{
        //    TestFramework.FindElementByParameter(this).SendKeys("path");
        //}

    }

    public static class LoginWebItems   // Well, lets create new class LoginWebItems, which contain elements for Login Form (Abdulin R.M. 22.20 28.05.2013)
    {
        public static WebItem LoginLink
        {
            get
            {
                return new WebItem("", "", "");  // don't finish yet
            }
        }

        public static WebItem UserNameTextBox
        {
            get
            {
                return new WebItem("", "", ".//*[@id='username']");
            }
        }

        public static WebItem PasswordTextBox
        {
            get
            {
                return new WebItem("", "", ".//*[@id='password']");
            }
        }

        public static WebItem LoginButton
        {
            get
            {
                return new WebItem("", "", ".//*[@id='_submit']");
            }
        }


        public static WebItem BC_chosen
        {
            get
            {
                return new WebItem("", "", ".//*[@id='products-menu']/div[1]/ul[1]/li[6]/a");
            }
        }
        public static WebItem AllProductsSpan
        {
            get
            {
                return new WebItem("", "", ".//*[@id='products-btn']");
            }
        }
        public static WebItem ForgetPassword
        {
            get
            {
                return new WebItem("", "", ".//*[@id='body-main']/div/div/div/div/div[2]/div[3]/div/div[1]/form/div/p[2]/a");
            }
        }
        public static WebItem LoggedGreetings
        {
            get
            {
                return new WebItem("", "", ".//*[@id='main-nav']/li[1]/span");
            }
        }
    }

    public static class ProductWebItems // this class was created for store info  about elements of Product Page (11:57 26.06 )
    {
        public static WebItem UploadDesignButton
        {
            get
            {
                return new WebItem("", "", ".//*[@id='designer-upload']/div[1]/a");
            }
        }
    }

    public static class UploaderWebItems // this class was created for store info  about elements of Uploader Page (12:02 26.06 )
    {
        public static WebItem AddImageButton
        {
            get
            {
                return new WebItem("sliceimage", "", "");
            }
        }

        public static WebItem SelectFileFieldFront
        {
            get
            {
                return new WebItem("fileSelect_file_1", "SelectFileField for Front Image", ".//*[@id='designer-upload']/div[1]/a");
            }
        }

        public static WebItem SelectFileFieldBack
        {
            get
            {
                return new WebItem("fileSelect_file_2", "SelectFileField for Back Image", ".//*[@id='designer-upload']/div[1]/a");
            }
        }

        public static WebItem SelectFileLinkFront
        {
            get
            {
                return new WebItem("noFlashToggle_1", "SelectFile link for Front Image", ".//*[@id='designer-upload']/div[1]/a");
            }
        }

        public static WebItem SelectFileLinkBack
        {
            get
            {
                return new WebItem("noFlashToggle_2", "SelectFile link for Back Image", ".//*[@id='designer-upload']/div[1]/a");
            }
        }

        public static WebItem FrontImage
        {
            get
            {
                return new WebItem("", "Front image (Uploader)", ".//*[@id='product_front_uid']/img");
            }
        }

        public static WebItem BackImage
        {
            get
            {
                return new WebItem("", "Back image (Uploader)", ".//*[@id='product_back_uid']/img");
            }
        }

        public static WebItem ContinueButton
        {
            get
            {
                return new WebItem("", "Continue button", ".//*[@id='body-main']/div/div/div/div/div[2]/div[4]/div[2]/form/button");
            }
        }
    }

    public static class ApprovalWebItems // this class was created for store info  about elements of Uploader Page (14:39 27.06 )
    {
        public static WebItem RadioFullUVFront
        {
            get
            {
                return new WebItem("front_full_uv", "Radio button - Full UV Front", ".//*[@id='front_full_uv']");
            }
        }

        public static WebItem RadioFullUVBack
        {
            get
            {
                return new WebItem("back_full_uv", "Radio button - Full UV Back", ".//*[@id='back_full_uv']");
            }
        }

        public static WebItem CheckBoxRoundedCorners
        {
            get
            {
                return new WebItem("rounded_corners", "Checkbox - rounded corners", ".//*[@id='rounded_corners']");
            }
        }

    }

    public class PagesActions   // Create PageActions clss, which will do some actions for open pages of our website. We should miss hardcode (Abdulin R.M. 22.25 28.05.2013)
    {
        public static void OpenHomePage()
        {
            TestFramework.WebDriver.Manage().Window.Maximize();
            TestFramework.OpenURL("https://www.overnightprints.com/");
            WriteLog.WriteLogToFile("Go to Home page", true);
        }
        
        public static void OpenLoginPage()              // This function open LogIn page (11:52 18.06.2013)
        {
            TestFramework.WebDriver.Manage().Window.Maximize();
            TestFramework.OpenURL("https://www.overnightprints.com/login");
            WriteLog.WriteLogToFile("Go to Login page", true);
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

            TestFramework.Delay();
        }
    }

    public class TestCases    // Create Test Case class for test cases functons
         {
             public static int total = 0;

             public static int count = 0;

             public static void Login_TC()
             {
                 WriteLog.WriteLogToFile("<-------------------------------Test Case starting ------------------------------->", true);
                 PagesActions.OpenLoginPage();
                 LoginAction.DoLogin();
                 if (VerifyClass.VerifyLoginText(LoginWebItems.LoggedGreetings.TakeElementText()) == true)
                 {
                     count++;
                     total++;
                     WriteLog.WriteResult(total.ToString() + " : " + "Verification successful");
                 }
                 else
                 {
                     total++;
                     WriteLog.WriteResult(total.ToString() + " : " + "Verification failed");
                 }
                 TestFramework.CloseBrowser();
                 WriteLog.WriteLogToFile("<-------------------------------Test Case ending ------------------------------->", true);
             }

             public static void Product_TC()
             {
                 WriteLog.WriteLogToFile("<-------------------------------Test Case starting ------------------------------->", true);
                 PagesActions.OpenHomePage();
                 LoginWebItems.AllProductsSpan.Hover();
                 LoginWebItems.BC_chosen.Click();
                 WriteLog.WriteLogToFile("<-------------------------------Test Case ending ------------------------------->", true);
             }

             public static void TestForNewFunctions()
             {
                 WriteLog.WriteLogToFile("<-------------------------------Test Case starting ------------------------------->", true);
                 WriteLog.ClearLog("Result");
                 PagesActions.OpenHomePage();
                 LoginWebItems.AllProductsSpan.Hover();
                 LoginWebItems.BC_chosen.Click();
                 ProductWebItems.UploadDesignButton.Click();
                 UploaderWebItems.SelectFileLinkFront.Click();
                 UploaderWebItems.SelectFileFieldFront.SetValue(@"E:\images\1.jpg");
                 System.Threading.Thread.Sleep(4000);
                 VerifyClass.VerifyElementDisplayed(UploaderWebItems.FrontImage);
                 UploaderWebItems.SelectFileLinkBack.Click();
                 UploaderWebItems.SelectFileFieldBack.SetValue(@"E:\images\2.jpg");
                 System.Threading.Thread.Sleep(4000);
                 VerifyClass.VerifyElementDisplayed(UploaderWebItems.BackImage);
                 UploaderWebItems.ContinueButton.Click();
                 ApprovalWebItems.RadioFullUVBack.Click();
                 ApprovalWebItems.RadioFullUVFront.Click();
                 ApprovalWebItems.CheckBoxRoundedCorners.Click();
                 WebItem.ChooseDropDownMenuOption("8");
                 System.Threading.Thread.Sleep(4000);


                 TestFramework.CloseBrowser();
                 WriteLog.WriteLogToFile("Browser closed", true);
                 WriteLog.WriteLogToFile("<-------------------------------Test Case ending ------------------------------->", true);
             }
         }
    
}


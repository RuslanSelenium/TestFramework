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
        public static string baseUrl = "https://www.overnightprints.com";

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

        public static void OpenPage(string url)
        {
            TestFramework.WebDriver.Manage().Window.Maximize();
            url = baseUrl + url;
            TestFramework.OpenURL("url");
            WriteLog.WriteLogToFile("Go to Home page", true);
        }
		///Открывает ссылку
        public static void OpenURL(string URL)
        {
            WebDriver.Navigate().GoToUrl(URL);
        }
  
        public static IWebElement FindElementByParameter(WebItem webItem)
            {
                int timeoutInSeconds = 10; // always use 1 second wait

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

        //public static void Delay(int Seconds = 10)
        //{
        //    System.Threading.Thread.Sleep(Seconds * 1000);
        //}

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
        public static string FindPricePosition(Product product)  // this function finds from table of prices some price and returns position on DD menu
        {
            string PricePath = @"E:\products\" + product.ProductType + ".txt";
            System.IO.StreamReader PriceFile = new System.IO.StreamReader(PricePath, true);
            int i = 1;
            string line;
            string[] lineArray = new string[50];// = { "asd", "asdasd" };
            while ((line = PriceFile.ReadLine()) != null)
            {
                lineArray[i] = line;
                i = i + 1;
            }

            for (i = 1; i <= lineArray.Length; i++)
            {
                if (lineArray[i] != null)
                {
                    if (lineArray[i].IndexOf(product.Quantity.ToString()) != -1)
                    {
                        return i.ToString();
                    }
                }
                else break;
            }
            return null;  // need to add exception when null comes
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

        public WebItem(/*string ID, string Name,*/ string XPathQuery)
        {
            /*this.ID = ID;
            this.Name = Name;  // All elements ClassName was changed by Name (23:49 28.05.2013)*/
            this.XPathQuery = XPathQuery;
        }

        public void Click()
        {
            //TestFramework.FindWebElement(this).Click();
            WriteLog.WriteLogToFile("Click on finding element :" + TestFramework.FindElementByParameter(this).Text, true);
            TestFramework.FindElementByParameter(this).Click();
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

        public static void ChooseDropDownMenuOption(Product product, string elementPosition)
        {            
            switch (product.MagnetsQty)
            {
                case null :
                    System.Threading.Thread.Sleep(2000);
                    System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> collectionSelector;
                    collectionSelector = TestFramework.WebDriver.FindElementsByClassName("sbSelector");
                    IWebElement[] elementArray = new IWebElement[5];
                    collectionSelector.CopyTo(elementArray, 0);
                    elementArray[0].Click();
                    
                    System.Threading.Thread.Sleep(2000);
                    
                    System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> collectionOptoins;
                    collectionOptoins = TestFramework.WebDriver.FindElementsByClassName("sbOptions");
                    IWebElement[] elementArrayOptions = new IWebElement[5];
                    collectionOptoins.CopyTo(elementArrayOptions, 0);
                    
                    string elementId = elementArrayOptions[0].GetAttribute("id");
                    string elementXPath = ".//*[@id='" + elementId + "']/li[" + elementPosition + "]/a";
                    WriteLog.WriteLogToFile("Click on finding element :" + TestFramework.WebDriver.FindElementByXPath(elementXPath).Text, true);
                    TestFramework.WebDriver.FindElementByXPath(elementXPath).Click();
                    break;
                default :
                    System.Threading.Thread.Sleep(2000);
                    System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> collectionSelectorDefault;
                    collectionSelectorDefault = TestFramework.WebDriver.FindElementsByClassName("sbSelector");
                    IWebElement[] elementArrayDefault = new IWebElement[5];
                    collectionSelectorDefault.CopyTo(elementArrayDefault, 0);
                    elementArrayDefault[1].Click();

                    System.Threading.Thread.Sleep(2000);

                    System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> collectionOptoinsDefault;
                    collectionOptoinsDefault = TestFramework.WebDriver.FindElementsByClassName("sbOptions");
                    IWebElement[] elementArrayOptionsDefault = new IWebElement[5];
                    collectionOptoinsDefault.CopyTo(elementArrayOptionsDefault, 0);

                    string elementIdDefault = elementArrayOptionsDefault[1].GetAttribute("id");
                    string elementXPathDefault = ".//*[@id='" + elementIdDefault + "']/li[" + elementPosition + "]/a";
                    WriteLog.WriteLogToFile("Click on finding element :" + TestFramework.WebDriver.FindElementByXPath(elementXPathDefault).Text, true);
                    TestFramework.WebDriver.FindElementByXPath(elementXPathDefault).Click();
                    break;
            }                       
        }

        //public static void UseFile(string path)
        //{
        //    TestFramework.FindElementByParameter(this).SendKeys("path");
        //}

    }

    public class Product  // This one was created for product object
    {
        public string ProductType; // ('BC'/'CDMagnet'/'Letterhead')
        public string ProductSize; // ('4x6'/'8.5x11') - It needs to choose radiobutton
        public string FrontOption ; // ('none'/'full'/'spot')
        public string BackOption; // ('none'/'full'/'spot')
        public ushort Quantity; // an positive count
        public Boolean RoundedCorners; // (yes/no)
        public string DeliveryType; //('Economy'/'Standart'/'Fast3D'/'Fast2D'/'Fast1D'/'BitGit')
        public string File1;  // path for file1
        public string File2;  // path for file2
        public string Designer; // 'Uploader'/'DV2'/'DaVinci'/'Express'
        public string MagnetsQty;  // 'qty'

        public Product(string ProductType, string ProductSize, string Designer, string FrontOption, string BackOption, ushort Quantity, Boolean RoundedCorners, string DeliveryType, string File1, string File2, string MagnetsQty) // Class for Product information
        {
            this.ProductType = ProductType;
            this.ProductSize = ProductSize;
            this.Designer = Designer;
            this.FrontOption = FrontOption;
            this.BackOption = BackOption;
            this.Quantity = Quantity;
            this.RoundedCorners = RoundedCorners;
            this.DeliveryType = DeliveryType;
            this.File1 = File1;
            this.File2 = File2;
        }

        public void Choose_Product() // Choose product by product type
        {
            LoginWebItems.AllProductsSpan.Hover();
            TestFramework.WebDriver.FindElementByLinkText(this.ProductType).Click();
            WriteLog.WriteLogToFile("Choose "+this.ProductType, true);
        }

        public void ChooseDesigner() // choose designer, need to be updated (add DV2, DaVinci and Express)
        {
            System.Threading.Thread.Sleep(4000);
            switch(this.Designer)
            {
                case "Uploader":
                    ProductWebItems.UploadDesignButton.Click();
                    WriteLog.WriteLogToFile("Uploader Designer was choosen", true);
                    break;
                default :
                    ProductWebItems.UploadDesignButton.Click();
                    WriteLog.WriteLogToFile("Uploader Designer was choosen by default", true);
                    break;
            }
        }
        
        public void UploadImages() // Upload Files in Uploader Designer
        {
            UploaderWebItems.SelectFileLinkFront.Click();
            UploaderWebItems.SelectFileFieldFront.SetValue(this.File1);
            WriteLog.WriteLogToFile("File : " + this.File1 + "was uploaded", true);
            TestFramework.Delay(10);
            if (this.File2 != "")
            {
                UploaderWebItems.SelectFileLinkBack.Click();
                UploaderWebItems.SelectFileFieldBack.SetValue(this.File2);
                WriteLog.WriteLogToFile("File : " + this.File2 + "was uploaded", true);
                TestFramework.Delay(5);
            }
            UploaderWebItems.ContinueButton.Click();
            // It should be Spot_UV added
        }

        public void ApprovalPage()
        {
            TestFramework.Delay(3);
            if (this.FrontOption == "full")
                ApprovalWebItems.RadioFullUVFront.Click();
            if (this.BackOption == "full")
                ApprovalWebItems.RadioFullUVBack.Click();
            if (this.RoundedCorners == true)
                ApprovalWebItems.CheckBoxRoundedCorners.Click();
            
            WebItem.ChooseDropDownMenuOption(this, WriteLog.FindPricePosition(this));
            ApprovalWebItems.ContinueButton.Click();
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
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary1;
using OpenQA.Selenium;

public class VerifyClass : TestFramework  // This class was created for store verify methods (25.06 12:09)
{
    public static void VerifyTextPresent(string text)
    {
        if (WebDriver.PageSource.Contains(text))
        {
            WriteLog.WriteLogToFile("Text \"" + text + "\" was found on the page", true);
        }
        else
        {
            WriteLog.WriteLogToFile("Warning! Text \"" + text + "\" was NOT found on the page", true);
            throw new Exception("Text \"" + text + "\" was NOT found on the page");
        }
    }

    public static void VerifyTextInTheElement(string text, WebItem webitem)            // Function verify text on page after user logged with text on xml file (25.06 12:09)
    {
        IWebElement element = TestFramework.FindElement(webitem);

        if (element.Text.Contains(text))
        {
            WriteLog.WriteLogToFile("Text \"" + text + "\" in the element with xPath : " + webitem.xPath + " was found", true);
        }
        else
        {
            WriteLog.WriteLogToFile("Warning! Text \"" + text + "\" in the element with xPath : " + webitem.xPath + " was NOT found", true);
            throw new Exception("Text \"" + text + "\" in the element with xPath : " + webitem.xPath + " was NOT found");
        }
    }

    public static void VerifyElementExists(WebItem webitem)
    {
        IWebElement element = TestFramework.FindElement(webitem);
        if (element != null)
        {
            WriteLog.WriteLogToFile("Element with xPath : " + webitem.xPath + " was found", true);
        }
        else
        {
            WriteLog.WriteLogToFile("Warning! Element with xPath : " + webitem.xPath + " was NOT found", true);
            throw new Exception("Element with xPath: " + webitem.xPath + " doesn't exist");
        }
    }

    public static void VerifyElementNotExists(WebItem webitem)
    {
        IWebElement element = TestFramework.FindElement(webitem);
        if (element == null)
        {
            WriteLog.WriteLogToFile("Success. Element with xPath : " + webitem.xPath + " was not found", true);
        }
        else
        {
            WriteLog.WriteLogToFile("Warning! Element with xPath : " + webitem.xPath + " was found", true);
            throw new Exception("Element with xPath: " + webitem.xPath + " exists, but it should not!");
        }
    }

    public static void VerifyUrl(string url)
    {
        if (WebDriver.Url == baseUrl + url)
        {
            WriteLog.WriteLogToFile("Success. We are on : " + baseUrl + url + " page", true);
        }
        else
        {
            WriteLog.WriteLogToFile("Warning! We are on : " + WebDriver.Url + " page. But should be on" + baseUrl + url + " page", true);
            throw new Exception("Warning! We are on : " + WebDriver.Url + " page. But should be on" + baseUrl + url + " page");
        }
    }
}
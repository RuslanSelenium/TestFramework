using System;
using ClassLibrary1;

public class TestCases   // Create Test Case class for test cases functons
{
    public static int total = 0;

    public static int count = 0;

    public static void TestForNewFunctions()
    {
        WriteLog.WriteLogToFile("<-------------------------------Test Case starting ------------------------------->", true);
        WriteLog.ClearLog("Result");
        //LoginWebItems.AllProductsSpan.Hover();
        //TestFramework.WebDriver.FindElementByLinkText("Letterhead").Click();
        //LoginWebItems.BC_chosen.Click();
        //ProductWebItems.UploadDesignButton.Click();
        //UploaderWebItems.SelectFileLinkFront.Click();
        //UploaderWebItems.SelectFileFieldFront.SetValue(@"E:\images\1.jpg");
        //System.Threading.Thread.Sleep(4000);
        //VerifyClass.VerifyElementDisplayed(UploaderWebItems.FrontImage);
        //UploaderWebItems.SelectFileLinkBack.Click();
        //UploaderWebItems.SelectFileFieldBack.SetValue(@"E:\images\2.jpg");
        //System.Threading.Thread.Sleep(4000);
        //VerifyClass.VerifyElementDisplayed(UploaderWebItems.BackImage);
        //UploaderWebItems.ContinueButton.Click();
        //ApprovalWebItems.RadioFullUVBack.Click();
        //ApprovalWebItems.RadioFullUVFront.Click();
        //ApprovalWebItems.CheckBoxRoundedCorners.Click();
        //WebItem.ChooseDropDownMenuOption("8");
        //TestFramework.CloseBrowser();
        System.Threading.Thread.Sleep(4000);
        WriteLog.WriteLogToFile("Browser closed", true);
        WriteLog.WriteLogToFile("<-------------------------------Test Case ending ------------------------------->", true);
    }

    public static void TestForNewFunctions2()
    {
        TestFramework.OpenBrowser("/login");
        LoginWebItems.UserNameTextBox.SetValue("ruslan.abdulin@opensoftdev.ru");
        LoginWebItems.PasswordTextBox.SelectFromMenu("123456");
        LoginWebItems.LoginButton.Click();
        VerifyClass.VerifyTextInTheElement("Ruslanko Stepanko", MainPage.linkUsename);
        TestFramework.CloseBrowser();
    }
}
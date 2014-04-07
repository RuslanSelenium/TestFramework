using System;
using ClassLibrary1;

public class TestCases    // Create Test Case class for test cases functons
{
    public static int total = 0;

    public static int count = 0;

    public static void Login_TC()
    {
        WriteLog.WriteLogToFile("<-------------------------------Test Case starting ------------------------------->", true);
        PagesActions.OpenLoginPage();
        LoginAction.DoLogin();
        ////if (VerifyClass.VerifyLoginText(LoginWebItems.LoggedGreetings.TakeElementText()) == true)
        //{
        //    count++;
        //    total++;
        //    WriteLog.WriteResult(total.ToString() + " : " + "Verification successful");
        //}
        //else
        //{
        //    total++;
        //    WriteLog.WriteResult(total.ToString() + " : " + "Verification failed");
        //}
        //TestFramework.CloseBrowser();
        WriteLog.WriteLogToFile("<-------------------------------Test Case ending ------------------------------->", true);
    }

    public static void Product_TC()
    {
        WriteLog.WriteLogToFile("<-------------------------------Test Case starting ------------------------------->", true);
        PagesActions.OpenHomePage();
       //LoginWebItems.AllProductsSpan.Hover();
        //LoginWebItems.BC_chosen.Click();
        WriteLog.WriteLogToFile("<-------------------------------Test Case ending ------------------------------->", true);
    }

    public static void TestForNewFunctions()
    {
        WriteLog.WriteLogToFile("<-------------------------------Test Case starting ------------------------------->", true);
        WriteLog.ClearLog("Result");
        PagesActions.OpenHomePage();
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

        Product product = new Product("Address Labels", "none", "Uploader", "none", "none", 1080, false, "Economy", @"E:\images\1.jpg", @"", "");
        product.Choose_Product();
        product.ChooseDesigner();
        product.UploadImages();
        product.ApprovalPage();


        //TestFramework.CloseBrowser();
        System.Threading.Thread.Sleep(4000);
        WriteLog.WriteLogToFile("Browser closed", true);
        WriteLog.WriteLogToFile("<-------------------------------Test Case ending ------------------------------->", true);
    }
}
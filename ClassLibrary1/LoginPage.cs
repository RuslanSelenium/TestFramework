using System;
using ClassLibrary1;

public class LoginWebItems : BasePage  // Well, lets create new class LoginWebItems, which contain elements for Login Form (Abdulin R.M. 22.20 28.05.2013)
{
    public static WebItem LoginLink
    {
        get
        {
            return new WebItem("");  // don't finish yet
        }
    }

    public static WebItem UserNameTextBox
    {
        get
        {
            return new WebItem(".//*[@id='username']");
        }
    }

    public static WebItem PasswordTextBox
    {
        get
        {
            return new WebItem(".//*[@id='password']");
        }
    }

    public static WebItem LoginButton
    {
        get
        {
            return new WebItem("//button[text()='Log In']");
        }
    }


    public static WebItem BC_chosen
    {
        get
        {
            return new WebItem(".//*[@id='products-menu']/div[1]/ul[1]/li[6]/a");
        }
    }
    public static WebItem AllProductsSpan
    {
        get
        {
            return new WebItem(".//*[@id='products-btn']");
        }
    }
    public static WebItem ForgetPassword
    {
        get
        {
            return new WebItem(".//*[@id='body-main']/div/div/div/div/div[2]/div[3]/div/div[1]/form/div/p[2]/a");
        }
    }
    public static WebItem LoggedGreetings
    {
        get
        {
            return new WebItem(".//*[@id='main-nav']/li[1]/span");
        }
    }
}


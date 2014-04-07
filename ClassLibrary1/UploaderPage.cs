using System;
using ClassLibrary1;

public class UploaderWebItems : BasePage  // this class was created for store info  about elements of Uploader Page (12:02 26.06 )
{  
    public static WebItem AddImageButton
    {
        get
        {
            return new WebItem("");
        }
    }

    public static WebItem SelectFileFieldFront
    {
        get
        {
            return new WebItem(".//*[@id='designer-upload']/div[1]/a");
        }
    }

    public static WebItem SelectFileFieldBack
    {
        get
        {
            return new WebItem(".//*[@id='designer-upload']/div[1]/a");
        }
    }

    public static WebItem SelectFileLinkFront
    {
        get
        {
            return new WebItem(".//*[@id='designer-upload']/div[1]/a");
        }
    }

    public static WebItem SelectFileLinkBack
    {
        get
        {
            return new WebItem(".//*[@id='designer-upload']/div[1]/a");
        }
    }

    public static WebItem FrontImage
    {
        get
        {
            return new WebItem(".//*[@id='product_front_uid']/img");
        }
    }

    public static WebItem BackImage
    {
        get
        {
            return new WebItem(".//*[@id='product_back_uid']/img");
        }
    }

    public static WebItem ContinueButton
    {
        get
        {
            return new WebItem(".//*[@id='body-main']/div/div/div/div/div[3]/div[4]/div[2]/form/button");
        }
    }
}
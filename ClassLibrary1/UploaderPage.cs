using System;
using ClassLibrary1;

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
            return new WebItem("", "Continue button", ".//*[@id='body-main']/div/div/div/div/div[3]/div[4]/div[2]/form/button");
        }
    }
}
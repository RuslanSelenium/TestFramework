using System;
using ClassLibrary1;

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

    public static WebItem ContinueButton
    {
        get
        {
            return new WebItem("", "Continue button", "//button");
        }
    }

}
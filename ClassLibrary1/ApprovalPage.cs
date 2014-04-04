using System;
using ClassLibrary1;

public class ApprovalWebItems : BasePage // this class was created for store info  about elements of Uploader Page (14:39 27.06 )
{
    public static WebItem RadioFullUVFront
    {
        get
        {
            return new WebItem(".//*[@id='front_full_uv']");
        }
    }

    public static WebItem RadioFullUVBack
    {
        get
        {
            return new WebItem(".//*[@id='back_full_uv']");
        }
    }

    public static WebItem CheckBoxRoundedCorners
    {
        get
        {
            return new WebItem(".//*[@id='rounded_corners']");
        }
    }

    public static WebItem ContinueButton
    {
        get
        {
            return new WebItem("//button");
        }
    }

}
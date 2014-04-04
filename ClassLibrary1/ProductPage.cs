using System;
using ClassLibrary1;

public static class ProductWebItems // this class was created for store info  about elements of Product Page (11:57 26.06 )
{
    public static WebItem UploadDesignButton
    {
        get
        {
            return new WebItem(".//*[@id='designer-upload']/div[1]/a");
        }
    }
}
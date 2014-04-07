using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary1;

public class MainPage : BasePage
{
    public static string baseUrl = "http://stack1.overnightprints.com";

    public static WebItem linkUsename // Кнопка по которой выпадает меню с продуктами
    {
        get
        {
            return new WebItem("//*[@class='user-name']");
        }
    }
}

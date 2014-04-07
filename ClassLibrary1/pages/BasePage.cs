using System;
using ClassLibrary1;

public class BasePage
{
    public static string baseUrl = "http://stack1.overnightprints.com";

    public static WebItem linkAllProductDDMenu // Кнопка по которой выпадает меню с продуктами
    {
        get
        {
            return new WebItem("//*[@id='products-btn']");
        }
    }
    
    public static WebItem linkLogin // Ссылка Login ведущая на страницу для авторизации
    {
        get
        {
            return new WebItem("//*[@id='main-nav']//a[text()='Login']");
        }
    }

    public static WebItem linkMyAccount // Ссылка My Account ведущая на страницу личного кабинета
    {
        get
        {
            return new WebItem("//*[@id='main-nav']//a[text()='My Account']");
        }
    }

    public static WebItem linkFAQs // Ссылка FAQs ведущая на страницу FAQ
    {
        get
        {
            return new WebItem("//*[@id='main-nav']//a[text()='FAQs']");
        }
    }
    
    public static WebItem linkCart // Ссылка Cart(x) ведущая на страницу корзины с товарами
    {
        get
        {
            return new WebItem("//a[@title='My Shopping Cart']");
        }
    }
}
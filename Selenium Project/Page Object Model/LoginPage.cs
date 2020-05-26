using Knab_Framework.Page_Object_Model;
using  OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Knab_Framework.PageObjectModel
{
    class LoginPage : Page
    {
        protected static string PageUrl = "https://trello.com/login";
        protected static string PageTitle = "login in Trello";
        public LoginPage(IWebDriver driver)
        {
            Driver = driver;
        }
        public AtlassianLoginPage EnterUserName(string username, IWebDriver driver)
        { IWebElement element = Driver.FindElement(By.Id("user"));
            element.SendKeys(username); 
            element.Submit();
            return new AtlassianLoginPage(driver);
        }
        public static LoginPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUrl);
            return new LoginPage(driver);
        }
    }
}

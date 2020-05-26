using Knab_Framework.PageObjectModel;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Knab_Framework.Page_Object_Model
{
    class AtlassianLoginPage: Page
    {
        public AtlassianLoginPage(IWebDriver driver)
        {
            Driver = driver; 
        }
        public BoardPage EnterPassword(string password) {
            IWebElement element = Driver.FindElement(By.Id("password"));
            element.SendKeys(password);
            element.Submit();
            return new BoardPage(Driver);
        }
        
    }
}

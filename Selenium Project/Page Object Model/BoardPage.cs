using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knab_Framework.PageObjectModel
{
    class BoardPage : Page
    {
        public BoardPage(IWebDriver driver)
        {
            Driver = driver;
            PageTitle = "Boards | Trello";
        }
        public string PageTitle { get; set; }

        public string GetPageTitle(IWebDriver driver)
        {
            return driver.Title.ToString();
        }

    }
}

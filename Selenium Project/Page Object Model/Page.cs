using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Knab_Framework.PageObjectModel
{
    class Page
    {
        protected IWebDriver Driver;
        protected virtual string PageUrl { get; }
        protected virtual string PageTitle { get; }
        public void navigatTo()
        {
            Driver.Navigate().GoToUrl(PageUrl);
            EnsurePageLoad(PageUrl);
        }
        public void EnsurePageLoad(string pageUrl)
        {
            if (!Driver.Url.Contains(pageUrl) && !Driver.Title.Contains(pageUrl))
            {
                throw new Exception($"Failed to load page. Page URL = '{Driver.Url}' Page Source: \r\n {Driver.PageSource}");
            }
        }
        public void Implicitwait(int seconds) => Thread.Sleep(seconds);
        public void Dispose()
        {
            Driver.Dispose();
        }
    }
}

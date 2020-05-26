using AventStack.ExtentReports;
using Knab_Framework.Page_Object_Model;
using Knab_Framework.PageObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Knab_Framework.Steps
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private BoardPage _boardPage;
        private AtlassianLoginPage _atlassianLoginPage;
        ExtentTest test ;

        [Given(@"I go to the website")]
        public void GivenIGoToTheWebsite()
        {
          _driver = new ChromeDriver();
          _loginPage = LoginPage.NavigateTo(_driver);
        }

        [Given(@"I enter the the (.*)")]
        public void GivenIEnterTheTheUserName(string username)
        {
             _atlassianLoginPage = _loginPage.EnterUserName(username, _driver);
        }

        [Given(@"In the atlassian page I enter the the (.*)")]
        public void GivenInTheAtlassianPageIEnterTheThe(string password)
        {
            _atlassianLoginPage.Implicitwait(6000);
            _boardPage= _atlassianLoginPage.EnterPassword(password);
        }
        [Then(@"I got the Board home page")]
        public void ThenIGotTheBoardHomePage()
        {
            _boardPage.Implicitwait(8000);
            string str = _boardPage.GetPageTitle(_driver);
            Assert.That(_boardPage.PageTitle, Is.EqualTo(str), "The page title is different");
            
        }
        [AfterScenario]
        public void Dispose()
        {
            _loginPage.Dispose();
            _boardPage.Dispose();
        }
    }
}

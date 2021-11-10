using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.POM;
using System;
using Selenium;

namespace ValidSetting.UITest
{
    class Setting
    {

        private IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            _webDriver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Dispose();
        }

        [Test]
        public void ChangeName()
        {
            var accountSetting = new AccountSetting(_webDriver);
            var signInPage = new SignInPage(_webDriver);
            var homePage = new HomePage(_webDriver);
            signInPage.GetToSignInPage()
                .InputEMailField("verify@mozej.com")
                .InputPasswordField("Aq1sw2de3!")
                .ClickLogIn();
            accountSetting.GoToAccountSetting()
                .ChangeGeneral()
                .ChangeFirstName("eTest")
                .SaveChange()
                .GoToMainPage();

            string actualResult = homePage.GetWelcomeMessageText;
            Assert.AreEqual(expected: "Welcome back eTest! How can we help?", actual: actualResult);
        }

        [Test]
        public void ChangeLastName()
        {
            var accountSetting = new AccountSetting(_webDriver);
            var signInPage = new SignInPage(_webDriver);
            //var home = new HomePage(_webDriver);
            string lastName = Helper.UniqueStringGeneration();
            signInPage.GetToSignInPage()
                .InputEMailField("verify@mozej.com")
                .InputPasswordField("Aq1sw2de3!")
                .ClickLogIn();
            accountSetting.GoToAccountSetting()
                .ChangeGeneral()
                .ChangeLastName(lastName)
                .SaveChange();

            Assert.IsTrue(accountSetting.GetPrimaryAccountName().Contains(lastName));
        }

    }
}

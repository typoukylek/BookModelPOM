using OpenQA.Selenium;

namespace Selenium.POM
{
    class HomePage
    {
        private readonly IWebDriver _webDriver;

        private readonly By _welcomeInAccount = By.CssSelector("[class='WelcomePage__welcomeBackSection--1fVmu'] [class='Section__title--1wSQt']");

        public HomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string GetWelcomeMessageText => _webDriver.FindElement(_welcomeInAccount).Text;

    }
}

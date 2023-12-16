using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit.Abstractions;

namespace Sample3.Tests.StepDefinitions
{
    [Binding]
    public class LoginWithTableStepDefinitions
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private IWebDriver _driver;

        public LoginWithTableStepDefinitions(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _driver = new ChromeDriver();
        }

        [Given(@"I am at the home page of web application\.")]
        public void GivenIAmAtTheHomePageOfWebApplication_()
        {
            _driver.Navigate().GoToUrl("https://www.automationexercise.com");
        }

        [When(@"I enter the credentials\.")]
        public void WhenIEnterTheCredentials_(Table table)
        {
            var credentials = new Dictionary<string, string>();
            
            foreach (var row in table.Rows)
            {
                credentials.Add(row[0], row[1]);
            }

            _driver.Navigate().GoToUrl("https://www.automationexercise.com/login");

            _driver.FindElement(By.XPath("//input[@data-qa=\"login-email\"]")).SendKeys(credentials["Username"]);
            _driver.FindElement(By.XPath("//input[@data-qa=\"login-password\"]")).SendKeys(credentials["Password"]);
        }

        [When(@"I click the login button\.")]
        public void WhenIClickTheLoginButton_()
        {
            _driver.FindElement(By.XPath("//button[@data-qa=\"login-button\"]")).Click();
        }
    }
}

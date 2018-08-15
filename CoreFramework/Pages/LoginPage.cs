using CoreFramework.Elements;
using OpenQA.Selenium;

namespace CoreFramework.Pages
{
    /// <summary>
    /// POM for Login page
    /// </summary>
    public class LoginPage: BasePage
    {
        private static readonly By LoginLabel = By.XPath("//content[text()='Sign in']");

        private readonly BaseElement emailInput = new ElementWithLogger(new Element(By.Id("identifierId"), "email input"));
        private readonly BaseElement emailNextButton = new ElementWithLogger(new Element(By.Id("identifierNext"), "next button"));
        private readonly BaseElement passwordInput = new ElementWithLogger(new Element(By.XPath("//input[@name='password']"), "password input"));
        private readonly BaseElement passwordNextButton = new ElementWithLogger(new Element(By.Id("passwordNext"), "next button"));

        public LoginPage(): base(LoginLabel, "Login page") { }

        /// <summary>
        /// Login with creds
        /// </summary>
        /// <param name="email">user email</param>
        /// <param name="password">user password</param>
        /// <returns>Home page model</returns>
        public HomePage Login(string email, string password)
        {
            emailInput.SendKeys(email);
            emailNextButton.Click();
            passwordInput.WaitForElementIsVisible();
            passwordInput.SendKeys(password);
            passwordNextButton.Click();
            
            return (HomePage) new HomePage().WaitForPageLoaded();
        }
    }
}

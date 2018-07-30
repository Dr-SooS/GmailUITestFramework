using CoreFramework.Elements;
using OpenQA.Selenium;

namespace CoreFramework.Pages
{
    public class LoginPage: BasePage
    {
        private static readonly By LoginLabel = By.XPath("//content[text()='Sign in']");

        private readonly BaseElement emailInput = new ElementWithLogger(new Element(By.Id("identifierId"), "email input"));
        private readonly BaseElement emailNextButton = new ElementWithLogger(new Element(By.Id("identifierNext"), "next button"));
        private readonly BaseElement passwordInput = new ElementWithLogger(new Element(By.XPath("//input[@name='password']"), "password input"));
        private readonly BaseElement passwordNextButton = new ElementWithLogger(new Element(By.Id("passwordNext"), "next button"));

        public LoginPage(): base(LoginLabel, "Login page") { }

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

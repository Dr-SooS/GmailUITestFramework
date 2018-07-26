using OpenQA.Selenium;

namespace CoreFramework.Pages
{
    public class LoginPage: BasePage
    {
        private static readonly By LoginLabel = By.XPath("//content[text()='Sign in']");

        private readonly BaseElement emailInput = new BaseElement(By.Id("identifierId"));
        private readonly BaseElement emailNextButton = new BaseElement(By.Id("identifierNext"));
        private readonly BaseElement passwordInput = new BaseElement(By.XPath("//input[@name='password']"));
        private readonly BaseElement passwordNextButton = new BaseElement(By.Id("passwordNext"));

        public LoginPage(): base(LoginLabel) { }

        public HomePage Login(string email, string password)
        {
            emailInput.GetElement().SendKeys(email);
            emailNextButton.GetElement().Click();
            passwordInput.WaitForElementIsVisible();
            passwordInput.GetElement().SendKeys(password);
            passwordNextButton.GetElement().Click();
            
            return (HomePage) new HomePage().WaitForPageLoaded();
        }
    }
}

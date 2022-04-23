using Automated_Test_Cases.Page_Object_Entities.BasePage_Entity;
using OpenQA.Selenium;

namespace Automated_Test_Cases.Page_Object_Entities
{
    public class AutomationPracticeHomePage : BasePage
    {
        private By EmailInput = By.Id("email_create");
        private By CreateAnAccountButton = By.Id("SubmitCreate");
        private By EmailInputAlreadyRegistredBlock = By.Id("email");
        private By PasswordInput = By.Id("passwd");
        private By SignInButton = By.Id("SubmitLogin");

        private IWebElement SearchEmailInput => driver.FindElement(EmailInput);
        private IWebElement SearchCreateAnAccountButton => driver.FindElement(CreateAnAccountButton);
        private IWebElement SearchEmailInputAlreadyRegistredBlock => driver.FindElement(EmailInputAlreadyRegistredBlock);
        private IWebElement SearchPasswordInput => driver.FindElement(PasswordInput);
        private IWebElement SearchSignInButton => driver.FindElement(SignInButton);

        public AutomationPracticeHomePage(IWebDriver? driver) : base(driver)
        {
        }

        private AutomationPracticeHomePage InsertEmailInfo(string email)
        {
            SearchEmailInput.SendKeys(email);
            return this;
        }

        private AutomationPracticeLoginPage ClickOnACreateAnAccountButton()
        {
            SearchCreateAnAccountButton.Click();
            return new AutomationPracticeLoginPage(driver);
        }

        public AutomationPracticeLoginPage Register(string email)
        {
            InsertEmailInfo(email);
            ClickOnACreateAnAccountButton();
            return new AutomationPracticeLoginPage(driver);
        }

        private AutomationPracticeHomePage InsertEmailAlreadyRegistredBlock(string email)
        {
            SearchEmailInputAlreadyRegistredBlock.SendKeys(email);
            return this;
        }

        private AutomationPracticeHomePage InsertPassword(string password)
        {
            SearchPasswordInput.SendKeys(password);
            return this;
        }

        private AutomationPracticeMyAccountPage ClickOnSignInButton()
        {
            SearchSignInButton.Click();
            return new AutomationPracticeMyAccountPage(driver);
        }

        public AutomationPracticeMyAccountPage LogIn(string email, string password)
        {
            ClickOnACreateAnAccountButton();
            InsertEmailAlreadyRegistredBlock(email);
            InsertPassword(password);
            ClickOnSignInButton();
            return new AutomationPracticeMyAccountPage(driver);
        }
    }
}

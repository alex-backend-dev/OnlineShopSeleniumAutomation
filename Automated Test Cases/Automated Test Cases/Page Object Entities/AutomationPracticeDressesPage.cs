using Automated_Test_Cases.Page_Object_Entities.BasePage_Entity;
using OpenQA.Selenium;

namespace Automated_Test_Cases.Page_Object_Entities
{
    public class AutomationPracticeDressesPage : BasePage
    {
        private By PrintedDressFirstElement = By.XPath("//a[@class = 'product_img_link']");
        private By AddToCartFirstElementButton = By.XPath("//a[@data-id-product = '3']");
        private By PrintedDressSecondElement = By.XPath("//img[@src = 'http://automationpractice.com/img/p/1/0/10-home_default.jpg']");
        private By AddToCartSecondElementButton = By.XPath("//a[@data-id-product = '4']");
        private By PrintedSummerDressThirdElement = By.XPath("//img[@src = 'http://automationpractice.com/img/p/1/2/12-home_default.jpg']");
        private By AddToCartThirdElementButton = By.XPath("//a[@data-id-product = '5']");
        private By ContinueShoppingButton = By.XPath("//span[@title = 'Continue shopping']");

        private IWebElement SearchPrintedDressFirstElement => driver.FindElement(PrintedDressFirstElement);
        private IWebElement SearchAddToCartFirstElementButton => driver.FindElement(AddToCartFirstElementButton);
        private IWebElement SearchPrintedDressSecondElement => driver.FindElement(PrintedDressSecondElement);
        private IWebElement SearchAddToCartSecondElementButton => driver.FindElement(AddToCartSecondElementButton);
        private IWebElement SearchPrintedSummerDressThirdElement => driver.FindElement(PrintedSummerDressThirdElement);
        private IWebElement SearchAddToCartThirdElementButton => driver.FindElement(AddToCartThirdElementButton);
        private IWebElement SearchContinueShoppingButton => driver.FindElement(ContinueShoppingButton);

        public AutomationPracticeDressesPage(IWebDriver? driver) : base(driver)
        {
        }

        private AutomationPracticeDressesPage ClickOnAFirstElement()
        {
            SearchAddToCartFirstElementButton.Click();
            return this;
        }

        private AutomationPracticeDressesPage ClickOnASecondElement()
        {
            SearchAddToCartSecondElementButton.Click();
            return this;
        }

        private AutomationPracticeDressesPage ClickOnAThirdElement()
        {
            SearchAddToCartThirdElementButton.Click();
            return this;
        }

        private AutomationPracticeDressesPage ClickOnContinueShoppingButton()
        {
            SearchContinueShoppingButton.Click();
            return this;
        }

        public void AddFirstProductToACart()
        {
            MoveTo(driver, SearchPrintedDressFirstElement);
            ClickOnAFirstElement();
            IsDisplayed(driver, ContinueShoppingButton, 7);
            ClickOnContinueShoppingButton();
        }

        public void AddSecondProductToACart()
        {
            MoveTo(driver, SearchPrintedDressSecondElement);
            ClickOnASecondElement();
            IsDisplayed(driver, ContinueShoppingButton, 7);
            ClickOnContinueShoppingButton();
        }

        public void AddThirdProductToACart()
        {
            MoveTo(driver, SearchPrintedSummerDressThirdElement);
            ClickOnAThirdElement();
            IsDisplayed(driver, ContinueShoppingButton, 7);
            ClickOnContinueShoppingButton();
        }
    }
}

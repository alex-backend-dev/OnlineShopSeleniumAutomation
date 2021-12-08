using Automated_Test_Cases.Page_Object_Entities.BasePage_Entity;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Automated_Test_Cases.Page_Object_Entities
{
    public class AutomationPracticeCheckOutPage : BasePage
    {
        private By ListOfSKU = By.CssSelector(".cart_item");
        private By TotalPriceBlock = By.XPath("//td[@class =  'total_price_container text-right']//parent::tr");
        private By TotalPrice = By.XPath("//td[@class='price']/span[text()='$107.97']");

        public IWebElement SearchTotalPrice => driver.FindElement(TotalPrice);
        public IList<IWebElement> SearchListOfSKU => driver.FindElements(ListOfSKU);

        public AutomationPracticeCheckOutPage(IWebDriver? driver) : base(driver)
        {
        }

        public IList<IWebElement> VerifyProductsAreInCart()
        {
            return GetElements(driver, ListOfSKU, 7);
        }
        
        public bool VerifyTotalIsDisplayed()
        {
            return IsDisplayed(driver, TotalPriceBlock, 5);
        }
    }
}

using Automated_Test_Cases.Page_Object_Entities.BasePage_Entity;
using OpenQA.Selenium;

namespace Automated_Test_Cases.Page_Object_Entities
{
    public class AutomationPracticePDPPage : BasePage
    {
        private By AddToWishListLink = By.Id("wishlist_button");
        private By FancyBoxElement = By.XPath("//div[@class = 'fancybox-inner']");

        private IWebElement SearchAddToWishListLink => driver.FindElement(AddToWishListLink);

        public AutomationPracticePDPPage(IWebDriver? driver) : base(driver)
        {
        }

        public AutomationPracticePDPPage ClickOnAWishList()
        {
            SearchAddToWishListLink.Click();
            IsDisplayed(driver, FancyBoxElement, 5);
            driver?.Navigate().Back();
            driver?.Navigate().Refresh();
            return this;
        }
    }
}

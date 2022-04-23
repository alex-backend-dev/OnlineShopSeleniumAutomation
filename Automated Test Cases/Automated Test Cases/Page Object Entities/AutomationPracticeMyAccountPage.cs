using Automated_Test_Cases.Page_Object_Entities.BasePage_Entity;
using OpenQA.Selenium;

namespace Automated_Test_Cases.Page_Object_Entities
{
    public class AutomationPracticeMyAccountPage : BasePage
    {
        private By ReturnHomeLink = By.XPath("//a[@title = 'Home']");
        private By MyWishListsLink = By.XPath("//a[@title = 'My wishlists']");
        private By DressesButton = By.XPath("//ul[@class= 'sf-menu clearfix menu-content sf-js-enabled sf-arrows']/li[2]/a");

        private IWebElement SearchMyWishListsLink => driver.FindElement(MyWishListsLink);
        private IWebElement SearchDressesButton => driver.FindElement(DressesButton);

        public AutomationPracticeMyAccountPage(IWebDriver? driver) : base(driver)
        {
        }

        public bool IsReturnHomeLinkDisplayed()
        {
            return IsDisplayed(driver, ReturnHomeLink, 7);
        }

        public AutomationPracticeMyStorePage ClickOnMyWishlists()
        {
            SearchMyWishListsLink.Click();
            return new AutomationPracticeMyStorePage(driver);
        }

        public AutomationPracticeDressesPage ClickOnADressesButton()
        {
            SearchDressesButton.Click();
            return new AutomationPracticeDressesPage(driver);
        }
    }
}

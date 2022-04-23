using Automated_Test_Cases.Page_Object_Entities.BasePage_Entity;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Automated_Test_Cases.Page_Object_Entities
{
    public class AutomationPracticeMyStorePage : BasePage
    {
        Random rnd = new Random();

        private By ListOfProducts = By.XPath("//div[@class = 'block_content']/ul/li[@class = 'clearfix']/a");
        private By MyWishListBlock = By.XPath("//div[@id = 'block-history']");
        private By MyWishListLink = By.XPath("//td[@style = 'width:200px;']/a");
        private By MyWishProductLink = By.XPath("//ul[@class = 'row wlp_bought_list']/li");
        private By CartDropDown = By.XPath("//a[@title= 'View my shopping cart']");

        private IList<IWebElement> SearchListOfProducts => driver.FindElements(ListOfProducts);
        private IList<IWebElement> SearchMyWishListBlock => driver.FindElements(MyWishListBlock);
        private IWebElement SearchMyWishListLink => driver.FindElement(MyWishListLink);
        private IWebElement SearchCartDropDown => driver.FindElement(CartDropDown);

        public AutomationPracticeMyStorePage(IWebDriver? driver) : base(driver)
        {
        }

        public AutomationPracticePDPPage RandomClick()
        {
            int randomValue = rnd.Next(SearchListOfProducts.Count);
            SearchListOfProducts[randomValue].Click();
            return new AutomationPracticePDPPage(driver);
        }

        public bool IsMyWishBlockIsntDisplayed() => SearchMyWishListBlock.Count <= 0;

        public bool IsMyWishBlockIsDisplayed()
        {
            return IsDisplayed(driver, MyWishListBlock, 7);
        }

        public AutomationPracticeMyStorePage ClickOnMyWishList()
        {
            SearchMyWishListLink.Click();
            return this;
        }

        public bool IsProductDisplayed()
        {
            return IsDisplayed(driver, MyWishProductLink, 7);
        }

        public AutomationPracticeMyStorePage GoToCheckOut()
        {
            SearchCartDropDown.Click();
            return this;
        }
    }
}

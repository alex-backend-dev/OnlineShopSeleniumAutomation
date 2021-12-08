using Automated_Test_Cases.Constant_Entities;
using Automated_Test_Cases.Test_Entities.BaseTest_Entity;
using NUnit.Framework;
using NUnit.Allure.Attributes;
using Allure.Commons;
using NUnit.Allure.Core;

namespace Automated_Test_Cases
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Automation Practices Tests")]
    [AllureDisplayIgnored]
    public class AutomationPracticeTests : BaseTest
    {
        /*
         *************************************** AP-1 Verify the ability to create an account  *****************************************************
         */

        [Test(Description = "Verify the ability to create an account")]
        [AllureTag("CI")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTms("AP-1")]
        [AllureOwner("Alexander Ulyanitskiy")]
        [AllureSubSuite("Verification")]
        [Order(1)]
        public void VerifyTheAbilityToCreateAnAccount()
        {
            automationPracticeHomePage?
                .GoTo(Constant.Url.Automation_Practice_Home_Page_Url);
            Assert.IsTrue(automationPracticeHomePage?.
                AtPageByURL(Constant.Url.Automation_Practice_Home_Page_Url), $"Home Page Url is incorrect - test received {driver?.Url}");
            Assert.IsTrue(automationPracticeHomePage?.
                AtPageByTitle(Constant.Title.Automation_Practice_Home_Page_Title), $"Home Page title is incorrect - test received {driver?.Title}");
            automationPracticeHomePage?.Register(Constant.Credentials.Email);

            Assert.IsTrue(automationPracticeLoginPage?.IsDisplayedYourPersonalInformationBlock(), "Personal Information block isn't displayed");
            Assert.IsTrue(automationPracticeLoginPage?.IsDisplayedYourAddressBlock(), "Your address block isn't displayed");
            automationPracticeLoginPage?
                .FirstNameInitialize(Constant.Credentials.FirstName)
                .LastNameInitialize(Constant.Credentials.LastName)
                .PasswordInitialize(Constant.Credentials.Password)
                .CompanyNameInitialize(Constant.Credentials.Company)
                .AddressNameInitialize(Constant.Credentials.AddressInfo)
                .AddressLine2Initialize(Constant.Credentials.AddressInfoLine2)
                .CityNameInitialize(Constant.Credentials.City)
                .ZipPostalCodeInitialize(Constant.Credentials.ZipPostalCode)
                .AdditionalInfoInitialize(Constant.Credentials.AdditionalInfo)
                .HomePhoneInfoInitialize(Constant.Credentials.HomePhone)
                .MobilePhoneInfoInitialize(Constant.Credentials.MobilePhone)
                .AddressInfoInitialize(Constant.Credentials.AddressAlias)
                .RegisterBuilder();

            Assert.IsTrue(automationPracticeMyAccountPage?.IsReturnHomeLinkDisplayed(), "Home Link isn't displayed");
            Assert.IsTrue(automationPracticeMyAccountPage?.AtPageByTitle
                (Constant.Title.Automation_Practice_My_Account_My_Store), $"My Store Page title is incorrect - test received {driver?.Title}");
        }

        /*
         *************************************** AP-2 Verify the ability to login in account  ******************************************************
         */

        [Test(Description = "Verify the ability to login in account")]
        [AllureTag("CI")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTms("AP-2")]
        [AllureOwner("Alexander Ulyanitskiy")]
        [AllureSubSuite("Verification")]
        [Order(2)]
        public void VerifyTheAbilityToLoginInAccount()
        {
            automationPracticeHomePage?
                .GoTo(Constant.Url.Automation_Practice_Home_Page_Url);
            Assert.IsTrue(automationPracticeHomePage?.
                AtPageByURL(Constant.Url.Automation_Practice_Home_Page_Url), $"Home Page Url is incorrect - test received {driver?.Url}");
            Assert.IsTrue(automationPracticeHomePage?.
                AtPageByTitle(Constant.Title.Automation_Practice_Home_Page_Title), $"Home Page title is incorrect - test received {driver?.Title}");
            automationPracticeHomePage?.LogIn(Constant.Credentials.Email, Constant.Credentials.Password);

            Assert.IsTrue(automationPracticeMyAccountPage?.IsReturnHomeLinkDisplayed(), "Home Link isn't displayed");
            Assert.IsTrue(automationPracticeMyAccountPage?.AtPageByTitle
                (Constant.Title.Automation_Practice_My_Account_My_Store), $"My Store Page title is incorrect - test received {driver?.Title}");
        }

        /*
         *************************************** AP-3 Verify the ability to add to auto created wish list ******************************************************
         */

        [Test(Description = "Verify the ability to add to auto created wish list")]
        [AllureTag("CI")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTms("AP-3")]
        [AllureOwner("Alexander Ulyanitskiy")]
        [AllureSubSuite("Verification")]
        [Order(3)]
        public void VerifyTheAbilityToAddToAutoCreatedWishlist()
        {
            automationPracticeHomePage?
                .GoTo(Constant.Url.Automation_Practice_Home_Page_Url);
            Assert.IsTrue(automationPracticeHomePage?.
                AtPageByURL(Constant.Url.Automation_Practice_Home_Page_Url), $"Home Page Url is incorrect - test received {driver?.Url}");
            Assert.IsTrue(automationPracticeHomePage?.
                AtPageByTitle(Constant.Title.Automation_Practice_Home_Page_Title), $"Home Page title is incorrect - test received {driver?.Title}");
            automationPracticeHomePage?.LogIn(Constant.Credentials.Email, Constant.Credentials.Password);

            Assert.IsTrue(automationPracticeMyAccountPage?.IsReturnHomeLinkDisplayed(), "Home Link isn't displayed");
            Assert.IsTrue(automationPracticeMyAccountPage?.AtPageByTitle
                (Constant.Title.Automation_Practice_My_Account_My_Store), $"My Account Store Page title is incorrect - test received {driver?.Title}");
            automationPracticeMyAccountPage?
                .ClickOnMyWishlists();
            Assert.IsTrue(automationPracticeMyStorePage?.IsMyWishBlockIsntDisplayed(), "My Wish Block is displayed");
            Assert.IsTrue(automationPracticeMyStorePage?.AtPageByTitle(Constant.Title.Automation_Practice_My_Store), $"My Store Page title is incorrect - test received {driver?.Title}");
            automationPracticeMyStorePage?.RandomClick();
            automationPracticePDPPage?.ClickOnAWishList();
            Assert.IsTrue(automationPracticeMyStorePage?.IsMyWishBlockIsDisplayed(), "My Wish Block isn't displayed");
            automationPracticeMyStorePage?
                .ClickOnMyWishList();
            Assert.IsTrue(automationPracticeMyStorePage?.IsProductDisplayed());
        }

        /*
         *************************************** AP-4 Verify the ability to add to your wish list ******************************************************
         */

        [Test(Description = "Verify the ability to add to your wish list")]
        [AllureTag("CI")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTms("AP-4")]
        [AllureOwner("Alexander Ulyanitskiy")]
        [AllureSubSuite("Verification")]
        [Order(4)]
        public void VerifyTheAbilityToAddToYorWishlist()
        {
            automationPracticeHomePage?
                .GoTo(Constant.Url.Automation_Practice_Home_Page_Url);
            Assert.IsTrue(automationPracticeHomePage?.
                AtPageByURL(Constant.Url.Automation_Practice_Home_Page_Url), $"Home Page Url is incorrect - test received {driver?.Url}");
            Assert.IsTrue(automationPracticeHomePage?.
                AtPageByTitle(Constant.Title.Automation_Practice_Home_Page_Title), $"Home Page title is incorrect - test received {driver?.Title}");
            automationPracticeHomePage?.LogIn(Constant.Credentials.Email, Constant.Credentials.Password);

            Assert.IsTrue(automationPracticeMyAccountPage?.IsReturnHomeLinkDisplayed(), "Home Link isn't displayed");
            automationPracticeMyAccountPage?
                .ClickOnMyWishlists();
            Assert.IsTrue(automationPracticeMyStorePage?.AtPageByTitle(Constant.Title.Automation_Practice_My_Store), $"My Store Page title is incorrect - test received {driver?.Title}");
            automationPracticeMyStorePage?.RandomClick();
            automationPracticePDPPage?.ClickOnAWishList();
            Assert.IsTrue(automationPracticeMyStorePage?.IsMyWishBlockIsDisplayed(), "My Wish Block isn't displayed");
        }

        /*
         *************************************** AP-5 Verify the ability to add to cart ******************************************************
         */

        [Test(Description = "Verify the ability to add to cart")]
        [AllureTag("CI")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTms("AP-5")]
        [AllureOwner("Alexander Ulyanitskiy")]
        [AllureSubSuite("Verification")]
        [Order(5)]
        public void VerifyTheAbilityToAddToCart()
        {
            automationPracticeHomePage?
                .GoTo(Constant.Url.Automation_Practice_Home_Page_Url);
            Assert.IsTrue(automationPracticeHomePage?.
                AtPageByURL(Constant.Url.Automation_Practice_Home_Page_Url), $"Home Page Url is incorrect - test received {driver?.Url}");
            Assert.IsTrue(automationPracticeHomePage?.
                AtPageByTitle(Constant.Title.Automation_Practice_Home_Page_Title), $"Home Page title is incorrect - test received {driver?.Title}");
            automationPracticeHomePage?.LogIn(Constant.Credentials.Email, Constant.Credentials.Password);

            Assert.IsTrue(automationPracticeMyAccountPage?.IsReturnHomeLinkDisplayed(), "Home Link isn't displayed");
            automationPracticeMyAccountPage?
                .ClickOnMyWishlists();
            Assert.IsTrue(automationPracticeMyStorePage?.AtPageByTitle(Constant.Title.Automation_Practice_My_Store), $"My Store Page title is incorrect - test received {driver?.Title}");
            automationPracticeMyAccountPage?.ClickOnADressesButton();
            automationPracticeDressesPage?.AddFirstProductToACart();
            automationPracticeDressesPage?.AddSecondProductToACart();
            automationPracticeDressesPage?.AddThirdProductToACart();
            automationPracticeMyStorePage?.GoToCheckOut();

            Assert.AreEqual(automationPracticeCheckOutPage?.SearchListOfSKU, automationPracticeCheckOutPage?.VerifyProductsAreInCart(), "Products aren't added to a cart");
            Assert.IsTrue(automationPracticeCheckOutPage?.VerifyTotalIsDisplayed(), "Total price isn't displayed");
            Assert.AreEqual("$107.97", automationPracticeCheckOutPage?.SearchTotalPrice.Text, "Total price isn't correct");
        }
    }
}
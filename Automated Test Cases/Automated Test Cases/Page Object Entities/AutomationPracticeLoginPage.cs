using Automated_Test_Cases.Page_Object_Entities.BasePage_Entity;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Automated_Test_Cases.Page_Object_Entities
{
    public class AutomationPracticeLoginPage : BasePage
    {
        private string _firstName;
        private string _lastName;
        private string _password;
        private string _company;
        private string _address;
        private string _addressLine2;
        private string _city;
        private string _zipPostalCode;
        private string _additionalInfo;
        private string _homePhone;
        private string _mobilePhone;
        private string _addressAlias;

        private By MrRadioButton = By.Id("id_gender1");
        private By FirstNamePersonalInfoInput = By.Id("customer_firstname");
        private By LastNamePersonalInfoInput = By.Id("customer_lastname");
        private By PasswordInput = By.Id("passwd");
        private By SelectDaysDropDown = By.Id("days");
        private By SelectMonthsDropDown = By.Id("months");
        private By SelectYearsDropDown = By.Id("years");
        private By SignUpForOurNewsLetterCheckBox = By.Id("newsletter");
        private By ReceiveSpecialOffersCheckBox = By.Id("optin");
        private By AccountCreationForm = By.Id("account-creation_form");
        private By YourAddressBlock = By.XPath("//h3[text()='Your address']/parent::*");
        private By CompanyInput = By.Id("company");
        private By AddressInput = By.Id("address1");
        private By AddressLine2Input = By.Id("address2");
        private By CityInput = By.Id("city");
        private By CountryDropDown = By.Id("id_country");
        private By AdditionalInfoTextArea = By.Id("other");
        private By HomePhoneInput = By.Id("phone");
        private By MobilePhoneInput = By.Id("phone_mobile");
        private By RegisterButton = By.Id("submitAccount");
        private By AddressForFutureReferenceInput = By.Id("alias");
        private By StateDropDown = By.Id("id_state");
        private By ZipPostalCodeInput = By.Id("postcode");

        private IWebElement SearchMrRadioButton => driver.FindElement(MrRadioButton);
        private IWebElement SearchFirstNameInput => driver.FindElement(FirstNamePersonalInfoInput);
        private IWebElement SearchLastNameInput => driver.FindElement(LastNamePersonalInfoInput);
        private IWebElement SearchPasswordInput => driver.FindElement(PasswordInput);
        private IWebElement SearchSelectDaysDropDown => driver.FindElement(SelectDaysDropDown);
        private IWebElement SearchSelectMonthsDropDown => driver.FindElement(SelectMonthsDropDown);
        private IWebElement SearchSelectYearsDropDown => driver.FindElement(SelectYearsDropDown);
        private IWebElement SearchSignUpForOurNewsLetter => driver.FindElement(SignUpForOurNewsLetterCheckBox);
        private IWebElement SearchReceiveSpecialOffersCheckBox => driver.FindElement(ReceiveSpecialOffersCheckBox);
        private IWebElement SearchCompanyInput => driver.FindElement(CompanyInput);
        private IWebElement SearchAddressInput => driver.FindElement(AddressInput);
        private IWebElement SearchAddressLine2Input => driver.FindElement(AddressLine2Input);
        private IWebElement SearchCityInput => driver.FindElement(CityInput);
        private IWebElement SearchCountryDropDown => driver.FindElement(CountryDropDown);
        private IWebElement SearchAdditionalInfoTextArea => driver.FindElement(AdditionalInfoTextArea);
        private IWebElement SearchHomePhoneInput => driver.FindElement(HomePhoneInput);
        private IWebElement SearchMobilePhoneInput => driver.FindElement(MobilePhoneInput);
        private IWebElement SearchRegisterButton => driver.FindElement(RegisterButton);
        private IWebElement SearchAddressForFutureReferenceInput => driver.FindElement(AddressForFutureReferenceInput);
        private IWebElement SearchStateDropDown => driver.FindElement(StateDropDown); 
        private IWebElement SearchZipPostalCodeInput => driver.FindElement(ZipPostalCodeInput);

        public AutomationPracticeLoginPage(IWebDriver? driver) : base(driver)
        {
        }

        public bool IsDisplayedYourPersonalInformationBlock()
        {
            return IsDisplayed(driver, AccountCreationForm, 10);
        }

        public bool IsDisplayedYourAddressBlock()
        {
            return IsDisplayed(driver, YourAddressBlock, 6);
        }

        private AutomationPracticeLoginPage ClickOnARadioButton()
        {
            SearchMrRadioButton.Click();
            return this;
        }

        public AutomationPracticeLoginPage FirstNameInitialize(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public AutomationPracticeLoginPage LastNameInitialize(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public AutomationPracticeLoginPage PasswordInitialize(string password)
        {
            _password = password;
            return this;
        }

        private AutomationPracticeLoginPage ClickOnDaysOption()
        {
            SelectElement selectList = new SelectElement(SearchSelectDaysDropDown);
            IList<IWebElement> options = selectList.Options;

            int countElements = options.Count;

            Random num = new Random();
            int select = num.Next(0, countElements);

            selectList.SelectByIndex(select);
            return this;
        }

        private AutomationPracticeLoginPage ClickOnMonthsOption()
        {
            SelectElement selectList = new SelectElement(SearchSelectMonthsDropDown);
            IList<IWebElement> options = selectList.Options;

            int countElements = options.Count;

            Random num = new Random();
            int select = num.Next(0, countElements);

            selectList.SelectByIndex(select);
            return this;
        }

        private AutomationPracticeLoginPage ClickOnYearsOption()
        {
            SelectElement selectList = new SelectElement(SearchSelectYearsDropDown);
            IList<IWebElement> options = selectList.Options;

            int countElements = options.Count;

            Random num = new Random();
            int select = num.Next(0, countElements);

            selectList.SelectByIndex(select);
            return this;
        }

        private AutomationPracticeLoginPage ClickOnRadioButtonSignUpForOurNewsLetter()
        {
            SearchSignUpForOurNewsLetter.Click();
            return this;
        }

        private AutomationPracticeLoginPage ClickOnCheckBoxReceiveSpecialOffers()
        {
            SearchReceiveSpecialOffersCheckBox.Click();
            return this;
        }

        public AutomationPracticeLoginPage CompanyNameInitialize(string company)
        {
            _company = company;
            return this;
        }

        public AutomationPracticeLoginPage AddressNameInitialize(string address)
        {
            _address = address;
            return this;
        }

        public AutomationPracticeLoginPage AddressLine2Initialize(string addressLine2)
        {
            _addressLine2 = addressLine2;
            return this;
        }

        public AutomationPracticeLoginPage CityNameInitialize(string city)
        {
            _city = city;
            return this;
        }

        private AutomationPracticeLoginPage ClickOnCountryOption()
        {
            SearchCountryDropDown.Click();
            var selectElement = new SelectElement(SearchCountryDropDown);
            selectElement.SelectByText("United States");
            return this;
        }

        private AutomationPracticeLoginPage ClickOnStateOption()
        {
            SelectElement selectList = new SelectElement(SearchStateDropDown);
            IList<IWebElement> options = selectList.Options;

            int countElements = options.Count;

            Random num = new Random();
            int select = num.Next(0, countElements);

            selectList.SelectByIndex(select);
            return this;
        }

        public AutomationPracticeLoginPage ZipPostalCodeInitialize(string zipPostalCode)
        {
            _zipPostalCode = zipPostalCode;
            return this;
        }

        public AutomationPracticeLoginPage AdditionalInfoInitialize(string additionalInfo)
        {
            _additionalInfo = additionalInfo;
            return this;
        }

        public AutomationPracticeLoginPage HomePhoneInfoInitialize(string homePhone)
        {
            _homePhone = homePhone;
            return this;
        }

        public AutomationPracticeLoginPage MobilePhoneInfoInitialize(string mobilePhone)
        {
            _mobilePhone = mobilePhone;
            return this;
        }

        public AutomationPracticeLoginPage AddressInfoInitialize(string addressAlias)
        {
            SearchAddressForFutureReferenceInput.Clear();
            _addressAlias = addressAlias;
            return this;
        }

        private AutomationPracticeLoginPage ClickOnARegisterButton()
        {
            SearchRegisterButton.Click();
            return this; 
        }

        public void RegisterBuilder()
        {
            ClickOnARadioButton();
            SendKeysFields(SearchFirstNameInput, _firstName);
            SendKeysFields(SearchLastNameInput, _lastName);
            SendKeysFields(SearchPasswordInput, _password);
            ClickOnDaysOption();
            ClickOnMonthsOption();
            ClickOnYearsOption();
            ClickOnRadioButtonSignUpForOurNewsLetter();
            ClickOnCheckBoxReceiveSpecialOffers();
            SendKeysFields(SearchCompanyInput, _company);
            SendKeysFields(SearchAddressInput, _address);
            SendKeysFields(SearchAddressLine2Input, _addressLine2);
            SendKeysFields(SearchCityInput, _city);
            ClickOnCountryOption();
            ClickOnStateOption();
            SendKeysFields(SearchZipPostalCodeInput, _zipPostalCode);
            SendKeysFields(SearchAdditionalInfoTextArea, _additionalInfo);
            SendKeysFields(SearchHomePhoneInput, _homePhone);
            SendKeysFields(SearchMobilePhoneInput, _mobilePhone);
            SendKeysFields(SearchAddressForFutureReferenceInput, _addressAlias);
            ClickOnARegisterButton();
        }
    }
}

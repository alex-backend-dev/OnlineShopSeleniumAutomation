using Automated_Test_Cases.TypeOfDriver_Enum;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Automated_Test_Cases.Page_Object_Entities.BasePage_Entity
{
    public class BasePage
    {
        protected IWebDriver? driver;
        public BasePage(IWebDriver? driver)
        {
            this.driver = driver;
        }

        public void GoTo(string URL)
        {
            driver?.Navigate().GoToUrl(URL);
        }


        public bool AtPageByURL(string URL)
        {
            return driver?.Url == URL;
        }

        public bool AtPageByTitle(string Title)
        {
            return driver?.Title == Title;
        }

        public bool IsDisplayed(IWebDriver driver, By by, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(by);
                    return elementToBeDisplayed.Displayed;
                }

                catch (StaleElementReferenceException)
                {
                    return false;
                }

                catch (NoSuchElementException)
                {
                    return false;
                }
            });

            return true;
        }

        public void SendKeysFields(IWebElement element, string text)
        {
            if (element != null)
            {
                element.SendKeys(text);
            }

            else
            {
                throw new ArgumentNullException("Element can't be empty");
            }
        }

        public void MoveTo(IWebDriver driver, IWebElement webElement)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(webElement);
            action.Perform();
        }

        public ReadOnlyCollection<IWebElement> GetElements(IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => (drv.FindElements(by).Count > 0) ? drv.FindElements(by) : null);
            }

            return driver.FindElements(by);
        }

        public static IWebDriver CreateDriver(TypeOfDriver typeOfDriver)
        {
            switch(typeOfDriver)
            {
                case TypeOfDriver.Chrome:
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    return new ChromeDriver();
                
                case TypeOfDriver.Firefox:
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    return new FirefoxDriver();

                case TypeOfDriver.Selenoid:
                    var driverOptions = new ChromeOptions();
                    var timestamp = $"{DateTime.Now:yyyyMMdd.HHmm}";
                    driverOptions.AddAdditionalCapability("videoName", $"{timestamp}.mp4", true);
                    driverOptions.AddAdditionalCapability("logName", $"{timestamp}.log", true);
                    driverOptions.AddAdditionalCapability("enableVNC", true, true);
                    driverOptions.AddAdditionalCapability("enableVideo", true, true);
                    driverOptions.AddAdditionalCapability("enableLog", true, true);
                    driverOptions.AddAdditionalCapability("screenResolution", "1920x1080x24", true);

                    return new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"), driverOptions);

                case TypeOfDriver.SauceLabs:
                    var browserOptions = new ChromeOptions();
                    browserOptions.PlatformName = "Windows 10";
                    browserOptions.BrowserVersion = "latest";

                    var sauceOptions = new Dictionary<string, object>();
                    sauceOptions.Add("name", TestContext.CurrentContext.TestDirectory);
                    sauceOptions.Add("username", Environment.GetEnvironmentVariable("SAUCE_USERNAME"));
                    sauceOptions.Add("accessKey", Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY"));
                    browserOptions.AddAdditionalOption("sauce:options", sauceOptions);
                    var sauceUrl = new Uri("https://api.eu-central-1.saucelabs.com/");

                    return new RemoteWebDriver(sauceUrl, browserOptions);

                default:
                    throw new Exception("Incorrect Browser Name");                    
            } 
        }
    }
}

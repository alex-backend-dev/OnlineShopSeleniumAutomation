using Allure.Commons;
using Automated_Test_Cases.Page_Object_Entities;
using Automated_Test_Cases.Page_Object_Entities.BasePage_Entity;
using Automated_Test_Cases.TypeOfDriver_Enum;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;

namespace Automated_Test_Cases.Test_Entities.BaseTest_Entity
{
    public class BaseTest
    {
        protected IWebDriver? driver;
        protected AutomationPracticeHomePage? automationPracticeHomePage;
        protected AutomationPracticeLoginPage? automationPracticeLoginPage;
        protected AutomationPracticeMyAccountPage? automationPracticeMyAccountPage;
        protected AutomationPracticeMyStorePage? automationPracticeMyStorePage;
        protected AutomationPracticePDPPage? automationPracticePDPPage;
        protected AutomationPracticeDressesPage? automationPracticeDressesPage;
        protected AutomationPracticeCheckOutPage? automationPracticeCheckOutPage;

        [OneTimeSetUp]
        public void ClearResultsDir()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [SetUp]
        public void Setup()
        {
            driver = BasePage.CreateDriver(TypeOfDriver.Chrome);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.Manage().Window.Maximize();

            automationPracticeHomePage = new AutomationPracticeHomePage(driver);
            automationPracticeLoginPage = new AutomationPracticeLoginPage(driver);
            automationPracticeMyAccountPage = new AutomationPracticeMyAccountPage(driver);
            automationPracticeMyStorePage = new AutomationPracticeMyStorePage(driver);
            automationPracticePDPPage = new AutomationPracticePDPPage(driver);
            automationPracticeDressesPage = new AutomationPracticeDressesPage(driver);
            automationPracticeCheckOutPage = new AutomationPracticeCheckOutPage(driver);
        }

        [TearDown]
        public void CreateScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string path = Path.Combine(Environment.CurrentDirectory, @"TestResults\", "Screenshoot.jpg");
                screenshot.SaveAsFile(path, ScreenshotImageFormat.Jpeg);
                driver.Quit();
            }

            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}

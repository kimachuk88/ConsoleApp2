using ConsoleApp2.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace ConsoleApp2
{
    [TestFixture]
    class BaseTest
    {
        public static IWebDriver driver;
        public HomePage homePage;
        public CheckoutPage checkoutPage;
        public PopupItem popupItem;
        public MainCartPage mainCartPage;
        public SidePanel sidePanel;
        public AllItemsPage allItemsPage;
        public ItemDetailsPage itemDetailsPage;

        [SetUp]
        public void InitDriver()
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            driver = new ChromeDriver(System.IO.Path.Combine(sCurrentDirectory, @"..\..\driver"));
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Url = "http://www.wahoofitness.com";
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            driver.Quit();
        }
    }
}

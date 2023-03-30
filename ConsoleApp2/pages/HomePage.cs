using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class HomePage
    {
        IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static HomePage InitPage(IWebDriver driver)
        {
            return new HomePage(driver);
        }

        public string possibleQuizCloseBtnXpath = "//div[contains(@id,'dy-quiz')]//div[@class='close-button']";
        public string shopBtnXpath = "//div[@class='action']//span[text()='SHOP']";
        public string topNavMenuItemBtn = "//nav[@id='top_nav']//span[text()='{0}']";
        public string subCategoriesBtn = "//div[@class='block-content toggle-content']//a[text()='{0}']";
        public string itemByNameXpath = "//p[@class='product-name']/a[text()='{0}']";
        private string itemAddToCartBtnXpath = "//li[@class='item' and .//a[text()='{0}']]//button[@title='Add to Cart']";

        public void ClickShopBtn()
        {
            Util.ClickElementByXpath(driver, shopBtnXpath);
        }

        public void OpenTopMenu(string menuName)
        {
            Util.ClickElementByXpath(driver, string.Format(topNavMenuItemBtn, menuName));
        }

        public void OpenSubCategorie(string subcategorieName)
        {
            Util.ClickElementByXpath(driver, string.Format(subCategoriesBtn, subcategorieName));
        }

        public void AddItemToCart(string itemName)
        {
            Util.HoverOver(driver, string.Format(itemByNameXpath, itemName));
            Util.ClickElementByXpath(driver, string.Format(itemAddToCartBtnXpath, itemName));
        }

        public void CloseQuiz()
        {
            try
            {
                Util.ClickElementByXpath(driver, possibleQuizCloseBtnXpath);
            } catch(NoSuchElementException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

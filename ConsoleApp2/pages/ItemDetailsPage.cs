using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    
    class ItemDetailsPage
    {
        IWebDriver driver;

        public ItemDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static ItemDetailsPage InitPage(IWebDriver driver)
        {
            return new ItemDetailsPage(driver);
        }

        private string addToCartBtnXpath = "//button[@id=product-addtocart-button']";


        public void AddItemToCart()
        {
            Util.ClickElementByXpath(driver, addToCartBtnXpath);
        }
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class MainCartPage
    {
        IWebDriver driver;

        public MainCartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static MainCartPage InitPage(IWebDriver driver)
        {
            return new MainCartPage(driver);
        }
        private string itemQtyFieldXpath = "//tr[.//a[text()='{0}']]//input[@class='input-text qty']";
        private string itemPriceXpath = "//tr[.//a[text()='{0}']]/td[@data-th='{1}']//span[@class='price']";
        private string updateCartBtnXpath = "//button[@name='update_cart_action']";
        private string proceedToCheckoutBtnXpath = "//button[@title='Proceed to Checkout']";

        public void SetItemQty(string itemQty)
        {
            Util.InputTextIntoFieldByXpath(driver, itemQtyFieldXpath, itemQty);
            Util.ClickElementByXpath(driver, updateCartBtnXpath);
        }

        public double GetItemPrice(string itemName, string priceType)
        {
            return double.Parse(Util.GetTextFromElement(driver, string.Format(itemPriceXpath, itemName, priceType)).Replace("$", ""));
        }

        public void ClickProceedToCheckoutBtn()
        {
            Util.ClickElementByXpath(driver, proceedToCheckoutBtnXpath);
        }
    }
}

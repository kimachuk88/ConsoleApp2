using OpenQA.Selenium;
using System;

namespace ConsoleApp2
{
    class MainCartPage
    {
        private IWebDriver driver;
        private string itemQtyFieldXpath = "//tr[.//a[text()='{0}']]//input[@class='input-text qty']";
        private string itemPriceXpath = "//tr[.//a[text()='{0}']]/td[@data-th='{1}']//span[@class='price']";
        private string updateCartBtnXpath = "//button[@name='update_cart_action']";
        private string proceedToCheckoutBtnXpath = "//button[@title='Proceed to Checkout']";


        public MainCartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static MainCartPage InitPage(IWebDriver driver)
        {
            return new MainCartPage(driver);
        }
       
        public void SetItemQty(string itemName, string itemQty)
        {
            DriverUtil.InputTextIntoFieldByXpath(driver, string.Format(itemQtyFieldXpath,itemName), itemQty);
            DriverUtil.ClickElementByXpath(driver, updateCartBtnXpath);
        }

        public double GetItemPrice(string itemName, string priceType)
        {
            String strNumber = DriverUtil.GetTextFromElement(driver, string.Format(itemPriceXpath, itemName, priceType)).Replace("$", "").Replace(".", ",");
            if (!double.TryParse(strNumber, out double result))
            {
                throw new ArgumentException("String is not a valid number.");
            }

            return result;
        }

        public void ClickProceedToCheckoutBtn()
        {
            DriverUtil.ClickElementByXpath(driver, proceedToCheckoutBtnXpath);
        }
    }
}

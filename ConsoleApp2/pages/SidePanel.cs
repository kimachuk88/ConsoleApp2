using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class SidePanel
    {
        private IWebDriver driver;
        private string removeItemFromCartBtnXpath = "//div[@class='product-item-details' and .//a[text()='{0}']]//a[@title='Remove item']";
        private string itemsNamesInCartXpath = "//strong[@class='product-item-name']//a";
        private string viewAndEditCartBtnXpath = "//a[@class='action viewcart']/span[text()='View and Edit Cart']";
        private string sidePanelCloseBtn = "//a[@id='btn-minicart-close']";

        public SidePanel(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static SidePanel InitPage(IWebDriver driver)
        {
            return new SidePanel(driver);
        }

        public void RemoveItemFromCart(string ItemName)
        {
            DriverUtil.ClickElementByXpath(driver, string.Format(removeItemFromCartBtnXpath, ItemName));
        }

        public List<string> GetNamesOfItemsInCart()
        {
            WaitUtil.WaitForElementStopMoving(driver, viewAndEditCartBtnXpath, 10);
            return DriverUtil.GetTextFromAllMatchingElements(driver, itemsNamesInCartXpath);
        }

        public void ClickViewAndEditCartBtn()
        {
            DriverUtil.ClickElementByXpath(driver, viewAndEditCartBtnXpath);
        }

        public void closeSidePanel()
        {
            WaitUtil.WaitForElementStopMoving(driver, sidePanelCloseBtn, 10);
            DriverUtil.ClickElementByXpath(driver, sidePanelCloseBtn);
        }
    }
}

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
        IWebDriver driver;

        public SidePanel(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static SidePanel InitPage(IWebDriver driver)
        {
            return new SidePanel(driver);
        }
        private string removeItemFromCartBtnXpath = "//div[@class='product-item-details' and .//a[text()='{0}']]//a[@title='Remove item']";
        private string itemsNamesInCartXpath = "//strong[@class='product-item-name']//a";
        private string viewAndEditCartBtnXpath = "//a[@class='action viewcart']/span[text()='View and Edit Cart']";
        private string sidePanelCloseBtn = "//a[@id='btn-minicart-close']";

        public void RemoveItemFromCart(string ItemName)
        {
            Util.ClickElementByXpath(driver, string.Format(removeItemFromCartBtnXpath, ItemName));
        }

        public List<string> GetNamesOfItemsInCart()
        {
            return Util.GetTextFromAllMatchingElements(driver, itemsNamesInCartXpath);
        }

        public void ClickViewAndEditCartBtn()
        {
            Util.ClickElementByXpath(driver, viewAndEditCartBtnXpath);
        }

        public void closeSidePanel()
        {
            Util.ClickElementByXpath(driver, sidePanelCloseBtn);
        }
    }
}

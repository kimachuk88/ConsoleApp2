using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.pages
{
    class AllItemsPage
    {
        private IWebDriver driver;
        private string itemsInGridXpath = "//li[@class='item']//div[@class='amlabel-div']//a";
        private string itemByNameXpath = "//p[@class='product-name']/a[text()='{0}']";

        public AllItemsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static AllItemsPage InitPage(IWebDriver driver)
        {
            return new AllItemsPage(driver);
        }

        public List<string> getAllAvailableItemsNames()
        {
            return DriverUtil.GetAttributeFromAllMatchingElements(driver, itemsInGridXpath, "title");
        }

        public void ViewItemDetails(string itemName)
        {
            DriverUtil.MoveToItem(driver, string.Format(itemByNameXpath, itemName));
            DriverUtil.ClickElementByXpath(driver, string.Format(itemByNameXpath, itemName));
        }

      
    }
}

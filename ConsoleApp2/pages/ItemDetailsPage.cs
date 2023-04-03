using ConsoleApp2.utils;
using OpenQA.Selenium;
using System.Collections.Generic;


namespace ConsoleApp2.pages
{
    class ItemDetailsPage
    {
        private IWebDriver driver;
        private string itemAddToCartBtnXpath = "//button[@title='Add to Cart']";
        private string dropDownXpath = "//div[contains(@class,'field configurable') and .//span[text()='{0}']]//select";
        private string availableDropDownNames = "//div[@class='product-options-wrapper']//span";


        public ItemDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static ItemDetailsPage InitPage(IWebDriver driver)
        {
            return new ItemDetailsPage(driver);
        }

        public void AddItemToCart()
        {
            
            DriverUtil.ClickElementByXpath(driver, itemAddToCartBtnXpath);
        }

        public bool IsThereAnyOptions()
        {
            return DriverUtil.IsElementDisplayed(driver, availableDropDownNames);
        }

        public List<string> GetAvailableDropDowns()
        {
            return DriverUtil.GetAttributeFromAllMatchingElements(driver, availableDropDownNames, "textContent");
        }

        public void SelectRandomValuesInDropDowns()
        {
            if (IsThereAnyOptions())
            {
                List<string> dropdowns = GetAvailableDropDowns();
                foreach (string dropdown in dropdowns)
                {
                    List<string> dropdownOptions = DriverUtil.GetDropDownOptions(driver, string.Format(dropDownXpath, dropdown));
                    string option = Util.GetRandomItemFromList(dropdownOptions);
                    DriverUtil.SelectOptionInDropdown(driver, string.Format(dropDownXpath, dropdown), option);
                }
            }
        }

    }
}

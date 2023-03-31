using OpenQA.Selenium;

namespace ConsoleApp2
{
    class HomePage
    {
        private IWebDriver driver;
        private string quizCloseBtnXpath = "//div[contains(@id,'dy-quiz')]//div[@class='close-button']";
        private string shopBtnXpath = "//div[@class='action']//span[text()='SHOP']";
        private string topNavMenuItemBtn = "//nav[@id='top_nav']//span[text()='{0}']";
        private string subCategoriesBtn = "//div[@class='block-content toggle-content']//a[text()='{0}']";
        private string itemByNameXpath = "//p[@class='product-name']/a[text()='{0}']";
        private string itemAddToCartBtnXpath = "//li[@class='item' and .//a[text()='{0}']]//button[@title='Add to Cart']";

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static HomePage InitPage(IWebDriver driver)
        {
            return new HomePage(driver);
        }

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
            Util.MoveToItem(driver, string.Format(itemByNameXpath, itemName));
            Util.ClickElementByXpath(driver, string.Format(itemAddToCartBtnXpath, itemName));
        }

        public void CloseQuizIfAppeared()
        {
            if (Util.IsElementDisplayed(driver, quizCloseBtnXpath))
            {
                Util.ClickElementByXpath(driver, quizCloseBtnXpath);
            }
        }
    }
}

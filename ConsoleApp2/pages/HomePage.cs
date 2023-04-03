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
            DriverUtil.ClickElementByXpath(driver, shopBtnXpath);
        }

        public void OpenTopMenu(string menuName)
        {
            DriverUtil.ClickElementByXpath(driver, string.Format(topNavMenuItemBtn, menuName));
        }

        public void OpenSubCategorie(string subcategorieName)
        {
            DriverUtil.ClickElementByXpath(driver, string.Format(subCategoriesBtn, subcategorieName));
        }

        public void CloseQuizIfAppeared()
        {
            if (DriverUtil.IsElementDisplayed(driver, quizCloseBtnXpath))
            {
                DriverUtil.ClickElementByXpath(driver, quizCloseBtnXpath);
            }
        }
    }
}

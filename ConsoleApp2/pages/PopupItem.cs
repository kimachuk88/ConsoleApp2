using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class PopupItem
    {
        IWebDriver driver;

        public PopupItem(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static PopupItem InitPage(IWebDriver driver)
        {
            return new PopupItem(driver);
        }
        private string popupActionBtnXpath = "//div[@class='modal-inner-wrap']//button/span[text()='{0}']";
        private string popupMessageXpath = "//div[@class='modal-inner-wrap' and .//h1[contains(text(),'Attention')]]//div[@class='modal-content']/div";

        public void ClickPopupActionBtn(String buttonName)
        {
            Util.ClickElementByXpath(driver, string.Format(popupActionBtnXpath, buttonName));
        }

        public string GetPopupMessage()
        {
            return Util.GetTextFromElement(driver, popupMessageXpath);
        }
    }
}

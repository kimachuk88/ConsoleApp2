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
        private IWebDriver driver;
        private string popupActionBtnXpath = "//aside[contains(@class,'_show')]//div[@class='modal-inner-wrap']//button/span[text()='{0}']";
        private string popupMessageXpath = "//aside[contains(@class,'_show')]//div[@class='modal-content']/div";
        private string suggestedAddressRadioBtnXpath = "//aside[contains(@class,'_show') and .//label[contains(text(),'{0}')]]//input[@name='candidate']";

       
        public PopupItem(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static PopupItem InitPage(IWebDriver driver)
        {
            return new PopupItem(driver);
        }
 
        public void ClickPopupActionBtn(String buttonName)
        {
            //Util.MoveToItem(driver, string.Format(popupActionBtnXpath, buttonName));
            Util.ClickElementByXpath(driver, string.Format(popupActionBtnXpath, buttonName));
        }

        public string GetPopupMessage()
        {
            //Util.MoveToItem(driver, popupMessageXpath);
            return Util.GetTextFromElement(driver, popupMessageXpath);
        }

        public void SelectSuggestedAddress(string streetAddress, string city)
        {
            string recomendationAddress = String.Join(", ", streetAddress.ToUpper(), city.ToUpper());
            Util.ClickElementByXpath(driver, string.Format(suggestedAddressRadioBtnXpath, recomendationAddress));
            ClickPopupActionBtn("Continue");
        }
    }
}

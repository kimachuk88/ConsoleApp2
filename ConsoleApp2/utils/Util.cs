using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Util
    {
        public static void ClickElementByXpath(IWebDriver driver, String btnXpath)
        {      
            driver.FindElement(By.XPath(btnXpath)).Click();
        }

        public static void InputTextIntoFieldByXpath(IWebDriver driver, String fieldXpath, String text)
        {
            driver.FindElement(By.XPath(fieldXpath)).SendKeys(text);
        }

        public static List<string> GetTextFromAllMatchingElements(IWebDriver driver, String itemXpath)
        {
             return new List<string>(driver.FindElements(By.XPath(itemXpath)).Select(iw => iw.Text));
        }

        public static string GetTextFromElement(IWebDriver driver, String itemXpath)
        {
            return driver.FindElement(By.XPath(itemXpath)).Text;
        }

        public static void HoverOver(IWebDriver driver, string menuXpath)
        {
            IWebElement element = driver.FindElement(By.XPath(menuXpath));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Util
    {
        public static void ClickElementByXpath(IWebDriver driver, String btnXpath)
        {
            WaitUtil.WaitForElement(driver, btnXpath, 10);
            driver.FindElement(By.XPath(btnXpath)).Click();
        }

        public static void InputTextIntoFieldByXpath(IWebDriver driver, String fieldXpath, String text)
        {
            WaitUtil.WaitForElement(driver, fieldXpath, 10);
            IWebElement field = driver.FindElement(By.XPath(fieldXpath));
            field.Clear();
            field.SendKeys(text);
            field.SendKeys(Keys.Tab);
        }

        public static List<string> GetTextFromAllMatchingElements(IWebDriver driver, String itemXpath)
        {
            WaitUtil.WaitForElement(driver, itemXpath, 10);
            return new List<string>(driver.FindElements(By.XPath(itemXpath)).Select(iw => iw.Text));
        }

        public static string GetTextFromElement(IWebDriver driver, String itemXpath)
        {
            WaitUtil.WaitForElement(driver, itemXpath, 10);
            return driver.FindElement(By.XPath(itemXpath)).Text;
        }

        public static void MoveToItem(IWebDriver driver, string menuXpath)
        {
            IWebElement element = driver.FindElement(By.XPath(menuXpath));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }

        public static bool IsElementDisplayed(IWebDriver driver, string menuXpath)
        {
            try
            {
                IWebElement element = driver.FindElement(By.XPath(menuXpath));
                if (element.Displayed)
                {
                    return true;
                }
                else
                {
                    // Element is not displayed, skip the test
                    return false;
                }
            }
            catch (NoSuchElementException)
            {
                // Element not found
                return false;
            }
        }
    }
}

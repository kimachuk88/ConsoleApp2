using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleApp2
{
    class DriverUtil
    {
        public static void ClickElementByXpath(IWebDriver driver, string btnXpath)
        {
            WaitUtil.WaitForElement(driver, btnXpath, 10);
            driver.FindElement(By.XPath(btnXpath)).Click();
        }

        public static void InputTextIntoFieldByXpath(IWebDriver driver, string fieldXpath, string text)
        {
            WaitUtil.WaitForElement(driver, fieldXpath, 10);
            IWebElement field = driver.FindElement(By.XPath(fieldXpath));
            field.Clear();
            field.SendKeys(text);
            field.SendKeys(Keys.Tab);
        }

        public static void InputTextIntoFieldSlowlyByXpath(IWebDriver driver, string fieldXpath, string text, int delay)
        {
            WaitUtil.WaitForElement(driver, fieldXpath, 10);
            IWebElement field = driver.FindElement(By.XPath(fieldXpath));
            field.Clear();
            foreach (char c in text)
            {
                try
                {
                    field.SendKeys(c.ToString());
                    Thread.Sleep(delay);
                }
                catch (ThreadInterruptedException e)
                {
                    Console.WriteLine(e);
                }
            }
            field.SendKeys(Keys.Tab);
        }

        public static List<string> GetTextFromAllMatchingElements(IWebDriver driver, string itemXpath)
        {
            WaitUtil.WaitForElementStopMoving(driver, itemXpath, 10);
            return new List<string>(driver.FindElements(By.XPath(itemXpath)).Select(iw => iw.Text));
        }

        public static List<string> GetAttributeFromAllMatchingElements(IWebDriver driver, string itemXpath, string attributeName)
        {
            WaitUtil.WaitForElement(driver, itemXpath, 10);
            return new List<string>(driver.FindElements(By.XPath(itemXpath)).Select(iw => iw.GetAttribute(attributeName)));
        }

        public static string GetTextFromElement(IWebDriver driver, string itemXpath)
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

        public static List<string> GetDropDownOptions(IWebDriver driver, string dropdownXpath)
        {
            string dropDownOptionsXpath = dropdownXpath + "/option[not(@disabled)]";
            List<string> options = GetTextFromAllMatchingElements(driver, dropDownOptionsXpath);

            // Remove option that is actually asking to choose the option 
            options.Remove("Choose an Option...");
            return options;
        }

        public static void SelectOptionInDropdown(IWebDriver driver, string dropdownXpath, string value)
        {
            string optionXpath = dropdownXpath + string.Format("/option[text()='{0}']", value);
            WaitUtil.WaitForElement(driver, optionXpath, 5);
            new SelectElement(driver.FindElement(By.XPath(dropdownXpath))).SelectByText(value);
        }

        public static void SwitchToFrame(IWebDriver driver, string xpath)
        {
            driver.SwitchTo().Frame(driver.FindElement(By.XPath(xpath)));
        }

        public static void SwitchToDefaultContent(IWebDriver driver)
        {
            driver.SwitchTo().DefaultContent();
        }
    }
}

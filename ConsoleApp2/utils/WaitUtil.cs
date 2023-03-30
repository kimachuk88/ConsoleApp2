using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    static class WaitUtil
    {
        static void waitForElement(IWebDriver driver, string elementXpath, int timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            /*wait.Until(ExpectedConditions.ElementExists(By.XPath(elementXpath)))*/
        }
    }
}

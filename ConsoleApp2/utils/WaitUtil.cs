using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;
using System.Drawing;
using System.Threading;

namespace ConsoleApp2
{
    static class WaitUtil
    {
        public static void WaitForElement(IWebDriver driver, string elementXpath, int timeoutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(elementXpath)));
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Element not found: " + ex.Message);
            }
        }

        public static void WaitForElementStopMoving(IWebDriver driver, string elementXpath, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(elementXpath)));

            // Get the initial position of the element
            Point initialLocation = element.Location;

            // Wait for the element to stop moving
            bool isMoving = true;
            while (isMoving)
            {
                // Wait for 1 second
                Thread.Sleep(1000); 
                Point currentLocation = element.Location;
                if (currentLocation.Equals(initialLocation))
                {
                    isMoving = false;
                }
                else
                {
                    initialLocation = currentLocation;
                }
            }
        }
    }
}

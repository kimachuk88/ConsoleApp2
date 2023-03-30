using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class CheckoutPage
    {
        IWebDriver driver;

        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static CheckoutPage InitPage(IWebDriver driver)
        {
            return new CheckoutPage(driver);
        }

        private string payNowBtnXpath = "//button[@type='submit']/span[text()='Pay Now']";
        private string emailFieldXpath = "//fieldset[@id='customer-email-fieldset']//input[@type='email']";
        private string firstNameFieldXpath = "//div[@name='shippingAddress.firstname']//input[@name='firstname']";
        private string lastNameFieldXpath = "//div[@name='shippingAddress.lastname']//input[@name='lastname']";
        private string streetAddressFieldXpath = "//div[@name='shippingAddress.street.0']//input[@name='street[0]']";
        private string cityFieldXpath = "//div[@name='shippingAddress.city']//input[@name='city']";
        private string postCodeFieldXpath = "//div[@name='shippingAddress.postcode']//input[@name='postcode']";
        private string cardNumberFieldXpath = "//div[@class='CardNumberField-input-wrapper']//input[@name='cardnumber']";
        private string cardExpiryDateFieldXpath = "//span[contains(@class,'CardField-expiry')]//input[@name='exp-date']";

        public void clickPayNowBtn()
        {
            Util.ClickElementByXpath(driver, payNowBtnXpath);
        }

        public void setEmailAddressField(String emailAddress)
        {
            Util.InputTextIntoFieldByXpath(driver, emailFieldXpath, emailAddress);
        }

        public void setFirstNameField(String firstName)
        {
            Util.InputTextIntoFieldByXpath(driver, firstNameFieldXpath, firstName);
        }

        public void setLastNameField(String lastName)
        {
            Util.InputTextIntoFieldByXpath(driver, lastNameFieldXpath, lastName);
        }

        public void setStreetAddressField(String streetAddress)
        {
            Util.InputTextIntoFieldByXpath(driver, streetAddressFieldXpath, streetAddress);
        }

        public void setCityField(String cityField)
        {
            Util.InputTextIntoFieldByXpath(driver, cityFieldXpath, cityField);
        }

        public void setPostCodeField(String postCode)
        {
            Util.InputTextIntoFieldByXpath(driver, postCodeFieldXpath, postCode);
        }

        public void setCardNumberField(String cardNumber)
        {
            Util.InputTextIntoFieldByXpath(driver, cardNumberFieldXpath, cardNumber);
        }

        public void setCardExpiryField(String cardExpiry)
        {
            Util.InputTextIntoFieldByXpath(driver, cardExpiryDateFieldXpath, cardExpiry);
        }
    }
}

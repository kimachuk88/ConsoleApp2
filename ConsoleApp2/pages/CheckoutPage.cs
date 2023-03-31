using OpenQA.Selenium;
using System;

namespace ConsoleApp2
{
    class CheckoutPage
    {
        private IWebDriver driver;
        private string payNowBtnXpath = "//button[@type='submit']/span[text()='Pay Now']";
        private string emailFieldXpath = "//fieldset[@id='customer-email-fieldset']//input[@type='email']";
        private string firstNameFieldXpath = "//div[@name='shippingAddress.firstname']//input[@name='firstname']";
        private string lastNameFieldXpath = "//div[@name='shippingAddress.lastname']//input[@name='lastname']";
        private string streetAddressFieldXpath = "//div[@name='shippingAddress.street.0']//input[@name='street[0]']";
        private string cityFieldXpath = "//div[@name='shippingAddress.city']//input[@name='city']";
        private string postCodeFieldXpath = "//div[@name='shippingAddress.postcode']//input[@name='postcode']";
        private string cardNumberFieldXpath = "//div[@class='CardNumberField-input-wrapper']//input[@name='cardnumber']";
        private string cardExpiryDateFieldXpath = "//span[contains(@class,'CardField-expiry')]//input[@name='exp-date']";
        private string cardCVCFieldXpath = "//span[contains(@class,'CardField-cvc')]//input[@name='cvc']";
        private string telephoneFieldXpath = "//form[@id='co-shipping-form']//input[@name='telephone']";
        private string paymentDeclinedMessageXpath = "//div[@data-role='checkout-messages']//div[@data-ui-id='checkout-cart-validationmessages-message-error']";

        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static CheckoutPage InitPage(IWebDriver driver)
        {
            return new CheckoutPage(driver);
        }

        public void clickPayNowBtn()
        {
            Util.ClickElementByXpath(driver, payNowBtnXpath);
        }

        public void SetEmailAddressField(String emailAddress)
        {
            Util.InputTextIntoFieldByXpath(driver, emailFieldXpath, emailAddress);
        }

        public void SetFirstNameField(String firstName)
        {
            Util.InputTextIntoFieldByXpath(driver, firstNameFieldXpath, firstName);
        }

        public void SetLastNameField(String lastName)
        {
            Util.InputTextIntoFieldByXpath(driver, lastNameFieldXpath, lastName);
        }

        public void SetStreetAddressField(String streetAddress)
        {
            Util.InputTextIntoFieldByXpath(driver, streetAddressFieldXpath, streetAddress);
        }

        public void SetCityField(String cityField)
        {
            Util.InputTextIntoFieldByXpath(driver, cityFieldXpath, cityField);
        }

        public void SetPostCodeField(String postCode)
        {
            Util.InputTextIntoFieldByXpath(driver, postCodeFieldXpath, postCode);
        }

        public void SetTelephoneField(String telephone)
        {
            Util.InputTextIntoFieldByXpath(driver, telephoneFieldXpath, telephone);
        }

        public void SetCardNumberField(String cardNumber)
        {
            Util.InputTextIntoFieldByXpath(driver, cardNumberFieldXpath, cardNumber);
        }

        public void SetCardExpiryField(String cardExpiry)
        {
            Util.InputTextIntoFieldByXpath(driver, cardExpiryDateFieldXpath, cardExpiry);
        }

        public void SetCardCVCField(String cardCVC)
        {
            Util.InputTextIntoFieldByXpath(driver, cardCVCFieldXpath, cardCVC);
        }

        public string GetDeclinedPaymentMessage()
        {
            WaitUtil.WaitForElement(driver, paymentDeclinedMessageXpath, 10);
            return Util.GetTextFromElement(driver, paymentDeclinedMessageXpath);
        }
    }
}

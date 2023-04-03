using ConsoleApp2.pages;
using ConsoleApp2.utils;
using NUnit.Framework;
using System.Collections.Generic;

namespace ConsoleApp2
{
    [TestFixture]
    class UIEndToEndTest : BaseTest
    {
        string itemCategory = "RIDE";
        string itemSubCategory = "All";
        string userEmail = "someone@whocares.com";
        string userFirstName = "Test";
        string userLastName = "Tester";
        string userAddress = "2208 Oakton St";
        string userCity = "Park Ridge";
        string userZipCode = "60068";
        string userTelephone = "4121234456";
        string userCardNumber = "4111111111111111";
        string userCardExpDate = "0226";
        string userCardCVC = "123";

        [SetUp]
        public void InitPages()
        {
            homePage = HomePage.InitPage(driver);
            checkoutPage = CheckoutPage.InitPage(driver);
            popupItem = PopupItem.InitPage(driver);
            mainCartPage = MainCartPage.InitPage(driver);
            sidePanel = SidePanel.InitPage(driver);
            allItemsPage = AllItemsPage.InitPage(driver);
            itemDetailsPage = ItemDetailsPage.InitPage(driver);
        }

        [Test]
        public void Test1()
        {
            // Wait for possible banner quiz and close if appear
            homePage.CloseQuizIfAppeared();

            // Select random product from any category
            homePage.OpenTopMenu(itemCategory);
            homePage.OpenSubCategorie(itemSubCategory);
            List<string> itemsOnPage = allItemsPage.getAllAvailableItemsNames();
            string primaryItem = Util.GetRandomItemFromList(itemsOnPage);
            allItemsPage.ViewItemDetails(primaryItem);

            // If product has color option or other, select random
            itemDetailsPage.SelectRandomValuesInDropDowns();

            // Add it to the cart
            itemDetailsPage.AddItemToCart();

            // Verify that side-bar cart appears with added product
            List<string> itemsInCart = sidePanel.GetNamesOfItemsInCart();
            Assert.That(itemsInCart.Contains(primaryItem), primaryItem + " was not found in cart");
            sidePanel.closeSidePanel();

            // Go back to product category and select another random product and add it to the cart, too.
            homePage.OpenTopMenu(itemCategory);
            homePage.OpenSubCategorie(itemSubCategory);
            string secondaryItem = Util.GetRandomItemFromList(itemsOnPage);
            allItemsPage.ViewItemDetails(secondaryItem);
            itemDetailsPage.SelectRandomValuesInDropDowns();
            itemDetailsPage.AddItemToCart();

            // Verify that side-bar cart appears with added product
            itemsInCart = sidePanel.GetNamesOfItemsInCart();
            Assert.That(itemsInCart.Contains(primaryItem), primaryItem + " was not found in cart");
            Assert.That(itemsInCart.Contains(secondaryItem), secondaryItem + " was not found in cart");

            // After the side-bar slides out again, click the removal button under one of the items. 
            sidePanel.RemoveItemFromCart(secondaryItem);

            // Confirm with the following pop-up
            popupItem.ClickPopupActionBtn("OK");
            itemsInCart = sidePanel.GetNamesOfItemsInCart();

            // Verify that item successfully removed from the cart.
            Assert.That(itemsInCart.Contains(primaryItem), primaryItem + " was not found in cart");
            Assert.That(!itemsInCart.Contains(secondaryItem), secondaryItem + " was found in cart");

            // At the bottom of the cart side-bar, click on the edit cart link - should be taken to cart page.
            sidePanel.ClickViewAndEditCartBtn();

            // Change the quantity of the item in the cart and click the update cart button.
            double primaryItemUnitPrice = mainCartPage.GetItemPrice(primaryItem, "Unit Price");
            double initialSubtotalPrice = mainCartPage.GetItemPrice(primaryItem, "Subtotal");
            Assert.That(primaryItemUnitPrice == initialSubtotalPrice, "Total and Subtotal are different");

            // Change the quantity of the item in the cart and click the update cart button.
            mainCartPage.SetItemQty(primaryItem, "2");

            // Prices should update to reflect the change.
            double subtotalAfterQtyChange = mainCartPage.GetItemPrice(primaryItem, "Subtotal");
            double expectedSubtotal = initialSubtotalPrice + primaryItemUnitPrice;
            Assert.That(expectedSubtotal == subtotalAfterQtyChange, "Price was not changed");

            // Click the blue proceed to checkout button. Should be taken to the checkout details page.
            mainCartPage.ClickProceedToCheckoutBtn();

            // Click the blue place order button without filling in any info. Error messages should appear.
            checkoutPage.clickPayNowBtn();
            Assert.That(popupItem.GetPopupMessage().Equals("No shipping method selected"));
            popupItem.ClickPopupActionBtn("OK");

            // Enter any email, name, address, phone, credit card
            checkoutPage.SetEmailAddressField(userEmail);
            checkoutPage.SetFirstNameField(userFirstName);
            checkoutPage.SetLastNameField(userLastName);
            checkoutPage.SetTelephoneField(userTelephone);
            checkoutPage.SetStreetAddressField(userAddress);
            checkoutPage.SetCityField(userCity);
            checkoutPage.SetPostCodeField(userZipCode);
            popupItem.SelectSuggestedAddress(userAddress, userCity);
            checkoutPage.SetCardDetailsFields(userCardNumber, userCardExpDate, userCardCVC);

            // Click the blue place order button.
            checkoutPage.clickPayNowBtn();

            // Verify that payment is declined.
            string expectedMessage = "Your card was declined. Your request was in live mode, but used a known test card.";
            Assert.That(checkoutPage.GetDeclinedPaymentMessage().Equals(expectedMessage));
        }

    }
}

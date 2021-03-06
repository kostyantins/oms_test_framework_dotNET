﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using oms_test_framework_dotNET.Utils;
using oms_test_framework_dotNET.Enums;

namespace oms_test_framework_dotNET.Tests.Customer
{
    [TestClass]
    public class LogOutTest : TestRunner
    {

        [TestInitialize]
        public void SetUp()
        {
            userInfoPage = logInPage.LogInAs(Roles.CUSTOMER);
            customerOrderingPage = userInfoPage.ClickCustomerOrderingLink();
        }

        [TestMethod]
        public void TestCustomerOrderingPageLogOutAbility()
        {
            Assert.IsTrue(customerOrderingPage.createNewOrderLink.IsDisplayed(),
                "Customer Ordering page doesn't exist");
            customerOrderingPage.DoLogOut();
            Assert.IsTrue(logInPage.usernameInput.IsDisplayed(),
                "Logout is not working");
        }

        [TestMethod]
        public void TestCreateNewOrderPageLogOutAbility()
        {
            createNewOrderPage = customerOrderingPage.ClickCreateNewOrderLink();
            Assert.IsTrue(createNewOrderPage.cVV2Text.IsDisplayed(),
                "Create new order page doesn't exists");
            createNewOrderPage.DoLogOut();
            Assert.IsTrue(logInPage.usernameInput.IsDisplayed(),
                "Logout is not working");
        }

        [TestMethod]
        public void TestAddItemPageLogOutAbility()
        {
            createNewOrderPage = customerOrderingPage.ClickCreateNewOrderLink();
            addItemPage = createNewOrderPage.ClickAddItemButton();
            Assert.IsTrue(addItemPage.resetButton.IsDisplayed(),
                "Add item page doesn't exists");
            addItemPage.DoLogOut();
            Assert.IsTrue(logInPage.usernameInput.IsDisplayed(),
                "Logout is not working");
        }

        [TestMethod]
        public void TestOrderItemsErrorMessagePageLogOutAbility()
        {
            createNewOrderPage = customerOrderingPage.ClickCreateNewOrderLink();
            addItemPage = createNewOrderPage.ClickAddItemButton();
            addItemPage
                .ClickSelectFirstItemLink()
                .ClickDoneButton();
            createNewOrderPage
                .orderNumberField
                .Clear();
            orderItemsErrorMessagePage = createNewOrderPage
                            .ClickPreferableDeliveryDateChooseLink()
                            .ClickCalendarMonthForwardButton()
                            .ClickDateLink()
                            .SelectAssigneeDropdown("login1")
                            .ClickSaveButtonFail();
            Assert.IsTrue(orderItemsErrorMessagePage.orderItemsErrorMessageText.IsDisplayed(),
                "Order items error message page doesn't exists");
            orderItemsErrorMessagePage.DoLogOut();
            Assert.IsTrue(logInPage.usernameInput.IsDisplayed(),
                "Logout is not working");
        }
    }
}

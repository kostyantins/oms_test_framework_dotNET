﻿using oms_test_framework_dotNET.Utils;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using oms_test_framework_dotNET.Enums;
using oms_test_framework_dotNET.Domains;
using oms_test_framework_dotNET.DBHelpers;

namespace oms_test_framework_dotNET.Tests.Supervisor
{
    [TestClass]
    public class AddNewProductTest : TestRunner
    {
        private const String ValidProductName = "UniqueName";
        private const String ValidProductDescription = "testProductDescription";
        private const String ValidProductPrice = "10.0";

        [TestInitialize]
        public void SetUp()
        {
            userInfoPage = logInPage.LogInAs(Roles.SUPERVISOR);
            itemManagementPage = userInfoPage.ClickItemManagementLink();
            addProductPage = itemManagementPage.ClickAddProductLink();
        }

        [TestMethod]
        public void TestAddValidProduct()
        {
            addProductPage.FillProductNameInput(ValidProductName)
                .FillProductDescriptionInput(ValidProductDescription)
                .FillProductPriceInput(ValidProductPrice)
                .ClickOkButton();

            Product testProduct = DBProductHandler.GetLastProduct();

            itemManagementPage.FillSearchInput(ValidProductName)
                .ClickSearchButton();

            Assert.AreEqual(itemManagementPage.firstProductNameText.GetText(),
                ValidProductName, "Product name {0} does not equal to created one {1}",
                itemManagementPage.firstProductNameText.GetText(), ValidProductName);

            Assert.AreEqual(itemManagementPage.firstProductDescriptionText.GetText(),
                ValidProductDescription, "Product description {0} does not equal to created one {1}",
                itemManagementPage.firstProductDescriptionText.GetText(), ValidProductDescription);

            Assert.AreEqual(itemManagementPage.firstProductPriceText.GetText(),
                ValidProductPrice, "Product price {0} does not equal to created one {1}",
                itemManagementPage.firstProductPriceText.GetText(), ValidProductPrice);

            DBProductHandler.DeleteProduct(testProduct.Id);
        }

        [TestMethod]
        public void TestCancelAddProduct()
        {
            addProductPage.FillProductNameInput(ValidProductName)
                .FillProductDescriptionInput(ValidProductDescription)
                .FillProductPriceInput(ValidProductPrice)
                .ClickCancelButton();

            itemManagementPage.FillSearchInput(ValidProductName)
               .ClickSearchButton();

            Assert.AreEqual(itemManagementPage.countOfProductFound.GetText(), "0",
                "Product has been unexpectely created !");
        }

        [TestMethod]
        public void TestInvalidInput()
        {
            const String InvalidShortName = "FU";
            const String InvalidLongName = "TestProductName";
            const String InvalidDescription = "InvalidProductDescriptionTest";
            const String InvalidPrice = "12345678901234";

            addProductPage.FillProductNameInput("")
                    .FillProductDescriptionInput("")
                    .FillProductPriceInput("")
                    .ClickOkButton();

            Assert.AreEqual(addProductPage.productNameErrorText.GetText(),
                "Please enter product name!", "Error message is not appeared or is incorrect !");
            Assert.IsTrue(addProductPage.productDescriptionErrorText.GetText() == "",
                "Unexpected error message !");
            Assert.AreEqual(addProductPage.productPriceErrorText.GetText(),
                "Please enter product price!", "Error message is not appeared or is incorrect !");

            addProductPage.FillProductNameInput(InvalidShortName)
                    .FillProductDescriptionInput(InvalidDescription)
                    .FillProductPriceInput(InvalidPrice)
                    .ClickOkButton();

            Assert.AreEqual(addProductPage.productNameErrorText.GetText(),
                "Enter value in range: 3-13", "Error message is not appeared or is incorrect !");
            Assert.AreEqual(addProductPage.productDescriptionErrorText.GetText(),
                "Enter less then 25 letters", "Error message is not appeared or is incorrect !");
            Assert.AreEqual(addProductPage.productPriceErrorText.GetText(),
                "Please enter double value!", "Error message is not appeared or is incorrect !");

            addProductPage.FillProductNameInput(InvalidLongName)
                    .FillProductDescriptionInput(InvalidDescription)
                    .FillProductPriceInput(InvalidPrice)
                    .ClickOkButton();

            Assert.AreEqual(addProductPage.productNameErrorText.GetText(),
                "Enter value in range: 3-13", "Error message is not appeared or is incorrect !");
            Assert.AreEqual(addProductPage.productDescriptionErrorText.GetText(),
                "Enter less then 25 letters", "Error message is not appeared or is incorrect !");
            Assert.AreEqual(addProductPage.productPriceErrorText.GetText(),
                "Please enter double value!", "Error message is not appeared or is incorrect !");
        }

    }
}

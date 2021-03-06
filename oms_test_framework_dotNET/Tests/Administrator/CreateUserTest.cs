﻿using oms_test_framework_dotNET.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using oms_test_framework_dotNET.Enums;
using oms_test_framework_dotNET.DBHelpers;

namespace oms_test_framework_dotNET.Tests
{
    [TestClass]
    public class CreateUserTest : TestRunner
    {
        private string userLogin = "StefDevis";
        private int createdUserId;

        [TestMethod]
        public void TestCreateNewUserAbility()
        {
            administrationPage = logInPage
                     .LogInAs(Roles.ADMINISTRATOR)
                     .ClickAdministrationLink();

            Assert
                .IsTrue(administrationPage.foundUsersTextLabel.IsDisplayed(),
                "The Admin page should be displayed!");

            createUserPage = administrationPage.ClickCreateNewUser();

            Assert
                .IsTrue(createUserPage.loginNameLabel.IsDisplayed(),
                "The CreateNewUserPage should be displayed!");

            createUserPage
            .FillLoginField(userLogin)
            .FillFirstNameField("Stef")
            .FillLastNameField("Devis")
            .FillPasswordField("qwerty")
            .FillConfirmPasswordField("qwerty")
            .FillEmailField("StefDevis@gmail.com")
            .ChooseRegion("North")
            .ChooseRole("Customer");

            createUserPage.ClickCreateButton();

            createdUserId = DBUserHandler.GetUserByLogin(userLogin).Id;

            Assert
                .IsTrue(administrationPage.foundUsersTextLabel.IsDisplayed(),
                "The Admin page should be displayed!");

            administrationPage
                .FillFieldFilter("Login")
                .FillConditionFilter("equal")
                .FillSearchInputField("StefDevis")
                .ClickSearchButton();

            Assert
                .AreEqual("StefDevis", administrationPage.logInFirstCellLink.GetText(),
                "As a result of the search should be a user with the specified login");

            administrationPage.DeleteUserByLogIn("StefDevis");
        }

        [TestCleanup]
        public void TearDown()
        {
            DBUserHandler.DeleteUser(createdUserId);
        }
    }
}

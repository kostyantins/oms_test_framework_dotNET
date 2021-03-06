﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using oms_test_framework_dotNET.Utils;
using oms_test_framework_dotNET.Enums;

namespace oms_test_framework_dotNET.Tests.Administrator
{
    [TestClass]
    public class LogOutTest : TestRunner
    {

        [TestInitialize]
        public void SetUp()
        {
            userInfoPage = logInPage.LogInAs(Roles.ADMINISTRATOR);
            administrationPage = userInfoPage.ClickAdministrationLink();
        }

        [TestMethod]
        public void TestAdministrationPageLogOutAbility()
        {
            Assert.IsTrue(administrationPage.foundUsersTextLabel.IsDisplayed(),
                "Administration page doesn't exist");
            administrationPage.DoLogOut();
            Assert.IsTrue(logInPage.usernameInput.IsDisplayed(),
                "Logout is not working");
        }

        [TestMethod]
        public void TestCreateReportPageLogOutAbility()
        {
            administratorCreateReportPage = administrationPage.ClickCreateReportLink();
            Assert.IsTrue(administratorCreateReportPage.saveReportLink.IsDisplayed(),
                "Create Report page doesn't exist");
            administratorCreateReportPage.DoLogOut();
            Assert.IsTrue(logInPage.usernameInput.IsDisplayed(),
                "Logout is not working");
        }

        [TestMethod]
        public void TestCreateUserPageLogOutAbility()
        {
            createUserPage = administrationPage.ClickCreateNewUser();
            Assert.IsTrue(createUserPage.loginNameLabel.IsDisplayed(),
                "Create new user page doesn't exists");
            createUserPage.DoLogOut();
            Assert.IsTrue(logInPage.usernameInput.IsDisplayed(),
                "Logout is not working");
        }

        [TestMethod]
        public void TestEditUserPageLogOutAbility()
        {
            editUserPage = administrationPage.ClickEditFirstUserLink();
            Assert.IsTrue(editUserPage.confirmPasswordText.IsDisplayed(),
                "Edit user page doesn't exists");
            editUserPage.DoLogOut();
            Assert.IsTrue(logInPage.usernameInput.IsDisplayed(),
                "Logout is not working");
        }
    }
}

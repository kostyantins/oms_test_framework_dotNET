﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using oms_test_framework_dotNET.Utils;
using oms_test_framework_dotNET.Enums;

namespace oms_test_framework_dotNET.Tests.Administrator
{
    [TestClass]
    public class PositiveLogInTest : TestRunner
    {
        [TestMethod]
        public void TestValidLogInAdministrator()
        {
            userInfoPage = logInPage.LogInAs(Roles.ADMINISTRATOR);
            Assert.IsTrue(userInfoPage.userInfoFieldSet.GetText().Equals("User Info"), "Login with administrator valid credentials is not successful");
        }
    }
}

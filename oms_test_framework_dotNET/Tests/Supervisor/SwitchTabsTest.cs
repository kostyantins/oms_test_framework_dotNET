﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using oms_test_framework_dotNET.Utils;
using System.Diagnostics;

namespace oms_test_framework_dotNET.Tests.Supervisor
{
    [TestClass]
    public class SwitchTabsTest : TestRunner
    {

        [TestInitialize]
        public void SetUpTest()
        {
            const string SupervisorLogin = "login2";
            const string SupervisorPassword = "qwerty";
            userInfoPage = logInPage.LogInAs(SupervisorLogin, SupervisorPassword);
        }

        [TestMethod]
        public void TestSwitchTabsAbility()
        {
            itemManagementPage = userInfoPage.ClickItemManagementLink();
            Assert.IsTrue(itemManagementPage.SearchByFieldSet.Displayed, "Current page is not {0}", itemManagementPage);
            itemManagementPage.ClickUserInfoLink();
            Assert.IsTrue(userInfoPage.UserInfoFieldSet.Displayed, "Current page is not {0}", userInfoPage);
        }
    }
}

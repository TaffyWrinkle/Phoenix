﻿namespace Phoenix.Test.UI.TestCases
{
    using System;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;

    using Phoenix.Test.Data;
    using Phoenix.Test.UI.Framework;
    using Phoenix.Test.UI.Framework.Logging;
    //using Phoenix.Test.UI.Framework.Authentication;
    //using Phoenix.Test.UI.Framework.Configuration;
    using Phoenix.Test.UI.Framework.Controls;
    //using Phoenix.Test.UI.Framework.Shared;
    using Phoenix.Test.UI.Framework.WebPages;
    using Phoenix.Test.Common;
    using Microsoft.VisualStudio.TestTools;
    using Microsoft.VisualStudio.TestTools.UnitTesting;


    [TestClass]
    //[SignInAs(EUserTypes.Regular)]
    public class AdminPortalTest : WAPTestBase
    {

        private AdminLoginPage loginPage;

        private string userName;
        private string password;
        private string serverName;

        private string clientId;
        private string clientKey;
        private string tenantId;
        private string azureSubscription;
        //private string url;

        public AdminPortalTest(string userAccount, string password, string serverName, string clientId, string clientKey, string tenantId, string azureSubscription)
        {
            this.userName = userAccount;
            this.password = password;
            this.serverName = serverName;

            this.clientId = clientKey;
            this.clientKey = clientKey;
            this.tenantId = tenantId;
            this.azureSubscription = azureSubscription;
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Log.Information("Start test init.");
            driver.Url = "https://" + serverName + ":30091";

            Log.Information("Get user and password.");
            this.loginPage = new AdminLoginPage(driver);
            loginPage.Login("", password);

            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(10000);
        }


        [TestMethod,
        Owner(TestOwners.JohnYu),
        Priority(TestPriority.P0),
        TestCategory(TestCategory.BVT),
        Description("Verify administrator can create a plan.")]
        public void AdminCreatePlanTest()
        {
            Log.Information("---Start AdminCreatePlanTest---");
            TestInitialize();
            var smpPage = new SmpPage(this.driver);

            var data = GetCreatePlanData();

            smpPage.CreatePlanFromNewButton(data);

            //Assert.IsTrue(smpPage.VerifyPlanCreated(data), "Failed to create plan from new button.");
        }

        [TestMethod,
        Owner(TestOwners.JohnYu),
        Priority(TestPriority.P0),
        TestCategory(TestCategory.BVT),
        Description("Verify administrator can create a add-on.")]
        public void AdminCreateAddonTest(CreateAddonData data)
        {
            Log.Information("---Start AdminCreateAddonTest---");
            TestInitialize();
            var smpPage = new SmpPage(this.driver);

            smpPage.CreateAddonFromNewButton(data);


            //////Assert.IsTrue(smpPage.VerifyPlanCreated(data), "Failed to create plan from new button.");
        }

        public void AdminOnboardSubscriptionTest(CreateAddonData data)
        {
            var smpPage = new SmpPage(this.driver);
            Log.Information("---Open Addons List Page---");
            smpPage.OpenMenuPlans(); // CHECK HERE INDEX OUT OF RANGE !!!

            var page = new AddonListPage(this.driver);
            page.SelectAddonInTableAndCheckDatails(data.addonName);

            var configPage = new AddonConfigPage(this.driver);
            configPage.OnboardSubscription(data);


        }


        public void AdminConfigureAddon()
        {
            var addonConfigPage = new AddonConfigPage(this.driver);

        }


        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        public CreatePlanData GetCreatePlanData()
        {
            string anyPlanName = GetRandomPlanName();
            return new CreatePlanData() { planName = anyPlanName, groupName = "Group01", userName = "test01@microsoft.com", localAdminPassword = "Password0)" };
        }

        public CreateAddonData GetCreateAddonData(string clientId, string clientKey, string tenantId, string azureSubscription)
        {
            string anyAddonName = GetRandomAddonName();
            return new CreateAddonData() { addonName = anyAddonName, clientId = clientId, clientKey = clientKey, tenantId = tenantId, azureSubscription = azureSubscription};
        }

        public string GetRandomPlanName()
        {
            return "Plan" + TestDataUtils.GetRandomString(4);
        }

        public string GetRandomAddonName()
        {
            return "Addon" + TestDataUtils.GetRandomString(4);
        }
    }
}
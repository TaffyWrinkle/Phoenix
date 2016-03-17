﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using Phoenix.Test.UI.Framework.Advertiser.Pages;
using Phoenix.Test.UI.Framework;
using Phoenix.Test.UI.Framework.WebPages;
using Phoenix.Test.UI.TestCases;
using Phoenix.Test.Data;
using Phoenix.Test.Installation.TestCase;
//using Phoenix.Test.UI.Framework.Configuration;
//using Framework;
//using Framework.Authentication;
//using Framework.Helper;
//using Framework.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
//using CampaignSummaryPage = Framework.Advertiser.Pages.CampaignSummaryPage;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Phoenix.Test.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.textBox_UserName.Text) || String.IsNullOrWhiteSpace(this.textBox_Password.Text)  || 
                String.IsNullOrWhiteSpace(this.textBox_AdminPortalServer.Text))
            {
                MessageBox.Show("Please input Administrator username, password, and Admin Portal Servername.");
                return;
            }

            var test = new AdminPortalTest(this.textBox_UserName.Text, this.textBox_Password.Text, this.textBox_AdminPortalServer.Text);
            test.AdminCreateUserAccountTest();
        }


        //not sure what this is doing in here - KH
        public void TestCase02()
        {
            var driver = new FirefoxDriver();
            var page = new SmpPage(driver);
            //string user = "test01@microsoft.com";
            //string psw = GetPassword();

            driver.Url = "https://khphoenixsql2.redmond.corp.microsoft.com:30081/#Workspaces/All/dashboard";
            driver.Manage().Window.Maximize();
            //page.AddSubscription();
        }

        [TestInitialize]
        public static void Init()
        {
            MessageBox.Show("Init");
            //var campaignSummaryPage = NavigateToPage<CampaignSummaryPage>();
            //var campaignCount = campaignSummaryPage.CampaignGridRowCount();

            //if (campaignCount < 2)
            //{
            //    for (var i = 0; i < 2 - campaignCount; i++)
            //    {
            //        HavingCreated(aMinimalValidCampaign()
            //            .WithName(expectedCampaignName()[i]));
            //    }
            //}

            //var keywordSummaryPage = campaignSummaryPage.MainCampaignSummarySection.NavigateKeywordsTab();

            //keywords = keywordSummaryPage.OpenAddKeywords();

            //campaignList = keywords.GetCampaignListOptionText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.textBox_TenantUserAccount.Text) || String.IsNullOrWhiteSpace(this.textBox_TenantPassword.Text) ||
                String.IsNullOrWhiteSpace(this.textBox_TenantPortalServer.Text))
            {
                MessageBox.Show("Please input Tenant username, password, and Admin Portal Servername.");
                return;
            }

            var test = new TenantPortalTest(this.textBox_TenantUserAccount.Text, this.textBox_TenantPassword.Text, this.textBox_TenantPortalServer.Text);
            test.TestInitialize();
            test.TenantCreateVmFromNewButtonTest();
            test.TestCleanup();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_TestPlan_Click(object sender, EventArgs e)
        {
            cmpwapProgressBar.Value = 1;
            cmpwapProgressBar.Maximum = 23;

            lblCheckDatabases.Text = "CHECKING DATABASES...";
            var databasesTest = new installationTest();
            databasesTest.Initialize();
            databasesTest.dbTest(textBox_SQLAdmin.Text,textBox_SQLAdmPswd.Text, textBox_ServerName.Text);
            
            if (databasesTest.GetPass())
            {
                databasesPic.BackgroundImage = imageList1.Images[1];
                lblCheckDatabases.Text = "DATABASES CHECKED - PASSED";
            }
            else
            {
                databasesPic.BackgroundImage = imageList1.Images[0];
                lblCheckDatabases.Text = "DATABASES CHECKED - FAILED";
            }
            for (int progressCount = 0; progressCount < 2; progressCount++)
            {
                cmpwapProgressBar.PerformStep();
            }
 

            lblCheckServices.Text = "CHECKING CMP AND RELATED SERVICES...";
            var servicesTest = new installationTest();
            servicesTest.Initialize();
            servicesTest.serviceTest(textBox_ServerName.Text);

            if (servicesTest.GetPass())
            {
                servicesPic.BackgroundImage = imageList1.Images[1];
                lblCheckServices.Text = "CMP AND RELATED SERVICES - PASSED";
            }
            else
            {
                servicesPic.BackgroundImage = imageList1.Images[0];
                lblCheckServices.Text = "CMP AND RELATED SERVICES - FAILED";
            }
            for (int progressCount = 0; progressCount < 2; progressCount++)
            {
                cmpwapProgressBar.PerformStep();
            }

            lblCheckWebApps.Text = "CHECKING WEB APPS...";
            var sitesTest = new installationTest();
            sitesTest.Initialize();
            sitesTest.siteTest(textBox_ServerName.Text);

            if (sitesTest.GetPass())
            {
                webappsPic.BackgroundImage = imageList1.Images[1];
                lblCheckWebApps.Text = "WEB APPS - PASSED";
            }
            else
            {
                webappsPic.BackgroundImage = imageList1.Images[0];
                lblCheckWebApps.Text = "WEB APPS - FAILED";
            }
            for (int progressCount = 0; progressCount < 17; progressCount++)
            {
                cmpwapProgressBar.PerformStep();
            }
        }
        private void ResourceProviderTest()
        {

        }

        private void textBox_ServerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_TenantPassword_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
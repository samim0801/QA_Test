using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation;
using Steps;
using System.Configuration;
using Homeaway_QA_Test.Pages;

namespace Homeaway_QA_Test.TestCases
{
    [TestClass]
    public class VerifySettings : TestBase
    {

        string strappLoginUrl = ConfigurationManager.AppSettings["appLoginUrl"];
        string strBrowser = ConfigurationManager.AppSettings["browser"];
        public VerifySettings()
        {
            base.initializeTestBase(strBrowser, strappLoginUrl);
        }

        public TestContext TestContext
        {
            get;
            set;
        }

        TestSteps testSteps = new TestSteps();

        [Description("Verify user is successfully able to add and delete preference")]
        [TestMethod]
        public void TC_001_VerifyPreferences()
        {
            try
            {
                AssertFor assertFor = new AssertFor();
                TestContext.WriteLine("Test execution started");

                LoginPage loginPage = new LoginPage(base.getDriver());
                IndexPage indexPage = loginPage.Login();
                testSteps.AddSteps(assertFor, "Log-in in to V12.Net");

                LmsPage lmsHomePage = indexPage.OpenLMS();
                testSteps.AddSteps(assertFor, "Open Lead Management System");

                SettingsPage settingsPage = lmsHomePage.GoToSettings();
                settingsPage.AddPreference();
                testSteps.AddSteps(assertFor, "Go to Settings and Add New Preference");

                string strAddedPref = settingsPage.getAddedPreferenceName();
                string strAllPref = settingsPage.getAllPreferenceDetail();

                assertFor.IsTrue(strAllPref.Contains(strAddedPref), "Preference addition is not working properly");
                settingsPage.DeletePreference();

                strAllPref = settingsPage.getAllPreferenceDetail();
                assertFor.IsTrue(!strAllPref.Contains(strAddedPref), "Preference deletion is not working properly");
                testSteps.AddSteps(assertFor, "Verify Preference added & deleted successfully");

                settingsPage.GotoHome();
                indexPage.logout();
                testSteps.AddSteps(assertFor, "Log out from V12.Net Application");

                assertFor.CheckExceptions();
                TestContext.WriteLine("Test execution successfully");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Test execution failed. Exception : {0}", ex.Message);
                throw;
            }
            finally
            {
                TestContext.WriteLine(testSteps.RetrieveAllExecutionInformation().ToString());
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            base.TestBaseCleanUp();
        }
    }
}

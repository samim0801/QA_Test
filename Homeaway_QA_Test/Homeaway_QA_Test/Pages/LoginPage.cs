using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Homeaway_QA_Test.Pages
{
    public class LoginPage : PageBase
    {
        string strCompanyCode;
        string strLoginId;
        string strPassword;
        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {
            PageInit();
        }

        private void PageInit()
        {        
            strCompanyCode = ConfigurationManager.AppSettings["companyCode"];
            strLoginId = ConfigurationManager.AppSettings["loginId"];
            strPassword = ConfigurationManager.AppSettings["password"];
        }

        [FindsBy(How = How.Name, Using = "txtCompanyCode")]
        public IWebElement txtCompanyCode { get; set; }

        [FindsBy(How = How.Name, Using = "txtLogin")]
        public IWebElement txtLogin { get; set; }

        [FindsBy(How = How.Name, Using = "txtPassword")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Name , Using = "loginForm")]
        public IWebElement frmLogin { get; set; }

        [FindsBy(How = How.Name, Using = "SubmitButton")]
        public IWebElement btnSubmit { get; set; }              

        public IndexPage Login()
        {
            WaitForElementVisible(By.Name("SubmitButton"));
         
            txtCompanyCode.SendKeys(strCompanyCode);
            txtLogin.SendKeys(strLoginId);
            txtPassword.SendKeys(strPassword);

            btnSubmit.Click();
            IndexPage indexPage = new IndexPage(base.webDriver);
            return indexPage;
        }
    }
}

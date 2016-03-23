using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Homeaway_QA_Test.Pages
{
    public class IndexPage : PageBase
    {       
        public IndexPage(IWebDriver webDriver) : base(webDriver)
        {
         
        }
     
        [FindsBy(How = How.PartialLinkText, Using = "Reservations")]
        public IWebElement lnkReservation { get; set; }


        [FindsBy(How = How.Name, Using = "ctl00$btnLogout")]
        public IWebElement btnLogout { get; set; }        

        By pageVerifyElement = By.Id("ctl00_lblLms");
        By frmElement = By.TagName("iframe");
        By frmVerifyElement = By.PartialLinkText("Inbox");
        By lmsLinkElement = By.PartialLinkText("Lead Management System");
                
        public LmsPage OpenLMS()
        {
            WaitForElementVisible(pageVerifyElement);
            lnkReservation.Click();

            IWebElement lnkLMS =  WaitForElementVisible(lmsLinkElement);
            lnkLMS.Click();

            IWebElement frmLMS = WaitForElementVisible(frmElement);
            base.SwitchToFrame(frmLMS);

            WaitForElementVisible(frmVerifyElement);
         
            LmsPage lmsHomePage = new LmsPage(base.webDriver);
            return lmsHomePage;
        }
        public void logout()
        {
            btnLogout.Click();
        }
    }
}

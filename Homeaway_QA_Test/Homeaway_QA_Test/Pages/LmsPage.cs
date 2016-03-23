using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Homeaway_QA_Test.Pages
{
    public class LmsPage : PageBase
    {
        public LmsPage(IWebDriver webDriver) : base(webDriver)
        {
         
        }

        [FindsBy(How = How.ClassName, Using = "dropdown")]
        public IWebElement lnkInquiry { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Settings")]
        public IWebElement lnkSetting { get; set; }

        public SettingsPage GoToSettings()
        {          
            lnkInquiry.Click();

            lnkSetting.Click();

            SettingsPage settingsPage = new SettingsPage(base.webDriver);
            return settingsPage;
        }
    }
}

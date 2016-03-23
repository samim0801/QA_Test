using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
namespace Homeaway_QA_Test.Pages
{
    public class SettingsPage : PageBase
    {
        public SettingsPage(IWebDriver webDriver) : base(webDriver)
        {
         
        }
        public string strPreftoAdd = "Test Preference Hill View";

        [FindsBy(How = How.Id, Using = "AddPreferenceLink")]
        public IWebElement lnkAddPreference { get; set; }

        [FindsBy(How = How.Id, Using = "AddInterestLink")]
        public IWebElement lnkAddInterest{ get; set; }

        //By txtInput = By.XPath("//div[@class='SingleField']//input[contains(@title,'This field is required')]");
        //By btnSave = By.XPath("//div[@class='SingleFieldButtonsContainer']//a[@title='Save' and not (@style)]");
        By txtInput = By.CssSelector("div#PreferencesContainer div:first-child div:last-child div.SingleField input");
        By btnSave = By.CssSelector("div#PreferencesContainer div:first-child div:last-child div.SingleFieldButtonsContainer a[title='Save']");
        By pageVerifyElement = By.PartialLinkText("Preferences");
        By prefContainer = By.CssSelector("div#PreferencesContainer div:first-child");
        By divContainer = By.CssSelector("div#PreferencesContainer div:first-child div:last-child label");
        By imgDeletePref = By.CssSelector("div#PreferencesContainer div:first-child div:last-child div.SingleFieldButtonsContainer a:last-child");
        By btnConfirmDelete = By.Id("ConfirmDeletePreferenceButton");

        public void AddPreference()
        {
            WaitForElementVisible(pageVerifyElement);

            lnkAddPreference.Click();

            IWebElement txtPrefInput = base.webDriver.FindElement(txtInput);
            txtPrefInput.SendKeys(strPreftoAdd);

            IWebElement btnSavePref = base.webDriver.FindElement(btnSave);
            btnSavePref.Click();

            WaitForElementVisible(divContainer);
        }
        public void AddInterest()
        {
            WaitForElementVisible(pageVerifyElement);

            lnkAddInterest.Click();
           
            IWebElement txtIntInput = base.webDriver.FindElement(txtInput);
            txtIntInput.SendKeys("Test Interest Reading");

            IWebElement btnSaveInt = base.webDriver.FindElement(btnSave);
            btnSaveInt.Click();
        }

        public void DeletePreference()
        {
            WaitForElementVisible(divContainer);
                       
            IWebElement btnDeletePref = base.webDriver.FindElement(imgDeletePref);
            ((IJavaScriptExecutor)base.webDriver).ExecuteScript("arguments[0].click();", btnDeletePref);

            IWebElement btnDelete = WaitForElementVisible(btnConfirmDelete);
            btnDelete.Click();
                       
            Thread.Sleep(5000); // Using this to forcefully wait for 5 sec in order to wait for ajax call to complete         
        }
        public string getAllPreferenceDetail()
        {
            IWebElement divPref = WaitForElementVisible(prefContainer);
            return divPref.Text;
        }
        public string getAddedPreferenceName()
        {
            return strPreftoAdd;
        }
        public void GotoHome()
        {
            base.SwithToDefault();
        }       
    }
}

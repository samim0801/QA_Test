using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
namespace Homeaway_QA_Test
{
    public class PageBase
    {
        public IWebDriver webDriver;
        double waitTime = Convert.ToDouble(ConfigurationManager.AppSettings["waitTime"]);
        public PageBase(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void SwitchToFrame(IWebElement frameElement)
        {
            webDriver.SwitchTo().Frame(frameElement);
        }

        public void SwithToDefault()
        {
            webDriver.SwitchTo().DefaultContent();
        }
        public IWebElement WaitForElementVisible(By bySelector)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(waitTime));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(bySelector));
            return element;
       }         
    }
}

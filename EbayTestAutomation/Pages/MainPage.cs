using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using EbayTestAutomation.Extensions;
using OpenQA.Selenium.Support.PageObjects;

namespace EbayTestAutomation.Pages
{
    class MainPage : PageBase
    {
        private const string BASE_URL = "https://ebay.com";
        private const string LOGOUT_LINK_XPATH = ".//*[@id='gh-uo']/a";

        [FindsBy(How = How.Id, Using = "gh-eb-u")]
        private IWebElement userMenu;

        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public void LoadPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void OpenUserMenu()
        {
            userMenu.Click();
        }

        public bool IsSignedIn()
        {
            IWebElement exitLink = driver.FindElementSafe(By.XPath(LOGOUT_LINK_XPATH));
            return exitLink.Exists();
        }

        public bool TryLogOut()
        {
            IWebElement exitLink = driver.FindElementSafe(By.XPath(LOGOUT_LINK_XPATH));
            if (exitLink.Exists())
            {
                exitLink.Click();
                return true;
            }
            else return false;
        }
    }
}

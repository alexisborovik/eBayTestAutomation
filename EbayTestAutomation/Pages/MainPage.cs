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
        private const string LOGOUT_LINK_XPATH = "//li[@id='gh-uo']/a";
        private const string CURRENT_LANG_XPATH = "//a[@id='gh-eb-Geo-a-default']/span[@class='gh-eb-Geo-txt']";
        private const string AVAILABLE_LANG_XPATH = "//a[@id='gh-eb-Geo-a-en']/span[@class='gh-eb-Geo-txt']";

        [FindsBy(How = How.Id, Using = "gh-eb-u")]
        private IWebElement userMenu;
        [FindsBy(How = How.Id, Using = "gh-eb-Geo")]
        private IWebElement geoMenu;
        [FindsBy(How = How.Id, Using = "gh-ac")]
        private IWebElement searchInput;
        [FindsBy(How = How.Id, Using = "gh-btn")]
        private IWebElement searchButt;

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

        public void LogOut()
        {
            IWebElement exitLink = driver.FindElementSafe(By.XPath(LOGOUT_LINK_XPATH));
            if (exitLink.Exists()) exitLink.Click(); ;
        }

        public void OpenGeoMenu()
        {
            geoMenu.Click();
        }

        public string GetCurrentLang()
        {
            IWebElement langMenuCurL = driver.FindElement(By.XPath(CURRENT_LANG_XPATH));
            return langMenuCurL.Text;
        }

        public string GetAvailableLang()
        {
            IWebElement langMenuAvL = driver.FindElement(By.XPath(AVAILABLE_LANG_XPATH));
            return langMenuAvL.Text;
        }

        public void ClickOnAvailableLang()
        {
            IWebElement langMenuAvL = driver.FindElement(By.XPath(AVAILABLE_LANG_XPATH));
            langMenuAvL.Click();
        }

        public void FillSearchInput(string request)
        {
            searchInput.SendKeys(request);
        }

        public void ClickSearchButt()
        {
            searchButt.Click();
        }
    }
}

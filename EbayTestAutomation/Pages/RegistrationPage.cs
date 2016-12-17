using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace EbayTestAutomation.Pages
{
    class RegistrationPage : PageBase
    {
        private const string BASE_URL = "https://reg.ebay.com/reg/PartialReg";
        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement emailInput;
        [FindsBy(How = How.Id, Using = "remail")]
        private IWebElement remailInput;
        [FindsBy(How = How.Id, Using = "PASSWORD")]
        private IWebElement passwordInput;
        [FindsBy(How = How.Id, Using = "firstname")]
        private IWebElement firstnameInput;
        [FindsBy(How = How.Id, Using = "lastname")]
        private IWebElement lastnameInput;
        [FindsBy(How = How.Id, Using = "phoneFlagComp1")]
        private IWebElement phoneInput;
        [FindsBy(How = How.Id, Using = "sbtBtn")]
        private IWebElement registerButton;
        [FindsBy(How = How.Id, Using = "ertx")]
        private IWebElement errorParagraph;
        [FindsBy(How = How.Id, Using = "email_w")]
        private IWebElement emailWarning;
        [FindsBy(How = How.Id, Using = "remail_w")]
        private IWebElement remailWarning;
        [FindsBy(How = How.Id, Using = "PASSWORD_w")]
        private IWebElement passwordWarning;

        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        public void LoadPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }
        public void Register()
        {
            registerButton.Click();
        }
    }
}

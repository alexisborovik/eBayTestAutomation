using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using EbayTestAutomation.Extensions;

namespace EbayTestAutomation.Pages
{
    class RegistrationPage : PageBase
    {
        private const string BASE_URL = "https://reg.ebay.com/reg/PartialReg";
        private const string SHOPPING_LINK = "LetsGoShoppingLink]";
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
        [FindsBy(How = How.ClassName, Using = "flag-dropdown")]
        private IWebElement flagDropdown;
        [FindsBy(How = How.Id, Using = "statErr")]
        private IWebElement errorStat;
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
        public void ClickRegister()
        {
            registerButton.Click();
        }

        public void ChooseCountry(string country)
        {
            if (!country.Equals(""))
            {
                flagDropdown.Click();
                IWebElement countryListElement = driver.FindElement(By.XPath("//span[text()='" + country + "']"));
                countryListElement.Click();
            }
        }

        public void FillEmail(string email)
        {
            emailInput.SendKeys(email);
        }

        public void FillReenterEmail(string reenterEmail)
        {
            remailInput.SendKeys(reenterEmail);
        }

        public void FillPass(string password)
        {
            passwordInput.SendKeys(password);
        }

        public void FillFirstName(string firstName)
        {
            firstnameInput.SendKeys(firstName);
        }

        public void FillLastName(string lastName)
        {
            lastnameInput.SendKeys(lastName);
        }

        public void FillPhoneNumber(string phone)
        {
            phoneInput.SendKeys(phone);
        }

        public bool IsErrorsExist()
        {
            return !(errorStat.GetCssValue("display").Equals("none"));
        }

        public bool IsSecondEmailWrong()
        {
            return remailWarning.Displayed;
        }

        public bool IsEmailWrong()
        {
            return emailWarning.Displayed;
        }

        public string GetPassErrorMessage()
        {
            string wText = passwordWarning.Text;
            return wText;
        }

        public bool GoShopping()
        {
            IWebElement shoppingLink = driver.FindElementSafe(By.Id(SHOPPING_LINK));
            if (shoppingLink.Exists())
            {
                shoppingLink.Click();
                return true;
            }
            return false;
        }
    }
}

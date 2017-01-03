using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace EbayTestAutomation.Pages
{
    class SignInPage : PageBase
    {
        private const string BASE_URL = "https://signin.ebay.com/ws/eBayISAPI.dll?SellItem";
        [FindsBy(How = How.XPath, Using = "//div[@id='pri_signin']/div[4]/span[2]/input[1]")]
        private IWebElement emailInput;
        [FindsBy(How = How.XPath, Using = "//div[@id='pri_signin']/div[5]/span[2]/input[1]")]
        private IWebElement passwordInput;
        [FindsBy(How = How.Id, Using = "csi")]
        private IWebElement stayignedCheckbox;
        [FindsBy(How = How.Id, Using = "sgnBt")]
        private IWebElement signButton;
        [FindsBy(How = How.Id, Using = "errf")]
        private IWebElement errorSpan;
        public SignInPage(IWebDriver driver) : base(driver)
        {
        }

        public void LoadPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void FillEmail(string email)
        {
            emailInput.SendKeys(email);
        }

        public void FillPass(string pass)
        {
            passwordInput.SendKeys(pass);
        }

        public void SignInClick()
        {
            signButton.Click();
        }

        public void StaySignedCheckboxClick()
        {
            stayignedCheckbox.Click();
        }

        public bool IsStaySignedChecked()
        {
            return stayignedCheckbox.GetAttribute("aria-checked").Equals("true");
        }

    }
}

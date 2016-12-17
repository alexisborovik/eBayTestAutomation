using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EbayTestAutomation.WebDriver;
using EbayTestAutomation.Pages;

namespace EbayTestAutomation.Steps
{
    class TestSteps
    {
        IWebDriver driver;
        public void StartBrowser()
        {
            driver = BrowserDriver.Chrome;
        }

        public void CloseBrowser()
        {
            BrowserDriver.closeChrome();
        }

        public void Register(string email, string firstName, string lastName, string pass, string phone, string country)
        {
            RegistrationPage rp = new RegistrationPage(driver);
            rp.LoadPage();
            rp.FillEmail(email);
            rp.FillReenterEmail(email);
            rp.FillPass(pass);
            rp.FillFirstName(firstName);
            rp.FillLastName(lastName);
            rp.ChooseCountry(country);
            rp.FillPhoneNumber(phone);
            rp.ClickRegister();
        }

        public bool IsRegisterErrorsExist()
        {
            RegistrationPage rp = new RegistrationPage(driver);
            return rp.IsErrorsExist();
        }
    }
}

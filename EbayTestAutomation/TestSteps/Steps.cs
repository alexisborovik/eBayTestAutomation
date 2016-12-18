using OpenQA.Selenium;
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

        public void RestartBrowser()
        {
            driver.Close();
            StartBrowser();
        }

        public void Register(string email, string secondEmail, string firstName, string lastName, string pass, string phone, string country)
        {
            RegistrationPage rp = new RegistrationPage(driver);
            rp.LoadPage();
            rp.FillEmail(email);
            rp.FillReenterEmail(secondEmail);
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

        public bool IsRegisterEmailsDontMatch()
        {
            RegistrationPage rp = new RegistrationPage(driver);
            return rp.IsSecondEmailWrong();
        }

        public bool IsRegisterEmailIncorrect()
        {
            RegistrationPage rp = new RegistrationPage(driver);
            return rp.IsEmailWrong();
        }

        public string GetRegisterPassErrMessage()
        {
            RegistrationPage rp = new RegistrationPage(driver);
            return rp.GetPassErrorMessage();
        }


        public bool GoToShopping()
        {
            RegistrationPage rp = new RegistrationPage(driver);
            return rp.TryGoShopping();
        }

        public void SignIn(string login, string pass, bool staySigned)
        {
            SignInPage sp = new SignInPage(driver);
            sp.LoadPage();
            sp.FillEmail(login);
            sp.FillPass(pass);
            if ((staySigned && !sp.IsStaySignedChecked()) ||
                (!staySigned && sp.IsStaySignedChecked()))
                sp.StaySignedCheckboxClick();
            sp.SignInClick();
        }

        public bool IsSignedIn()
        {
            MainPage mp = new MainPage(driver);
            mp.LoadPage();
            mp.OpenUserMenu();
            return mp.IsSignedIn();
        }

        public bool TryLogout()
        {
            MainPage mp = new MainPage(driver);
            mp.LoadPage();
            mp.OpenUserMenu();
            return mp.TryLogOut();
        }

        public string GetCurrentLang()
        {
            MainPage mp = new MainPage(driver);
            mp.LoadPage();
            mp.OpenGeoMenu();
            return mp.GetCurrentLang();
        }

        public string GetAvailableLang()
        {
            MainPage mp = new MainPage(driver);
            mp.LoadPage();
            mp.OpenGeoMenu();
            return mp.GetAvailableLang();
        }

        public void ChangeLang()
        {
            MainPage mp = new MainPage(driver);
            mp.LoadPage();
            mp.OpenGeoMenu();
            mp.ClickOnAvailableLang();
        }
    }
}

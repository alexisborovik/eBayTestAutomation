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
            return rp.GoShopping();
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

        public void Logout()
        {
            MainPage mp = new MainPage(driver);
            mp.LoadPage();
            mp.OpenUserMenu();
            mp.LogOut();
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

        public void Search(string request)
        {
            MainPage mp = new MainPage(driver);
            mp.LoadPage();
            mp.FillSearchInput(request);
            mp.ClickSearchButt();
        }

        public string GoToSearchResult(int index)
        {
            SearchResultsPage sr = new SearchResultsPage(driver);
            return sr.GoToResult();
        }

        public string AddToCart()
        {
            ProductDescritionPage pd = new ProductDescritionPage(driver);
            return pd.AddToCart();
        }

        public bool IsItemInCart(string title)
        {
            ShoppingCart sc = new ShoppingCart(driver);
            sc.LoadPage();
            return sc.isItemExistsInCart(title);
        }

        public void RemoveFromCart(string title)
        {
            ShoppingCart sc = new ShoppingCart(driver);
            sc.LoadPage();
            sc.RemoveItemFromCart(title);
        }

        public void SaveForLater(string title)
        {
            ShoppingCart sc = new ShoppingCart(driver);
            sc.LoadPage();
            sc.AddToSaveForLaterList(title);
        }

        public bool IsItemExsistInLaterList(string title)
        {
            ShoppingCart sc = new ShoppingCart(driver);
            sc.LoadPage();
            return sc.IsItemExsistInLaterList(title);
        }

        public void BackFromLaterToCart(string title)
        {
            ShoppingCart sc = new ShoppingCart(driver);
            sc.LoadPage();
            sc.BackFromSaveForLaterList(title);
        }

        public void RemoveFromLaterList(string title)
        {
            ShoppingCart sc = new ShoppingCart(driver);
            sc.LoadPage();
            sc.RemoveFromLater(title);
        }
    }
}
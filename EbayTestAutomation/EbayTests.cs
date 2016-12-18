using System;
using NUnit.Framework;
using EbayTestAutomation.Steps;
using EbayTestAutomation.Tools;

namespace EbayTestAutomation
{
    class EbayTests
    {
        private TestSteps steps = new TestSteps();

        private string EMAIL = "firsttestemail@mail.ru";
        private string SECOND_EMAIL = "secondtestemail@mail.ru";
        private string INCORRECT_EMAIL = "INCORRECT@mailru";
        private string PHONE = "259258290";
        private string COUNTRY = "Belarus";
        private string PASS = "12345qazWSX";
        private string SHORT_PASS = "qA1!";
        private string PASS_CONTAINS_ONLY_DIGITS = "1029384756";
        private string FIRST_NAME = "Alexis";
        private string LAST_NAME = "Borovik";
        private string LOGIN = "AlexisBorovikTester";
        private string SEARCH_REQUEST = "INTEL CORE I7";


        private string ERR_PASS_MATCH_TO_NAME = "Ваш пароль не должен совпадать с вашим именем или адресом электронной почты.";
        private string ERR_PASS_TOO_SHORT = "Введите как минимум 6 символов.";
        private string ERR_PASS_REQUREMENTS = "Придумайте пароль, состоящий как минимум из 6 символов и представляющий комбинацию букв, цифр и специальных символов.";

        [SetUp]
        public void Init()
        {
            steps.StartBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void RegisterWithEmptyFields()
        {
            steps.Register("", "", "", "", "", "","");
            Assert.True(steps.IsRegisterErrorsExist());
        }

        [Test]
        public void Register()
        {
            steps.Register(EMAIL, EMAIL, FIRST_NAME, LAST_NAME, PASS, PHONE, COUNTRY);
            Assert.True(steps.GoToShopping());
        }

        [Test]
        public void RegisterWithDifferentEmails()
        {
            steps.Register(EMAIL, SECOND_EMAIL, FIRST_NAME, LAST_NAME, PASS, PHONE, COUNTRY);
            Assert.True(steps.IsRegisterEmailsDontMatch());
        }

        [Test]
        public void RegisterWithIncorrectEmail()
        {
            steps.Register(EMAIL, INCORRECT_EMAIL, FIRST_NAME, LAST_NAME, PASS, PHONE, COUNTRY);
            Assert.True(steps.IsRegisterEmailIncorrect());
        }

        [Test]
        public void RegisterWithPassEqualsToEmail()
        {
            steps.Register(EMAIL, EMAIL, FIRST_NAME, LAST_NAME, EMAIL, PHONE, COUNTRY);
            Assert.True(steps.GetRegisterPassErrMessage().Contains(ERR_PASS_MATCH_TO_NAME));
        }

        [Test]
        public void RegisterWithPassContainsOnlyDigits()
        {
            steps.Register(EMAIL, EMAIL, FIRST_NAME, LAST_NAME, PASS_CONTAINS_ONLY_DIGITS, PHONE, COUNTRY);
            Assert.True(steps.GetRegisterPassErrMessage().Contains(ERR_PASS_REQUREMENTS));
        }

        [Test]
        public void RegisterWithShortPass()
        {
            steps.Register(EMAIL, EMAIL, FIRST_NAME, LAST_NAME, SHORT_PASS, PHONE, COUNTRY);
            Assert.True(steps.GetRegisterPassErrMessage().Contains(ERR_PASS_TOO_SHORT));
        }

        [Test]
        public void SignInViaEmail()
        {
            steps.SignIn(EMAIL, PASS, false);
            Assert.True(steps.IsSignedIn());
        }

        [Test]
        public void SignInViaLogin()
        {
            steps.SignIn(LOGIN, PASS, false);
            Assert.True(steps.IsSignedIn());
        }

        [Test]
        public void CheckLogout()
        {
            steps.SignIn(EMAIL, PASS, true);
            steps.TryLogout();
            Assert.False(steps.IsSignedIn());
        }

        [Test]
        public void SwitchLanguage()
        {
            string availableLang = steps.GetAvailableLang();
            steps.ChangeLang();
            string currLang = steps.GetCurrentLang();
            Assert.True(currLang.Equals(availableLang));
        }
        [Test]
        public void AddToCart()
        {
            steps.SignIn(EMAIL, PASS, false);
            steps.Search(SEARCH_REQUEST);
            string itemTitle = steps.GoToSearchResult(1);
            steps.AddToCart();
            Assert.True(steps.IsItemWithTitleExsist(itemTitle));
        }
    }
}

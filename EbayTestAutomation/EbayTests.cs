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
        private string INCORRECT_EMAIL = "INCORRECT@mail@ru";
        private string PHONE = "259258290";
        private string COUNTRY = "Belarus";
        private string PASS = "12345qazWSX";
        private string SHORT_PASS = "qA1!";
        private string FIRST_NAME = "Alexis";
        private string LAST_NAME = "Borovik";
        private string LOGIN = "AlexisBorovikTester";

        private string ERR_PASS_MATCH_TO_NAME = "Ваш пароль не должен совпадать с вашим именем или адресом электронной почты.";
        private string ERR_PASS_TOO_SHORT = "Введите как минимум 6 символов.";

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
        public void RegisterWithPassMatchToEmail()
        {
            steps.Register(EMAIL, EMAIL, FIRST_NAME, LAST_NAME, EMAIL, PHONE, COUNTRY);
            Assert.True(steps.GetRegisterPassErrMessage().Equals(ERR_PASS_MATCH_TO_NAME));
        }

        [Test]
        public void RegisterWithShortPass()
        {
            steps.Register(EMAIL, EMAIL, FIRST_NAME, LAST_NAME, SHORT_PASS, PHONE, COUNTRY);
            Assert.True(steps.GetRegisterPassErrMessage().Equals(ERR_PASS_TOO_SHORT));
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
        public void CheckForStayingSignedIn()
        {
            steps.TryLogout();
            steps.SignIn(EMAIL, PASS, true);
            steps.CloseBrowser();
            System.Threading.Thread.Sleep(5000);
            steps.StartBrowser();
            Assert.True(steps.IsSignedIn());
        }
    }
}

using System.Collections.Generic;
using NUnit.Framework;
using EbayTestAutomation.Steps;
using EbayTestAutomation.Tools;

namespace EbayTestAutomation
{
    class EbayTests
    {
        private TestSteps steps = new TestSteps();
        private Dictionary<string, string> settings = Tool.LoadSettings();

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
            steps.Register("", "", "", "", "", "", "");
            Assert.True(steps.IsRegisterErrorsExist());
        }

        [Test]
        public void Register()
        {
            steps.Register(
                settings["EMAIL"],
                settings["EMAIL"],
                settings["FIRSTNAME"],
                settings["LASTNAME"],
                settings["PASS"],
                settings["PHONE"],
                settings["COUNTRY"]);
            Assert.True(steps.GoToShopping());
        }

        [Test]
        public void RegisterWithDifferentEmails()
        {
            steps.Register(
                settings["EMAIL"],
                settings["SECOND_EMAIL"],
                settings["FIRSTNAME"],
                settings["LASTNAME"],
                settings["PASS"],
                settings["PHONE"],
                settings["COUNTRY"]);
            Assert.True(steps.IsRegisterEmailsDontMatch());
        }

        [Test]
        public void RegisterWithIncorrectEmail()
        {
            steps.Register(
                settings["INCORRECT_EMAIL"],
                settings["INCORRECT_EMAIL"],
                settings["FIRSTNAME"], 
                settings["LASTNAME"],
                settings["PASS"], 
                settings["PHONE"],
                settings["COUNTRY"]);
            Assert.True(steps.IsRegisterEmailIncorrect());
        }

        [Test]
        public void RegisterWithPassEqualsToEmail()
        {
            steps.Register(
                settings["EMAIL"],
                settings["EMAIL"], 
                settings["FIRSTNAME"],
                settings["LASTNAME"],
                settings["EMAIL"], 
                settings["PHONE"],
                settings["COUNTRY"]);
            Assert.True(settings["ERR_PASS_MATCH_TO_NAME"].Contains(steps.GetRegisterPassErrMessage()));
        }

        [Test]
        public void RegisterWithPassContainsOnlyDigits()
        {
            steps.Register(
                settings["EMAIL"], 
                settings["EMAIL"], 
                settings["FIRSTNAME"],
                settings["LASTNAME"], 
                settings["PASS_CONTAINS_ONLY_DIGITS"],
                settings["PHONE"], 
                settings["COUNTRY"]);
            Assert.True(settings["ERR_PASS_REQUIREMENTS"].Contains(steps.GetRegisterPassErrMessage()));
        }

        [Test]
        public void RegisterWithShortPass()
        {
            steps.Register(
                settings["EMAIL"],
                settings["EMAIL"],
                settings["FIRSTNAME"],
                settings["LASTNAME"],
                settings["SHORT_PASS"],
                settings["PHONE"],
                settings["COUNTRY"]);
            Assert.True(settings["ERR_PASS_TOO_SHORT"].Contains(steps.GetRegisterPassErrMessage()));
        }

        [Test]
        public void SignInViaEmail()
        {
            steps.SignIn(settings["EMAIL"], settings["PASS"], false);
            Assert.True(steps.IsSignedIn());
        }

        [Test]
        public void SignInViaLogin()
        {
            steps.SignIn(settings["LOGIN"], settings["PASS"], false);
            Assert.True(steps.IsSignedIn());
        }

        [Test]
        public void CheckLogout()
        {
            steps.SignIn(settings["EMAIL"], settings["PASS"], true);
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
            steps.SignIn(settings["EMAIL"], settings["PASS"], false);
            steps.Search(settings["SEARCH_REQUEST"]);
            string itemTitle = steps.GoToSearchResult(1);
            steps.AddToCart();
            Assert.True(steps.IsItemInCart(itemTitle));
            steps.RemoveFromCart(itemTitle);
        }

        [Test]
        public void RemoveFromCart()
        {
            steps.SignIn(settings["EMAIL"], settings["PASS"], false);
            steps.Search(settings["SEARCH_REQUEST_FOR_REMOVE"]);
            string itemTitle = steps.GoToSearchResult(1);
            steps.AddToCart();
            steps.RemoveFromCart(itemTitle);
            Assert.False(steps.IsItemInCart(itemTitle));
        }

        [Test]
        public void SaveForLater()
        {
            steps.SignIn(settings["EMAIL"], settings["PASS"], false);
            steps.Search(settings["SEARCH_REQUEST"]);
            string itemTitle = steps.GoToSearchResult(1);
            steps.AddToCart();
            steps.SaveForLater(itemTitle);
            Assert.True(steps.IsItemExsistInLaterList(itemTitle));
            steps.RemoveFromLaterList(itemTitle);
        }

        [Test]
        public void BackFromLaterToCart()
        {
            steps.SignIn(settings["EMAIL"], settings["PASS"], false);
            steps.Search(settings["SEARCH_REQUEST"]);
            string itemTitle = steps.GoToSearchResult(1);
            steps.AddToCart();
            steps.SaveForLater(itemTitle);
            steps.BackFromLaterToCart(itemTitle);
            Assert.False(steps.IsItemExsistInLaterList(itemTitle));
            steps.RemoveFromCart(itemTitle);
        }
        [Test]
        public void RemoveFromLater()
        {
            steps.SignIn(settings["EMAIL"], settings["PASS"], false);
            steps.Search(settings["SEARCH_REQUEST"]);
            string itemTitle = steps.GoToSearchResult(1);
            steps.AddToCart();
            steps.SaveForLater(itemTitle);
            steps.RemoveFromLaterList(itemTitle);
            Assert.False(steps.IsItemInCart(itemTitle));
        }
    }
}

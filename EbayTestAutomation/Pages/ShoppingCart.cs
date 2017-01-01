using OpenQA.Selenium;
using EbayTestAutomation.Extensions;
using System;

namespace EbayTestAutomation.Pages
{
    class ShoppingCart : PageBase
    {
        private const string BASE_URL = "http://cart.payments.ebay.com/sc/view";
        private const string REMOVE_FROM_CART = "http://cart.payments.ebay.com/sc/rfc";
        private const string SAVE_FOR_LATER = "http://cart.payments.ebay.com/sc/sfl";
        private const string REMOVE_FROM_LATER = "http://cart.payments.ebay.com/sc/rfsfl";
        private const string FROM_LATER_TO_CART = "http://cart.payments.ebay.com/sc/sflatc";
        public ShoppingCart(IWebDriver driver) : base(driver)
        {
        }

        private string ConfigXPath(string textToFind, string linkTo)
        {
            return String.Format(".//div[.//a[contains(text(),'{0}')] and contains(@class,'fl col_100p talign balign clearfix')]//a[starts-with(@href,'{1}')]", textToFind, linkTo);
        }

        public void LoadPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public bool isItemExistsInCart(string title)
        {
            IWebElement itemLink = driver.FindElementSafe(By.XPath(".//div[@id='CARTSection']//a[contains(text(),'" + title + "')]"));
            return itemLink.Exists();
        }

        public void RemoveItemFromCart(string title)
        {
            IWebElement removeLink = driver.FindElementSafe(By.XPath(ConfigXPath(title,REMOVE_FROM_CART)));
            if (removeLink.Exists()) removeLink.Click();
        }

        public void AddToSaveForLaterList(string title)
        {
            IWebElement addToLaterLink = driver.FindElementSafe(By.XPath(ConfigXPath(title,SAVE_FOR_LATER)));
            if (addToLaterLink.Exists())addToLaterLink.Click();
        }

        public void BackFromSaveForLaterList(string title)
        {
            IWebElement backToCartLink = driver.FindElementSafe(By.XPath(ConfigXPath(title,FROM_LATER_TO_CART)));
            if (backToCartLink.Exists()) backToCartLink.Click();
        }

        public bool IsItemExsistInLaterList(string title)
        {
            IWebElement itemLink = driver.FindElementSafe(By.XPath(".//*[@id='SFLSection']//a[contains(text(),'" + title + "')]"));
            return itemLink.Exists();
        }

        public void RemoveFromLater(string title)
        {
            IWebElement removeLink = driver.FindElementSafe(By.XPath(ConfigXPath(title,REMOVE_FROM_LATER)));
            if (removeLink.Exists()) removeLink.Click();
        }

    }
}

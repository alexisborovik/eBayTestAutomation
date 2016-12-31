using OpenQA.Selenium;
using EbayTestAutomation.Extensions;

namespace EbayTestAutomation.Pages
{
    class ShoppingCart : PageBase
    {
        private const string BASE_URL = "http://cart.payments.ebay.com/sc/view";
        public ShoppingCart(IWebDriver driver) : base(driver)
        {
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
            string xpath = ".//div[.//a[contains(text(),'" + title + "')] and contains(@class,'fl col_100p talign balign clearfix')]//a[starts-with(@href,'http://cart.payments.ebay.com/sc/rfc')]";
            IWebElement removeLink = driver.FindElementSafe(By.XPath(xpath));
            if (removeLink.Exists()) removeLink.Click();
        }

        public void AddToSaveForLaterList(string title)
        {
            string xpath = ".//div[.//a[contains(text(),'" + title + "')] and contains(@class,'fl col_100p talign balign clearfix')]//a[starts-with(@href,'http://cart.payments.ebay.com/sc/sfl')]";
            IWebElement addToLaterLink = driver.FindElementSafe(By.XPath(xpath));
            if (addToLaterLink.Exists())
            {
                addToLaterLink.Click();
            }
        }

        public void BackFromSaveForLaterList(string title)
        {
            string xpath = ".//div[.//a[contains(text(),'" + title + "')] and contains(@class,'fl col_100p talign balign clearfix')]//a[starts-with(@href,'http://cart.payments.ebay.com/sc/sflatc')]";
            IWebElement backToCartLink = driver.FindElementSafe(By.XPath(xpath));
            if (backToCartLink.Exists()) backToCartLink.Click();
        }

        public bool IsItemExsistInLaterList(string title)
        {
            IWebElement itemLink = driver.FindElementSafe(By.XPath(".//*[@id='SFLSection']//a[contains(text(),'" + title + "')]"));
            return itemLink.Exists();
        }

        public void RemoveFromLater(string title)
        {
            string xpath = ".//div[.//a[contains(text(),'" + title + "')] and contains(@class,'fl col_100p talign balign clearfix')]//a[starts-with(@href,'http://cart.payments.ebay.com/sc/rfsfl')]";
            IWebElement removeLink = driver.FindElementSafe(By.XPath(xpath));
            if (removeLink.Exists()) removeLink.Click();
        }

    }
}

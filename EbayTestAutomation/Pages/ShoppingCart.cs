using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool isExistItemWithTitle(string title)
        {
            IWebElement itemLink = driver.FindElementSafe(By.XPath(".//a[text() = '"+title+"']"));
            return itemLink.Exists();
        }

        public void TryRemoveItemWithTitle(string title)
        {
            IWebElement removeLink = driver.FindElementSafe(By.XPath(".//a[text() = '" + title + "']/../../../../../../../../div[2]/div/div/a[1]"));
            if (removeLink.Exists()) removeLink.Click();
        }

        public void TryAddToSaveForLaterList(string title)
        {
            IWebElement addToLaterLink = driver.FindElementSafe(By.XPath(".//a[text() = '" + title + "']/../../../../../../../../div[2]/div/div/a[2]"));
            if (addToLaterLink.Exists()) addToLaterLink.Click();
        }

        public void TryBackFromSaveForLaterList(string title)
        {
            IWebElement backToCartLink = driver.FindElementSafe(By.XPath(".//*[@id='SFLSection']/div[3]/div/div//a[text()='"
                + title + "']/../../../../../../../../div[2]/div/div/a[2]"));
            if (backToCartLink.Exists()) backToCartLink.Click();
        }

        public bool IsItemExsistInLaterList(string title)
        {
            IWebElement itemLink = driver.FindElementSafe(By.XPath(".//*[@id='SFLSection']/div[3]/div/div//a[text()='"
                +title + "']"));
            return itemLink.Exists();
        }

        public void TryRemoveFromLater(string title)
        {
            IWebElement removeLink = driver.FindElementSafe(By.XPath(".//*[@id='SFLSection']/div[3]/div/div//a[text()='"
                + title + "']/../../../../../../../../div[2]/div/div/a[1]"));
            if (removeLink.Exists()) removeLink.Click();
        }

    }
}

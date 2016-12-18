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
    }
}

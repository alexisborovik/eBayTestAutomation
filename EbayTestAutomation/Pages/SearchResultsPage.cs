using OpenQA.Selenium;
using EbayTestAutomation.Extensions;
using OpenQA.Selenium.Support.PageObjects;

namespace EbayTestAutomation.Pages
{
    class SearchResultsPage : PageBase
    {
        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
        }

        public string GoToResult(int index=1)
        {
            IWebElement itemLink = driver.FindElement(By.XPath("//ul[@id='ListViewInner']/li["+index+"]/h3/a"));
            string itemd = itemLink.Text.Replace("...", "");
            itemLink.Click();
            return itemd;
        }
    }
}

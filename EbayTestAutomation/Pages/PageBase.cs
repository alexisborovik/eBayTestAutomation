using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace EbayTestAutomation.Pages
{
    class PageBase
    {
        protected IWebDriver driver;

        public PageBase(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void ScrollToBottom()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0,document.body.scrollHeight);");
        }
    }
}

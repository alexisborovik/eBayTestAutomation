using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace EbayTestAutomation.Pages
{
    class ProductDescritionPage : PageBase
    {
        [FindsBy(How = How.Id, Using = "itemTitle")]
        private IWebElement title;
        [FindsBy(How = How.Id, Using = "isCartBtn_btn")]
        private IWebElement addToCart;

        public ProductDescritionPage(IWebDriver driver) : base(driver)
        {
        }

        public string AddToCart()
        {
            string ttt = title.Text;
            addToCart.Click();
            return ttt;
        }

    }
}

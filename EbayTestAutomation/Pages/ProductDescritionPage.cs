using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace EbayTestAutomation.Pages
{
    class ProductDescritionPage : PageBase
    {
        [FindsBy(How = How.Id, Using = "isCartBtn_btn")]
        private IWebElement addToCart;

        public ProductDescritionPage(IWebDriver driver) : base(driver)
        {
        }

        public void AddToCart()
        {
            addToCart.Click();
        }

    }
}

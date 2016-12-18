using NUnit.Framework;
using EbayTestAutomation.WebDriver;

namespace EbayTestAutomation
{
    public class Class1
    {
        [Test]
        public void TestConstructorClassic()
        {
            
            Pages.RegistrationPage pp = new Pages.RegistrationPage(BrowserDriver.Chrome);
            pp.LoadPage();
            pp.ChooseCountry("Belarus");
            bool b = pp.TryGoShopping();
            int a = 0;
           // pp.Register();
            
           // BrowserDriver.Chrome.Navigate().GoToUrl("https://signin.ebay.com/ws/eBayISAPI.dll?SellItem");
           /* BrowserDriver.Firefox.Url = "http://www.google.com";
            BrowserDriver.Firefox.Navigate().GoToUrl("http://tut.by");
            Assert.AreEqual(0, 0);
            System.Threading.Thread.Sleep(5000);
            BrowserDriver.closeFirefox();
            */
        }
    }
}

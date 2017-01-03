using OpenQA.Selenium;

namespace EbayTestAutomation.Extensions
{
    public static class ExtensionMethods
    {
        public static IWebElement FindElementSafe(this IWebDriver driver, By by)
        {
            try
            {
                return driver.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public static bool Exists(this IWebElement element)
        {
            return (element == null) ? false : true;
        }

        public static bool IsElementExists(this IWebDriver driver, By findsBy)
        {
            return (driver.FindElements(findsBy).Count != 0) ? true : false;
        }
    }
}

using System;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.IO;

namespace EbayTestAutomation.WebDriver
{
    class BrowserDriver
    {
        private static IWebDriver firefox;
        private static IWebDriver chrome;

        private BrowserDriver()
        {

        }

        public static IWebDriver Firefox
        {
            get
            {
                if(firefox == null)
                {
                    firefox = new FirefoxDriver();
                    configureDriver(ref firefox);
                }
                return firefox;
            }
        }

        public static IWebDriver Chrome
        {
            get
            {
                if(chrome == null)
                {
                    chrome = new ChromeDriver();
                    configureDriver(ref chrome);
                }
                return chrome;
            }
        }

        public static void closeFirefox()
        {
            quitDriver(ref firefox);
        }

        public static void closeChrome()
        {
            quitDriver(ref chrome);
        }
        private static void configureDriver(ref IWebDriver instance)
        {
            instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
            instance.Manage().Window.Maximize();
        }

        private static void quitDriver(ref IWebDriver instance)
        {
            if (instance != null)
            {
                instance.Quit();
                instance = null;
            }
        }
    }
}

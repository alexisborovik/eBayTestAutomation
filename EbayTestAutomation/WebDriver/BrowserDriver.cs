using System;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace EbayTestAutomation.WebDriver
{
    class BrowserDriver
    {
        private static IWebDriver firefox;
        private static IWebDriver chrome;

        public static IWebDriver Firefox
        {
            get
            {
                if(firefox == null)
                {
                    firefox = new FirefoxDriver();
                    configureDriver(firefox);
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
                    configureDriver(chrome);
                }
                return chrome;
            }
        }

        public static void closeFirefox()
        {
            quitDriver(firefox);
        }

        public static void closeChrome()
        {
            quitDriver(chrome);
        }
        private static void configureDriver(IWebDriver instance)
        {
            instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            instance.Manage().Window.Maximize();
        }

        private static void quitDriver(IWebDriver instance)
        {
            if (instance != null)
            {
                instance.Quit();
                instance = null;
            }
        }

    }
}

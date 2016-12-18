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

        public static void CreateChromeProfile()
        {
            string cd = Directory.GetCurrentDirectory() + @"\ChromeProfile";
            Directory.CreateDirectory(cd);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments =
                "/C \"C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe\" --user-data-dir=\"" + cd + "\" -first-run";
            process.StartInfo = startInfo;
            process.Start();
            /*
                    string cd = Directory.GetCurrentDirectory() + @"\ChromeProfile";
                    ChromeOptions co = new ChromeOptions();
                    co.AddArgument("user-data-dir=" + cd);*/
        }

    }
}

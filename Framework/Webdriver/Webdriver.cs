using OpenQA.Selenium;
using Task3.Framework.Utils;

namespace Task3.Framework.Webdriver
{
    public class Webdriver
    {
        private Webdriver()
        {
        }

        private static IWebDriver? driver;

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                driver = BrowserFactory.GetDriver(Config.Settings["Driver"]);
            }

            return driver;
        }

        public static void DisposeDriver()
        {
            if (driver != null)
            {
                driver.Dispose();
                driver = null;
            }
        }
    }
}
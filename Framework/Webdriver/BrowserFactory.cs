using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Task3.Framework.Utils;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Task3.Framework.Webdriver
{
    public class BrowserFactory
    {
        public static IWebDriver GetDriver(string driverName)
        {
            IWebDriver driver = null;

            switch (driverName.Trim().ToLower())
            {
                case "chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

                    ChromeOptions cromeOptions = new ChromeOptions();

                    foreach (var opt in Config.BrowserOptions)
                    {
                        cromeOptions.AddArgument(opt.Value);
                    }

                    driver = new ChromeDriver(cromeOptions);

                    break;

                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());

                    FirefoxOptions firefoxOptions = new FirefoxOptions();

                    foreach (var opt in Config.BrowserOptions)
                    {
                        firefoxOptions.AddArgument(opt.Value);
                    }

                    driver = new FirefoxDriver(firefoxOptions);

                    break;

                default:

                    throw new System.Exception($"Create driver error: {driverName}");
            }

            return driver;
        }
    }
}
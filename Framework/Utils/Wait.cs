using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Task3.Framework.Utils
{
    internal class Wait
    {
        private WebDriverWait wait;
        private IWebDriver driver;
        private double timeout = double.Parse(Config.Settings["Timeout"]);

        public Wait()
        {
            this.driver = Webdriver.Webdriver.GetInstance();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));

            wait.IgnoreExceptionTypes
                (
                    typeof(ElementNotVisibleException),
                    typeof(NoSuchElementException),
                    typeof(StaleElementReferenceException)
                );
        }

        public void WaitUntilClickable(By locator)
        {
            Logger.Info($"Wait clickable element: {locator.ToString()}");
            try
            {
                _ = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (TimeoutException)
            {
                Logger.Error($"Timeout: wait clickable element: {locator.ToString()}");
                throw new TimeoutException($"Timeout: wait cllickabe element: {locator.ToString()}");
            }
        }

        public void WaitUntilVisible(By locator)
        {
            Logger.Info($"Wait visible element: {locator.ToString()}");
            try
            {
                _ = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (TimeoutException)
            {
                Logger.Error($"Timeout: wait visible element: {locator.ToString()}");
                throw new TimeoutException($"Timeout: wait visible element: {locator.ToString()}");
            }
        }

        public void WaitUntilClose(By locator)
        {
            Logger.Info($"Wait for closing element: {locator.ToString()}");
            try
            {
                _ = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
            }
            catch (TimeoutException)
            {
                Logger.Error($"Timeout: wait for closing element: {locator.ToString()}");
                throw new TimeoutException($"Timeout: wait for closing element: {locator.ToString()}");
            }
        }

        public void WaitUntilAlertIsPresent()
        {
            Logger.Info($"Wait until alert is present");
            try
            {
                _ = wait.Until(ExpectedConditions.AlertIsPresent());
            }
            catch (TimeoutException)
            {
                Logger.Error($"Timeout - wait for alert");
                throw new TimeoutException($"Timeout - wait for alert");
            }
        }
    }
}
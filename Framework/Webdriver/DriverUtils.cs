using SeleniumExtras.WaitHelpers;
using System;
using Task3.Framework.Utils;

namespace Task3.Framework.Webdriver
{
    internal class DriverUtils
    {
        public static void OpenUrl(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                Webdriver.GetInstance().Navigate().GoToUrl(url);
                Logger.Info($"Url opend ok: {url}");
            }
            else
            {
                Logger.Error("Empty Url");
            }
        }

        public static void AcceptAlert()
        {
            Logger.Info("Accept Alert");

            Webdriver.GetInstance().SwitchTo().Alert().Accept();
        }

        public static void DismissAlert()
        {
            Logger.Info("Dismiss Alert");

            Webdriver.GetInstance().SwitchTo().Alert().Dismiss();
        }

        public static string WaitAndGetAlertText()
        {
            var wait = new Wait();

            Logger.Info("Get Alert text");

            wait.WaitUntilAlertIsPresent();

            var text = Webdriver.GetInstance().SwitchTo().Alert().Text;

            if (String.IsNullOrEmpty(text))
            {
                Logger.Warning("Alert text is empty");
            }

            return text;
        }

        public static void SendKeysToAlert(string text)
        {
            Logger.Info($"Send keys to Alert: \"{text}\"");

            var alert = Webdriver.GetInstance().SwitchTo().Alert();

            alert.SendKeys(text);
        }

        public static bool IsAlertPresent()
        {
            var alert = ExpectedConditions.AlertIsPresent().Invoke(Webdriver.GetInstance());

            if (alert != null)
            {
                Logger.Info("Alert is present on page");
                return true;
            }
            else
            {
                Logger.Info("Alert is not present on page");
                return false;
            }
        }

        public static void SwitchToNewTab()
        {
            Logger.Info("Switch to new tab");

            if (Webdriver.GetInstance().WindowHandles.Count > 1)
            {
                Webdriver.GetInstance().SwitchTo().Window(Webdriver.GetInstance().WindowHandles[1]);
            }
        }

        public static void CloseCurrentTabAndReturn()
        {
            Logger.Info("Close current tab and return");

            var handles = Webdriver.GetInstance().WindowHandles;

            if (handles.Count > 1)
            {
                Webdriver.GetInstance().Close();
                Webdriver.GetInstance().SwitchTo().Window(handles[0]);
            }
        }

        public static void SwitchToPreviosTab()
        {
            Logger.Info("Switch to previous tab");

            var handles = Webdriver.GetInstance().WindowHandles;

            if (handles.Count > 1)
            {
                Webdriver.GetInstance().SwitchTo().Window(handles[0]);
            }
        }
    }
}
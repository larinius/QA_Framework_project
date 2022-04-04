using NUnit.Framework;
using System.Collections.Generic;
using Task3.Framework;
using Task3.Framework.Utils;
using Task3.Framework.Webdriver;
using Task3.Pages;

namespace Task3
{
    public class Tests : BaseTest
    {
        [Test]
        public void TestCaseAlerts()
        {
            string alertMessage = string.Empty;

            DriverUtils.OpenUrl(Config.TestPage["Url"]);

            var homePage = new HomePage();

            homePage.WaitUntilLoaded();

            Assert.IsTrue(homePage.IsDisplayed(), "Home page not opend");

            homePage.ClickAlertButton();

            var alertsFramesWindowsPage = new AlertsFramesWindowsPage();

            alertsFramesWindowsPage.WaitUntilLoaded();

            Assert.IsTrue(alertsFramesWindowsPage.IsDisplayed(), "Alerts, Frame & Windows page is not opend");

            alertsFramesWindowsPage.ClickMenuSubitem("Alerts");

            var alertsPage = new AlertsPage();

            alertsPage.WaitUntilLoaded();

            Assert.IsTrue(alertsPage.IsDisplayed(), "Alerts page is not opend");

            alertsPage.ClickAlertButton();

            alertMessage = DriverUtils.WaitAndGetAlertText();

            Assert.AreEqual(alertMessage, "You clicked a button", "Alert is not opend");

            DriverUtils.AcceptAlert();

            Assert.IsFalse(DriverUtils.IsAlertPresent(), "Allert is not closed");

            alertsPage.ClickConfirmAlertButton();

            alertMessage = DriverUtils.WaitAndGetAlertText();

            Assert.AreEqual(alertMessage, "Do you confirm action?", "Confirm Alert is not opend");

            DriverUtils.AcceptAlert();

            Assert.IsFalse(DriverUtils.IsAlertPresent(), "Confirm Allert is not closed");

            var confirmText = alertsPage.GetPromtComfirmText();

            Assert.AreEqual(confirmText, "You selected Ok", "Confirm Alert result text is not equal to expected");

            alertsPage.ClickPromtAlertButton();

            alertMessage = DriverUtils.WaitAndGetAlertText();

            Assert.AreEqual(alertMessage, "Please enter your name", "Promt Alert is not opend");

            var randomStr = Text.GetRandomString(12);

            DriverUtils.SendKeysToAlert(randomStr);

            DriverUtils.AcceptAlert();

            Assert.IsFalse(DriverUtils.IsAlertPresent(), "Promt Allert is not closed");

            var promtText = alertsPage.GetPromtResulltText();

            Assert.AreEqual(promtText, randomStr, "Text on page is not equal to input");
        }

        [Test]
        public void TestCaseIFrame()
        {
            DriverUtils.OpenUrl(Config.TestPage["Url"]);

            var homePage = new HomePage();

            homePage.WaitUntilLoaded();

            Assert.IsTrue(homePage.IsDisplayed(), "Home page not opend");

            homePage.ClickAlertButton();

            var alertsFramesWindowsPage = new AlertsFramesWindowsPage();

            alertsFramesWindowsPage.WaitUntilLoaded();

            Assert.IsTrue(alertsFramesWindowsPage.IsDisplayed(), "Alerts, Frame & Windows page not opend");

            alertsFramesWindowsPage.ClickMenuSubitem("Nested Frames");

            var nestedFramesPage = new NestedFramesPage();

            nestedFramesPage.WaitUntilLoaded();

            Assert.IsTrue(nestedFramesPage.IsDisplayed(), "Nested Frames page not opend");

            var parentFrameText = nestedFramesPage.GetParentFrameText();

            Assert.AreEqual(parentFrameText, "Parent frame", "Text in parent frame not equal to expected");

            var childFrameText = nestedFramesPage.GetChildFrameText();

            Assert.AreEqual(childFrameText, "Child Iframe", "Text in child frame not equal to expected");

            nestedFramesPage.ClickMenuSubitem("Frames");

            var framesPage = new FramesPage();

            framesPage.WaitUntilLoaded();

            Assert.IsTrue(framesPage.IsDisplayed(), "Frames page not opend");

            var firstText = framesPage.GetFirstFrameText();

            var secondText = framesPage.GetSecondFrameText();

            Assert.AreEqual(firstText, secondText, "Texts in frames are not equal");
        }

        private static IEnumerable<UserData> UsersTestData
        {
            get
            {
                return Config.TestUsers();
            }
        }

        [Test, TestCaseSource(nameof(UsersTestData))]
        public void TestCaseTables(UserData data)
        {
            DriverUtils.OpenUrl(Config.TestPage["Url"]);

            var homePage = new HomePage();

            homePage.WaitUntilLoaded();

            Assert.IsTrue(homePage.IsDisplayed(), "Home page not opend");

            homePage.ClickElementsButton();

            var elementsPage = new ElementsPage();

            elementsPage.WaitUntilLoaded();

            elementsPage.ClickMenuSubitem("Web Tables");

            var tablesPage = new WebTablesPage();

            tablesPage.WaitUntilLoaded();

            Assert.IsTrue(tablesPage.IsDisplayed(), "Web Tables page not opend");

            int userCount = tablesPage.GetUsersCount();

            tablesPage.ClickAddButton();

            Assert.IsTrue(tablesPage.IsFormDisplayed(), "Add user form not displayed");

            tablesPage.FillAddUserForm(data);

            tablesPage.ClickSubmitButton();

            tablesPage.WaitFormClosed();

            Assert.IsFalse(tablesPage.IsFormDisplayed(), "Add user form not closed");

            Assert.IsTrue(tablesPage.UserIsDisplayed(data.Email), $"New user {data.Email} not found");

            int newCount = tablesPage.GetUsersCount();

            Assert.AreNotEqual(userCount, newCount, "User count not chahged");

            tablesPage.DeleteNewUser();

            Assert.IsFalse(tablesPage.UserIsDisplayed(data.Email), $"New user {data.Email} not deleted");
        }

        [Test]
        public void TestCaseHandles()
        {
            DriverUtils.OpenUrl(Config.TestPage["Url"]);

            var homePage = new HomePage();

            homePage.WaitUntilLoaded();

            Assert.IsTrue(homePage.IsDisplayed(), "Home page not opend");

            homePage.ClickAlertButton();

            var alertsFramesWindowsPage = new AlertsFramesWindowsPage();

            alertsFramesWindowsPage.WaitUntilLoaded();

            Assert.IsTrue(alertsFramesWindowsPage.IsDisplayed(), "Alerts, Frame & Windows page is not opend");

            alertsFramesWindowsPage.ClickMenuSubitem("Browser Windows");

            var browserWindowPage = new BrowserWindowPage();

            browserWindowPage.WaitUntilLoaded();

            Assert.IsTrue(browserWindowPage.IsDisplayed(), "Browser Window page not opend");

            browserWindowPage.TabButtonClick();

            DriverUtils.SwitchToNewTab();

            var text = browserWindowPage.GetTabText();

            var url = Webdriver.GetInstance().Url;

            Assert.AreEqual(text, "This is a sample page", "Text in new tab not equal to expected");

            Assert.AreEqual(url, "https://demoqa.com/sample", "New tab URL is not equal to expected");

            DriverUtils.CloseCurrentTabAndReturn();

            Assert.IsTrue(browserWindowPage.IsDisplayed(), "Browser Window page not opend");

            browserWindowPage.ClickMenuCategory("Elements");

            browserWindowPage.ClickMenuSubitem("Links");

            var linksPage = new LinksPage();

            linksPage.WaitUntilLoaded();

            Assert.IsTrue(linksPage.IsDisplayed(), "Links Page is not opend");

            linksPage.ClickHomeLink();

            DriverUtils.SwitchToNewTab();

            homePage.WaitUntilLoaded();

            Assert.IsTrue(homePage.IsDisplayed(), "Home page not opend");

            DriverUtils.SwitchToPreviosTab();

            Assert.IsTrue(linksPage.IsDisplayed(), "Links Page not opend");
        }
    }
}
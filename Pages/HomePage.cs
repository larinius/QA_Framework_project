using Task3.Framework;
using Task3.Framework.WebElements;

namespace Task3
{
    internal class HomePage : BaseForm
    {
        private Button alertsButton;
        private Button elementsButton;

        public HomePage()
            : base(new Banner("//div[@class=\"home-banner\"]", "Home Banner"), "Home Banner")
        {
            string alertButtonLocator = "//div[contains(@class, \"card-body\")][contains(.,\"Alerts, Frame & Windows\")]";

            string elementButtonLocator = "//div[contains(@class, \"card-body\")][contains(.,\"Elements\")]";

            alertsButton = new Button(alertButtonLocator, "Alert Button");

            elementsButton = new Button(elementButtonLocator, "Elements Button");
        }

        public void ClickAlertButton()
        {
            alertsButton.Click();
        }

        public void ClickElementsButton()
        {
            elementsButton.Click();
        }
    }
}
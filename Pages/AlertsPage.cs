using Task3.Forms;
using Task3.Framework;
using Task3.Framework.WebElements;

namespace Task3.Pages
{
    internal class AlertsPage : BaseForm
    {
        private Button alertButton;
        private Button confirmButton;
        private Button promtButton;
        private TextField confirmText;

        public AlertsPage() :
            base(new TextField("//div[@class=\"main-header\"][normalize-space() = 'Alerts']", "Alerts Page"), "Alerts Page")
        {
            alertButton = new Button("//button[@id=\"alertButton\"]", "Alert Button");
            confirmButton = new Button("//button[@id=\"confirmButton\"]", "Confirm Button");
            promtButton = new Button("//button[@id=\"promtButton\"]", "Promt Button");
        }

        public void ClickAlertButton()
        {
            alertButton.Click();
        }

        public void ClickConfirmAlertButton()
        {
            confirmButton.Click();
        }

        public void ClickPromtAlertButton()
        {
            promtButton.Click();
        }

        public string GetPromtComfirmText()
        {
            confirmText = new TextField("//span[@id=\"confirmResult\"]", "Confirm Text");

            return confirmText.GetText();
        }

        public string GetPromtResulltText()
        {
            confirmText = new TextField("//span[@id=\"promptResult\"]", "Confirm Text");

            return confirmText.GetText().Replace("You entered ", "");
        }
    }
}
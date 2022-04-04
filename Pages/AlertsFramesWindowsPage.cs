using Task3.Forms;
using Task3.Framework;
using Task3.Framework.WebElements;

namespace Task3.Pages
{
    internal class AlertsFramesWindowsPage : BaseForm
    {
        private AcordionMenuForm acordionMenu;

        public AlertsFramesWindowsPage()
            : base(new TextField("//div[@class=\"main-header\"][normalize-space() = 'Alerts, Frame & Windows']", "Alerts Frame Window Page"), "Alerts Frame Window Page")
        {
            acordionMenu = new AcordionMenuForm(new Button("//div[@class=\"element-group\"][contains(.,\"Alerts\")]", "LeftAccordion"), "LeftAccordion");
        }

        public void ClickMenuSubitem(string name)
        {
            acordionMenu.WaitAndClickMenuSubitem(name);
        }
    }
}
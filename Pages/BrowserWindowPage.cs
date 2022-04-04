using Task3.Forms;
using Task3.Framework;
using Task3.Framework.WebElements;

namespace Task3.Pages
{
    internal class BrowserWindowPage : BaseForm
    {
        private Button tabButton;
        private AcordionMenuForm acordionMenu;

        public BrowserWindowPage() :
            base(new TextField("//div[@class=\"main-header\"][normalize-space() = 'Browser Windows']", "Browser Windows Page"), "Browser Windows Page")
        {
            tabButton = new Button("//button[@id=\"tabButton\"]", "Tab Button");
            acordionMenu = new AcordionMenuForm(new Button("//div[@class=\"element-group\"][contains(.,\"Alerts\")]", "LeftAccordion"), "LeftAccordion");
        }

        public void TabButtonClick()
        {
            tabButton.Click();
        }

        public string GetTabText()
        {
            var tabText = new TextField("//body", "Tab Text");

            return tabText.GetText();
        }

        public void ClickMenuCategory(string name)
        {
            acordionMenu.ClickMenuCategory(name);
        }

        public void ClickMenuSubitem(string name)
        {
            acordionMenu.WaitAndClickMenuSubitem(name);
        }
    }
}
using Task3.Forms;
using Task3.Framework;
using Task3.Framework.WebElements;

namespace Task3.Pages
{
    internal class ElementsPage : BaseForm
    {
        private AcordionMenuForm acordionMenu;

        public ElementsPage() :
            base(new TextField("//div[@class=\"main-header\"][normalize-space() = 'Elements']", "Elements Page"), "Elements Page")
        {
            acordionMenu = new AcordionMenuForm(new Button("//div[@class=\"element-group\"][contains(.,\"Elements\")]", "LeftAccordion"), "LeftAccordion");
        }

        public void ClickMenuSubitem(string name)
        {
            acordionMenu.WaitAndClickMenuSubitem(name);
        }
    }
}
using Task3.Forms;
using Task3.Framework;
using Task3.Framework.Webdriver;
using Task3.Framework.WebElements;

namespace Task3.Pages
{
    internal class NestedFramesPage : BaseForm
    {
        private AcordionMenuForm acordionMenu;

        public NestedFramesPage() :
            base(new TextField("//div[@class=\"main-header\"][normalize-space() = 'Nested Frames']", "Nested Frames Page"), "Nested Frames Page")
        {
            acordionMenu = new AcordionMenuForm(new Button("//div[@class=\"element-group\"][contains(.,\"Alerts\")]", "LeftAccordion"), "LeftAccordion");
        }

        public void ClickMenuSubitem(string name)
        {
            acordionMenu.WaitAndClickMenuSubitem(name);
        }

        public string GetParentFrameText()
        {
            var parentFrameForm = new FrameForm(new TextField("//body", "Frame Text"), "Parent Frame");

            Webdriver.GetInstance().SwitchTo().Frame(0);

            var text = parentFrameForm.GetText();

            Webdriver.GetInstance().SwitchTo().DefaultContent();

            return text;
        }

        public string GetChildFrameText()
        {
            var childFrameForm = new FrameForm(new TextField("//body", "Frame Text"), "Child Frame");

            Webdriver.GetInstance().SwitchTo().Frame(0).SwitchTo().Frame(0);

            var text = childFrameForm.GetText();

            Webdriver.GetInstance().SwitchTo().DefaultContent();

            return text;
        }
    }
}
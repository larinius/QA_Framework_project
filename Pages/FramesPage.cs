using Task3.Forms;
using Task3.Framework;
using Task3.Framework.Webdriver;
using Task3.Framework.WebElements;

namespace Task3.Pages
{
    internal class FramesPage : BaseForm
    {
        private AcordionMenuForm acordionMenu;

        public FramesPage() :
            base(new TextField("//div[@class=\"main-header\"][normalize-space() = 'Frames']", "Frames Page"), "Frames Page")
        {
            acordionMenu = new AcordionMenuForm(new Button("//div[@class=\"element-group\"][contains(.,\"Alerts\")]", "LeftAccordion"), "LeftAccordion");
        }

        public void ClickMenuSubitem(string name)
        {
            acordionMenu.WaitAndClickMenuSubitem(name);
        }

        public string GetFirstFrameText()
        {
            var frameOneForm = new FrameForm(new TextField("//body", "Frame Text"), "Frame One");

            Webdriver.GetInstance().SwitchTo().Frame(0);

            var t = frameOneForm.GetText();

            Webdriver.GetInstance().SwitchTo().DefaultContent();

            return t;
        }

        public string GetSecondFrameText()
        {
            var frameTwoForm = new FrameForm(new TextField("//body", "Frame Text"), "Frame Two");

            Webdriver.GetInstance().SwitchTo().Frame(1);

            var t = frameTwoForm.GetText();

            Webdriver.GetInstance().SwitchTo().DefaultContent();

            return t;
        }
    }
}
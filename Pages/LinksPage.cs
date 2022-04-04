using Task3.Forms;
using Task3.Framework;
using Task3.Framework.WebElements;

namespace Task3.Pages
{
    internal class LinksPage : BaseForm
    {
        private AcordionMenuForm acordionMenu;
        private Link homeLink;

        public LinksPage() :
            base(new TextField("//div[@class=\"main-header\"][normalize-space() = 'Links']", "Links Page"), "Links Page")
        {
            acordionMenu = new AcordionMenuForm(new Button("//div[@class=\"element-group\"][contains(.,\"Alerts\")]", "LeftAccordion"), "LeftAccordion");

            homeLink = new Link("//a[@id=\"simpleLink\"]", "Home Link");
        }

        public void ClickHomeLink()
        {
            homeLink.Click();
        }
    }
}
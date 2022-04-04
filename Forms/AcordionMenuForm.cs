using Task3.Framework;
using Task3.Framework.Utils;
using Task3.Framework.WebElements;

namespace Task3.Forms
{
    internal class AcordionMenuForm : BaseForm
    {
        public AcordionMenuForm(BaseElement uniqueEement, string name) : base(uniqueEement, name)
        {
        }

        public void ClickMenuCategory(string text)
        {
            Logger.Info($"Click form item \"{text}\"");

            var itemLocator = $"//div[@class=\"element-group\"][contains(.,\"{text}\")]";

            var item = new Button(itemLocator, text);

            item.Click();
        }

        public void WaitAndClickMenuSubitem(string text)
        {
            Logger.Info($"Click form item \"{text}\"");

            var itemLocator = $"//li[contains(@class, 'btn')][.= \"{text}\"]";

            var item = new Button(itemLocator, text);

            item.WaitUntillClickable();
            item.Click();
        }
    }
}
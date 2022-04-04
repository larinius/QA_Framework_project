using Task3.Framework;
using Task3.Framework.WebElements;

namespace Task3.Forms
{
    internal class FrameForm : BaseForm
    {
        private TextField text;

        public FrameForm(BaseElement uniqueElement, string name) : base(uniqueElement, name)
        {
            text = new TextField("//body", "Frame Text");
        }

        public string GetText()
        {
            return text.GetText();
        }
    }
}
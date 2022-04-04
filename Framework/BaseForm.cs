using Task3.Framework.WebElements;

namespace Task3.Framework
{
    abstract class BaseForm
    {
        public string Name { get; set; }
        protected BaseElement UniqueElement { get; set; }
        protected string FormName { get; set; }

        protected BaseForm(BaseElement uniqueElement, string name)
        {
            UniqueElement = uniqueElement;
            Name = name;
        }

        public bool IsDisplayed()
        {
            return UniqueElement.IsDisplayed();
        }

        public void WaitUntilLoaded()
        {
            UniqueElement.WaitUntilLoad();
        }

        public void WaitUntilClosed()
        {
            UniqueElement.WaitUntilClose();
        }
    }
}
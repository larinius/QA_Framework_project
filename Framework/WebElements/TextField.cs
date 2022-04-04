using System.Linq;

namespace Task3.Framework.WebElements
{
    internal class TextField : BaseElement
    {
        public TextField(string locator, string name) :
            base(locator, name)
        {
        }

        public int Count()
        {
            return FindElements().Count();
        }
    }
}
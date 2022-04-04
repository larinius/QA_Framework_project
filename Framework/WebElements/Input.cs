using System.Linq;
using Task3.Framework.Utils;

namespace Task3.Framework.WebElements
{
    internal class Input : BaseElement
    {
        public Input(string locator, string name) :
            base(locator, name)
        {
        }

        public void Sendkeys(string text)
        {
            if (FindElements().Count > 0)
            {
                Logger.Info($"Input \"{Name}\" - send keys. Text: \"{text}\"");
                FindElements().First().SendKeys(text);
            }
            else
            {
                Logger.Warning($"Input \"{Name}\" - send keys error, Element not found. Text: \"{text}\"");
            }
        }
    }
}
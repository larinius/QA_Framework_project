using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using Task3.Framework.Utils;

namespace Task3.Framework.WebElements
{
    abstract class BaseElement
    {
        public string Name { get; set; }
        private By locator;
        private Wait wait;

        protected BaseElement(By locator, string name)
        {
            Name = name;
            this.locator = locator;
            wait = new Wait();
        }

        protected IList<IWebElement> FindElements()
        {
            var e = Webdriver.Webdriver.GetInstance().FindElements(locator);

            return e;
        }

        public void Click()
        {
            if (FindElements().Count > 0)
            {
                FindElements().First().Click();
                Logger.Info($"Element \"{Name}\" clicked");
            }
            else
            {
                Logger.Warning($"Element \"{Name}\" not found, unable to click");
            }
        }

        public bool IsDisplayed()
        {
            var elements = FindElements();

            return (elements.Count > 0) ? true : false;
        }

        public string GetText()
        {
            return (FindElements().Count > 0) ? FindElements().First().Text : string.Empty;
        }

        public void WaitUntilLoad()
        {
            wait.WaitUntilVisible(locator);
        }

        public void WaitUntillClickable()
        {
            wait.WaitUntilClickable(locator);
        }

        public void WaitUntilClose()
        {
            wait.WaitUntilClose(locator);
        }
    }
}
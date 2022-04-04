using NUnit.Framework;
using Task3.Framework.Utils;

namespace Task3.Framework
{
    public class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            Logger.Info("Start test");
        }

        [TearDown]
        public void TearDown()
        {
            Webdriver.Webdriver.DisposeDriver();

            Logger.Info("Test finished");
        }
    }
}
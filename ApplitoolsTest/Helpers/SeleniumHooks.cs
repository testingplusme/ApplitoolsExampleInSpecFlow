using Applitools;
using Applitools.Selenium;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace ApplitoolsTest.Helpers
{
    [Binding]
    public class SeleniumHooks
    {
        private IObjectContainer container;
        public SeleniumHooks(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
           var driver=new ChromeDriver();
            var eyes = new Eyes
            {
                ApiKey = "YOUR-API-KEY",
                FailureReports = FailureReports.OnClose,
            };
            container.RegisterInstanceAs<IWebDriver>(driver);
            container.RegisterInstanceAs<Eyes>(eyes);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = container.Resolve<IWebDriver>();
            var eyes = container.Resolve<Eyes>();
            driver.Close();
            driver.Dispose();
            eyes.Close();
            eyes.AbortIfNotClosed();
            container.Dispose();
        }
    }
}

using System.Drawing;
using Applitools.Selenium;
using ApplitoolsTest.Helpers;
using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ApplitoolsTest.Steps
{
    [Binding]
    public sealed class VisualRegressionSteps
    {
        private IObjectContainer container;
        private IWebDriver Driver => container.Resolve<IWebDriver>();
        private Eyes Eyes => container.Resolve<Eyes>();

        public VisualRegressionSteps(IObjectContainer container)
        {
            this.container = container;
        }

        [Given(@"I enter to (staging|production) blog")]
        public void GivenIEnterToBlog(string envType)
        {
            Eyes.Open(Driver, "WordPress", "WordPress homepage", new Size(1024, 800));
            Driver.Url = envType == "staging" ? TestSettings.StagingUrl : TestSettings.ProductionUrl;
            Eyes.CheckWindow("I enter to home page");
            Eyes.CheckElement(By.CssSelector(".menu-primary-container"));
        }
    }
}

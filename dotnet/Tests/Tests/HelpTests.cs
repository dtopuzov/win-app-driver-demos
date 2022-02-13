using Framework.Settings;
using NUnit.Framework;
using OpenEdge;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Tests
{
    public class HelpTests : ProwinTest
    {
        private Prowin prowin;

        [SetUp]
        public void Setup()
        {
            var settings = new AppSettings();
            settings.Path = @"C:\Progress\OpenEdge\bin\prowin.exe";
            prowin = new Prowin(settings);
        }

        [TearDown]
        public void TearDown()
        {
            prowin.Stop();
        }

        [Test]
        public void Test_Help_About()
        {
            prowin.Click(By.Name("Help"));
            prowin.Click(By.Name("About Procedure Editor"));
            Thread.Sleep(1000);
        }
    }
}

using Framework.Settings;
using NUnit.Framework;
using OpenEdge;
using OpenQA.Selenium;

namespace Tests
{
    public class PSC237810Test : ProwinTest
    {
        private Prowin prowin;

        [SetUp]
        public void Setup()
        {
            var settings = new AppSettings();
            settings.Path = @"C:\Progress\OpenEdge\bin\prowin.exe";
            settings.WorkingDirectory = @"C:\OpenEdge\WRK\PSC00237810";
            settings.Args = @"-usewidgetid -p runit.p";

            prowin = new Prowin(settings);
        }

        [TearDown]
        public void TearDown()
        {
            prowin.Stop();
        }

        [Test]
        public void Test_PSC237810()
        {
            prowin.Click(By.Name("Show Browse Form"));
            var form = Desktop.Find(By.Name("BrowseForm"));

            Assert.Multiple(() =>
            {
                Assert.IsTrue(form.Size.Width > 100);
                Assert.IsTrue(form.Size.Height > 100);
            });
        }
    }
}

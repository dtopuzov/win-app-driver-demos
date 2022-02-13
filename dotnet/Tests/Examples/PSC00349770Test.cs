using Framework.Settings;
using NUnit.Framework;
using OpenEdge;
using System.Threading;

namespace Tests
{
    public class PSC00349770Test : ProwinTest
    {
        private Prowin prowin;

        [SetUp]
        public void Setup()
        {
            var settings = new AppSettings();
            settings.Path = @"C:\Progress\OpenEdge\bin\prowin.exe";
            settings.WorkingDirectory = @"C:\OpenEdge\WRK\PSC00349770";
            settings.Args = @"-usewidgetid -p runit.p";

            prowin = new Prowin(settings);
        }

        [TearDown]
        public void TearDown()
        {
            prowin.Stop();
        }

        [Test]
        public void Test_PSC00349770()
        {
            Thread.Sleep(1000);
        }
    }
}

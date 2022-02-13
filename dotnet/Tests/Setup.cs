using Framework.Server;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// A SetUpFixture outside of any namespace provides
    /// SetUp and TearDown for the entire assembly.
    /// </summary>
    [SetUpFixture]
    public class Setup
    {
        /// <summary>
        /// Executes once before the test run.
        /// </summary>
        [OneTimeSetUp]
        public void GlobalSetup()
        {
            Server.Start();
        }

        /// <summary>
        /// Executes once after the test run.
        /// </summary>
        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            Server.Stop();
        }
    }
}

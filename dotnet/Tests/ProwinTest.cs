using Framework;
using Framework.Utils;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ProwinTest
    {
        protected static App App { get; private set; }

        protected static Desktop Desktop { get; private set; }

        [OneTimeSetUp]
        public void ClassInit()
        {
            // Once before app tests in class.
            Desktop = new Desktop();
            Processes.KillByName("prowin");
        }

        [SetUp]
        public void TestInit()
        {
            // Runs before each test.
        }

        [TearDown]
        public void TestCleanup()
        {
            // Runs after each test.
        }

        [OneTimeTearDown]
        public void ClassCleanup()
        {
            // Runs once after all tests in this class are executed. (Optional)
            // Not guaranteed that it executes instantly after all tests from the class.
        }
    }
}

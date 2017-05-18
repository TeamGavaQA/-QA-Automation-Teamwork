using Blog.Tests.Utilities;
using NUnit.Framework;

namespace Blog.Tests.TestFixtures
{
    [SetUpFixture]
    public class GlobalSetup
    {
        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            // Workaround for Seleno not disposing of more than one instance.
            BrowserHosts.TerminateInstances();
        }
    }
}

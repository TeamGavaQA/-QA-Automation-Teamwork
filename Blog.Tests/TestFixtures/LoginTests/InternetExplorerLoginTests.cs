using Blog.Tests.Utilities;
using NUnit.Framework;

namespace Blog.Tests.TestFixtures.LoginTests
{
    [TestFixture]
    public class InternetExplorerLoginTests : AbstractLoginTests
    {
        public InternetExplorerLoginTests()
        {
            this.Driver = BrowserHosts.InternetExplorer;
        }

        [Test]
        public override void LoginShouldFailWithoutEmail()
        {
            base.LoginShouldFailWithoutEmail();
        }

        [Test]
        public override void LoginShouldFailWithoutPassword()
        {
            base.LoginShouldFailWithoutPassword();
        }
    }
}
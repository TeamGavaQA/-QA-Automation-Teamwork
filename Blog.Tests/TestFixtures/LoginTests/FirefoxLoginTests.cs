using Blog.Tests.Utilities;
using NUnit.Framework;

namespace Blog.Tests.TestFixtures.LoginTests
{
    [TestFixture]
    public class FirefoxLoginTests : AbstractLoginTests
    {
        public FirefoxLoginTests()
        {
            this.Driver = BrowserHosts.Firefox;
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

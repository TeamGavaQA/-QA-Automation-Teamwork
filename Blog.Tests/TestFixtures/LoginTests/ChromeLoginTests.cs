using Blog.Tests.Utilities;
using NUnit.Framework;

namespace Blog.Tests.TestFixtures.LoginTests
{
    [TestFixture]
    public class ChromeLoginTests : AbstractLoginTests
    {
        public ChromeLoginTests()
        {
            this.Driver = BrowserHosts.Chrome;
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

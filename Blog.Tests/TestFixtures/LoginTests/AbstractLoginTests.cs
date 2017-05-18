using Blog.Tests.Models;
using Blog.Tests.Pages.LoginPage;

namespace Blog.Tests.TestFixtures.LoginTests
{
    public class AbstractLoginTests : AbstractSeleniumTests<LoginPage, LoginPageModel>
    {
        public virtual void LoginShouldFailWithoutEmail()
        {
            this.Page.FillLoginForm(this.Model);

            this.Page.AssertTextMatch(this.Page.EmailErrorMessage, this.Model.ExpectedError);
        }

        public virtual void LoginShouldFailWithoutPassword()
        {
            this.Page.FillLoginForm(this.Model);

            this.Page.AssertTextMatch(this.Page.PasswordErrorMessage, this.Model.ExpectedError);
        }
    }
}

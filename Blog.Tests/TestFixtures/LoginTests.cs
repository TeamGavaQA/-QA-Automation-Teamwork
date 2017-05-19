using Blog.Tests.Models;
using Blog.Tests.Pages.LoginPage;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Blog.Tests.TestFixtures
{
    public class LoginTests<TDriver> : AbstractSeleniumTests<TDriver, LoginPage, LoginPageModel>
        where TDriver : IWebDriver
    {
        [Test]
        public void LoginShouldFailWithoutEmail()
        {
            this.Page.FillLoginForm(this.Model);

            this.Page.AssertTextMatch(this.Page.EmailErrorMessage, this.Model.ExpectedError);
        }

        [Test]
        public void LoginShouldFailWithoutPassword()
        {
            this.Page.FillLoginForm(this.Model);

            this.Page.AssertTextMatch(this.Page.PasswordErrorMessage, this.Model.ExpectedError);
        }
    }
}

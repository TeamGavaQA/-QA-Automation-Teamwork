using Blog.Tests.Models;
using Blog.Tests.Pages.RegistrationPage;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Blog.Tests.TestFixtures
{
    public class RegistrationTests<TDriver> : AbstractSeleniumTests<TDriver, RegistrationPage, RegistrationPageModel>
        where TDriver : IWebDriver
    {
        [Test]
        public void RegisterShouldFailWithoutEmail()
        {
            FillFormAndAssertError();
        }

        [Test]
        public void RegisterShouldFailWithoutFullName()
        {
            FillFormAndAssertError();
        }

        [Test]
        public void RegisterShouldFailWithoutPassword()
        {
            FillFormAndAssertError();
        }

        [Test]
        public void RegisterShouldFailWithInvalidEmail()
        {
            FillFormAndAssertError();
        }

        [Test]
        public void RegisterShouldFailWithTooLongFullName()
        {
            FillFormAndAssertError();
        }

        [Test]
        public void RegisterShouldFailWithMissmatchedPaswords()
        {
            FillFormAndAssertError();
        }

        private void FillFormAndAssertError()
        {
            this.Page.FillRegistrationForm(this.Model);

            this.Page.AssertTextMatch(this.Page.ErrorMessage, this.Model.ExpectedError);
        }
    }
}

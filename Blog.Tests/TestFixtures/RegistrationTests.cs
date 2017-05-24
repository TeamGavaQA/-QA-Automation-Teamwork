using Blog.Tests.Models;
using Blog.Tests.Pages.RegistrationPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Tests.TestFixtures
{
    class RegistrationTests<TDriver> : AbstractSeleniumTests<TDriver, RegistrationPage, RegistrationPageModel>
        where TDriver : IWebDriver
    {
        [Test]
        public void NavigateToRegistrationPage()
        {
            this.Page.NavigateTo();
            this.Page.RegistrationButton.Click();

            this.Page.AssertTextMatch(this.Page.RegistrationHeader, "Register");
        }
        [Test]
        public void RegisterShouldFailWithoutEmail()
        {
            this.Page.FillRegistrationForm(this.Model);

            this.Page.AssertTextMatch(this.Page.EmailErrorMessage, this.Model.ExpectedError);
        }
        [Test]
        public void RegisterShouldFailWithoutFullName()
        {
            this.Page.FillRegistrationForm(this.Model);

            this.Page.AssertTextMatch(this.Page.FullNameErrorMessage, this.Model.ExpectedError);
        }


    }
}

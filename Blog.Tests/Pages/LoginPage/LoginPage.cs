using Blog.Tests.Models;
using Blog.Tests.Pages.AbstractPage;
using OpenQA.Selenium;

namespace Blog.Tests.Pages.LoginPage
{
    public partial class LoginPage : AbstarctPage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        protected override string URL => base.baseUrl + "Account/Login";

        public void FillLoginForm(LoginPageModel model)
        {
            Type(this.Email, model.Email);
            Type(this.Password, model.Password);
            if (model.RememberMe == "1")
            {
                this.RememberMe.Click();
            }

            this.SubmitButton.Click();
        }
    }
}

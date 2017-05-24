using Blog.Tests.Models;
using OpenQA.Selenium;

namespace Blog.Tests.Pages.RegistrationPage
{
    public partial class RegistrationPage : AbstractPage.AbstractPage
    {
        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }
        protected override string URL => base.baseUrl + "Account/Register";

        public void FillRegistrationForm(RegistrationPageModel model)
        {
            Type(this.Email, model.Email);
            Type(this.FullName, model.FullName);
            Type(this.Password, model.Password);
            Type(this.ConfirmPassword, model.ConfirmPassword);
            if (model.RememberMe == "1")
            {
                this.RememberMe.Click();
            }


            this.RegButton.Click();
        }

    }
}

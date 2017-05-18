using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Blog.Tests.Pages.LoginPage
{
    public partial class LoginPage
    {
        public IWebElement Email =>
            this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));    

        public IWebElement Password =>
            this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Password")));

        public IWebElement RememberMe =>
            this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("RememberMe")));

        public IWebElement SubmitButton =>
            this.Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[type=submit]")));

        public IWebElement EmailErrorMessage
        {
            get
            {
                const string path = "/html/body/div[2]/div/div/form/div[1]/div/span/span";
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath(path)));

                return this.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(path)));
            }
        }

        public IWebElement PasswordErrorMessage
        {
            get
            {
                const string path = "/html/body/div[2]/div/div/form/div[2]/div/span/span";
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath(path)));

                return this.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(path)));
            }
        }
    }
}

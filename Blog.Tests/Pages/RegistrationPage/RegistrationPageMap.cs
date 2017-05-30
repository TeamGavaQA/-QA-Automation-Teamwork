using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Blog.Tests.Pages.RegistrationPage
{
    public partial class RegistrationPage
    {
        public IWebElement RegistrationButton =>
            this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("registerLink")));

        public IWebElement Email =>
            this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));

        public IWebElement FullName =>
            this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("FullName")));

        public IWebElement Password =>
            this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Password")));

        public IWebElement ConfirmPassword =>
            this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ConfirmPassword")));

        public IWebElement RegButton =>
            this.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/div/form/div[6]/div/input")));

        public IWebElement ErrorMessage
        {
            get
            {
                const string path = "/html/body/div[2]/div/div/form/div[1]/ul/li";
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath(path)));

                return this.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(path)));
            }
        }
    }
}

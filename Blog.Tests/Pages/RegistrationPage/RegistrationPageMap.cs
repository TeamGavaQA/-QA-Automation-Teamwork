using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Tests.Pages.RegistrationPage
{
    public partial class RegistrationPage
    {
        public IWebElement RegistrationButton =>
            this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("registerLink")));

        public IWebElement RegistrationHeader =>
            this.Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".well>h2:nth-child(1)")));

        public IWebElement Email =>
            this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));

        public IWebElement FullName =>
            this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("FullName")));

        public IWebElement Password =>
            this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Password")));

        public IWebElement ConfirmPassword =>
            this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ConfirmPassword")));

        public IWebElement RememberMe =>
             this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("RememberMe")));


        public IWebElement RegButton =>
            this.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/div/form/div[6]/div/input")));

        public IWebElement EmailErrorMessage
        {
            get
            {
                const string path = "/html/body/div[2]/div/div/form/div[1]/ul/li";
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath(path)));

                return this.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(path)));
            }
        }

        public IWebElement FullNameErrorMessage
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

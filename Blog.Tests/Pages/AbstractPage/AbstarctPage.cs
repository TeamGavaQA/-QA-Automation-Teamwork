using System;
using System.Collections.Generic;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Blog.Tests.Pages.AbstractPage
{
    public abstract partial class AbstarctPage
    {
        protected string baseUrl = ConfigurationManager.AppSettings["URL"];

        protected AbstarctPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(10));
            this.Builder = new Actions(this.Driver);

        }

        protected virtual string URL { get; set; }

        protected IWebDriver Driver { get; }

        protected WebDriverWait Wait { get; }

        protected Actions Builder { get; set; }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(URL);
        }

        public void FollowLink(string linkText)
        {
            this.Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(linkText))).Click();
        }

        public static void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text ?? string.Empty);
        }

        public static void ClickOnElements(
            IReadOnlyList<IWebElement> elements, IReadOnlyList<bool> values)
        {
            for (var i = 0; i < values.Count; i++)
            {
                if (values[i])
                {
                    elements[i].Click();
                }
            }
        }

    }
}
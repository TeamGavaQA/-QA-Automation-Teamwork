using System;
using Blog.Tests.Pages.AbstractPage;
using Blog.Tests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using TestStack.Seleno.Configuration;

namespace Blog.Tests.TestFixtures
{
    public abstract class AbstractSeleniumTests<TPage, TModel>
        where TPage : AbstarctPage
    {
        protected IWebDriver Driver;
        protected TPage Page;
        protected TModel Model;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.Page = (TPage) Activator.CreateInstance(typeof(TPage), this.Driver);
            this.Driver.Manage().Window.Maximize();
        }

        [SetUp]
        public void Init()
        {
            this.Page.NavigateTo();
            this.Model = ExcelDataReader.GetTestData<TModel>();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
        }
    }

}
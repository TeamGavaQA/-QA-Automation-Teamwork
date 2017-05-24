using System;
using System.Configuration;
using System.IO;
using Blog.Tests.Pages.AbstractPage;
using Blog.Tests.Utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Blog.Tests.TestFixtures
{
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    public abstract class AbstractSeleniumTests<TDriver, TPage, TModel>
        where TPage : AbstractPage
        where TDriver : IWebDriver
    {
        protected IWebDriver Driver;
        protected TPage Page;
        protected TModel Model;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.Driver = BrowserHosts.GetInstance<TDriver>();
            this.Page = (TPage) Activator.CreateInstance(typeof(TPage), this.Driver);
            this.Driver.Manage().Window.Maximize();
        }

        [SetUp]
        public void Init()
        {
            this.Page.NavigateTo();
            this.Model = ExcelDataReader.GetTestData<TModel>();
        }

        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var screenshotPath = Path.GetFullPath(Path.Combine(
                    TestContext.CurrentContext.TestDirectory,
                    ConfigurationManager.AppSettings["FailedTestScreenshotsPath"]));
                if (!Directory.Exists(screenshotPath))
                {
                    Directory.CreateDirectory(screenshotPath);
                }

                ((ITakesScreenshot) this.Driver).GetScreenshot().SaveAsFile(
                    Path.Combine(screenshotPath, $"{TestContext.CurrentContext.Test.Name}.jpg"),
                    ScreenshotImageFormat.Jpeg);
            }
        }
    }

}
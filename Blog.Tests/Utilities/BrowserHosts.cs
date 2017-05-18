using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using TestStack.Seleno.Configuration;

namespace Blog.Tests.Utilities
{
    public static class BrowserHosts
    {
        private static readonly Func<RemoteWebDriver, SelenoHost> hostInit = driver =>
        {
            var host = new SelenoHost();
            host.Run("Blog", 60634, c => c.WithRemoteWebDriver(() => driver));

            return host;
        };

        private static readonly Lazy<SelenoHost> _chromeHost = new Lazy<SelenoHost>(
            () => hostInit(new ChromeDriver()));

        private static readonly Lazy<SelenoHost> _firefoxHost = new Lazy<SelenoHost>(
            () => hostInit(new FirefoxDriver()));

        private static readonly Lazy<SelenoHost> _internetExplorerHost = new Lazy<SelenoHost>(
            () => hostInit(new InternetExplorerDriver()));

        public static IWebDriver Chrome => _chromeHost.Value.Application.Browser;
        public static IWebDriver Firefox => _firefoxHost.Value.Application.Browser;
        public static IWebDriver InternetExplorer => _internetExplorerHost.Value.Application.Browser;

        public static void TerminateInstances()
        {
            if (_chromeHost.IsValueCreated)
            {
                Chrome.Quit();
            }
            if (_firefoxHost.IsValueCreated)
            {
                Firefox.Quit();
            }
            if (_internetExplorerHost.IsValueCreated)
            {
                InternetExplorer.Quit();
            }
        }
    }
}

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

        private static readonly Lazy<SelenoHost> _chromeHost = new Lazy<SelenoHost>(() =>
            hostInit(new ChromeDriver()));
        private static readonly Lazy<SelenoHost> _firefoxHost = new Lazy<SelenoHost>(() =>
            hostInit(new FirefoxDriver()));
        private static readonly Lazy<SelenoHost> _internetExplorerHost = new Lazy<SelenoHost>(() =>
            hostInit(new InternetExplorerDriver()));

        private static IWebDriver Chrome => _chromeHost.Value.Application.Browser;
        private static IWebDriver Firefox => _firefoxHost.Value.Application.Browser;
        private static IWebDriver InternetExplorer => _internetExplorerHost.Value.Application.Browser;

        public static IWebDriver GetInstance<T>() where T : IWebDriver
        {
            switch (typeof(T).Name)
            {
                case nameof(ChromeDriver):
                    return Chrome;
                case nameof(FirefoxDriver):
                    return Firefox;
                case nameof(InternetExplorerDriver):
                    return InternetExplorer;
                default:
                    throw new ArgumentException("Unsupported browser type", typeof(T).Name);
            }
        }

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

using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using TestStack.Seleno.Configuration;

namespace Blog.Tests.Utilities
{
    public static class BrowserHosts
    {
        private static readonly Dictionary<Type, SelenoHost> _instances =
            new Dictionary<Type, SelenoHost>();

        public static IWebDriver GetInstance<T>() where T : IWebDriver
        {
            var type = typeof(T);
            if (!_instances.ContainsKey(type))
            {
                var host = new SelenoHost();
                Func<RemoteWebDriver> browserConstructor;
                switch (type.ToString())
                {
                    // Override the constructor for specific browsers here if needed.
                    default:
                        browserConstructor = () =>
                            (RemoteWebDriver) Activator.CreateInstance(typeof(T));
                        break;
                }

                host.Run("Blog", 60634, c => c.WithRemoteWebDriver(browserConstructor));

                _instances[type] = host;
            }

            return _instances[type].Application.Browser;
        }

        public static void TerminateInstances()
        {
            foreach (var selenoHost in _instances.Values)
            {
                selenoHost.Application.Browser.Quit();
            }
        }
    }
}

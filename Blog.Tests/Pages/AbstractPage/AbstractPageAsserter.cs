using NUnit.Framework;
using OpenQA.Selenium;

namespace Blog.Tests.Pages.AbstractPage
{
    public abstract partial class AbstractPage
    {
        public void AssertTextMatch(IWebElement element, string text)
        {
            StringAssert.Contains(text, element.Text);
        }

        public void AssertHasClass(IWebElement target, string classValue)
        {
            StringAssert.Contains(classValue, target.GetAttribute("class"));
        }

        public void AssertLacksClass(IWebElement target, string classValue)
        {
            StringAssert.DoesNotContain(classValue, target.GetAttribute("class"));
        }
    }
}

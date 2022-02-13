using System.Collections.Generic;
using Framework.Settings;
using Framework.Utils;
using Framework.WinAppDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;

namespace Framework
{
    public class App
    {
        public App(AppSettings settings)
        {
            var options = Client.AppSessionOptions(settings);
            Driver = new WindowsDriver<WindowsElement>(Server.Server.ServiceUri, options);
        }

        public App(AppiumOptions options)
        {
            Driver = new WindowsDriver<WindowsElement>(Server.Server.ServiceUri, options);
        }

        public AppiumDriver<WindowsElement> Driver { get; private set; }

        public virtual void Stop()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }

        public WindowsElement Find(By locator)
        {
            Wait.Until(() => Driver.FindElements(locator).Count > 0);
            return Driver.FindElement(locator);
        }

        public IReadOnlyCollection<WindowsElement> FindAll(By locator, bool wait = true)
        {
            if (wait)
            {
                Wait.Until(() => Driver.FindElements(locator).Count > 0);
            }

            return Driver.FindElements(locator);
        }

        public WindowsElement FindByText(string text, bool exactMatch = true)
        {
            return Find(GetTextLocator(text, exactMatch));
        }

        public IReadOnlyCollection<WindowsElement> FindAllByText(string text, bool exactMatch = true, bool wait = true)
        {
            return FindAll(GetTextLocator(text, exactMatch), wait);
        }

        public void Click(By locator)
        {
            var element = Find(locator);
            var action = new Actions(Driver);
            action.MoveToElement(element).Click().Perform();
        }

        private By GetTextLocator(string text, bool exactMatch = true)
        {
            return exactMatch
                ? By.Name(text)
                : By.XPath($"//*[contains(@Name,'{text}')]");
        }
    }
}

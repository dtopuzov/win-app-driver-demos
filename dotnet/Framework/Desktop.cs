using System.Collections.Generic;
using Framework.Utils;
using Framework.WinAppDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace Framework
{
    public class Desktop
    {
        public Desktop()
        {
            var options = Client.RootSessionOptions();
            Driver = new WindowsDriver<WindowsElement>(Server.Server.ServiceUri, options);
        }

        public AppiumDriver<WindowsElement> Driver { get; private set; }

        public void Stop()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }

        public App GetAppByTitle(string title)
        {
            var titleElement = Find(By.Name(title));
            var winHandleString = titleElement.GetAttribute("NativeWindowHandle");
            var winHandleHex = int.Parse(winHandleString).ToString("x");

            var options = new AppiumOptions();
            options.AddAdditionalCapability("appTopLevelWindow", winHandleHex);
            options.AddAdditionalCapability("deviceName", "WindowsPC");

            return new App(options);
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

        private By GetTextLocator(string text, bool exactMatch = true)
        {
            return exactMatch
                ? By.Name(text)
                : By.XPath($"//*[contains(@Name,'{text}')]");
        }
    }
}

using Framework.Settings;
using OpenQA.Selenium.Appium;

namespace Framework.WinAppDriver
{
    public class Client
    {
        public static AppiumOptions AppSessionOptions(AppSettings settings)
        {
            var options = new AppiumOptions();
            options.AddAdditionalCapability("platformName", "Windows");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            options.AddAdditionalCapability("app", settings.Path);

            if (settings.WorkingDirectory != null)
            {
                options.AddAdditionalCapability("appWorkingDir", settings.WorkingDirectory);
            }

            if (settings.Args != null)
            {
                options.AddAdditionalCapability("appArguments", settings.Args);
            }

            return options;
        }

        public static AppiumOptions RootSessionOptions()
        {
            var options = new AppiumOptions();
            options.AddAdditionalCapability("platformName", "Windows");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            options.AddAdditionalCapability("app", "Root");
            return options;
        }
    }
}

using Microsoft.IdentityModel.Protocols;
using NLog.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.DriverInitialization;
public class DriverInstance
{
    public IWebDriver GetDriverInstance()
    {
        ChromeOptions chromeOptions = new();

        var baseDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

        chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
        chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
        chromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);

        chromeOptions.AddUserProfilePreference("profile.default_content_settings.popups", 0);
        chromeOptions.AddUserProfilePreference("profile.content_settings.exceptions.automatic_downloads.*.setting", 1);
        chromeOptions.AddUserProfilePreference("download.extensions_to_open", "applications/pdf");
        chromeOptions.AddUserProfilePreference("browser.set_download_behavior", "allow");

        chromeOptions.AddArguments("--disable-notifications");
        chromeOptions.AddArguments("--start-maximized");
        chromeOptions.AddArguments("--ignore-certificate-errors");
        chromeOptions.AddArguments("--disable-infobars");

        chromeOptions.AddUserProfilePreference("intl.accept_languages", "nl");
        chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");

        return new ChromeDriver(ChromeDriverService.CreateDefaultService(), chromeOptions, TimeSpan.FromMinutes(3));
    }
}

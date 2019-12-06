using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Rave.Test.SauceLab
{
	public class Base
	{
		private static RemoteWebDriver driver;

		public static RemoteWebDriver Driver
		{
			get
			{
				if (driver == null)
					throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
				return driver;
			}
			private set
			{
				driver = value;
			}
		}

		[BeforeScenario]
		public static void StartBrowser()
		{
			var platform = ConfigurationManager.AppSettings["platform"].ToString();
			SetBrowserCapabilityBasedOnPlatform(platform);
			var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
			Thread.Sleep(5000);
		}

		[AfterScenario]
		public static void CloseDriver()
		{
			Driver.Close();
			Driver.Quit();
		}

		private static void SetBrowserCapabilityBasedOnPlatform(string platform)
		{
			var capabilities = new DesiredCapabilities();
			if (platform.Equals("ios", StringComparison.InvariantCulture))
			{
				capabilities.SetCapability("testobjectApiKey", "580A8664A557447E90C43C7F38177CE1");
				capabilities.SetCapability("platformName", "iOS");
				capabilities.SetCapability("deviceName", "iPhone_6_free");
				capabilities.SetCapability("cacheId", "16ea658d164");
				capabilities.SetCapability("browserName", "safari");
				capabilities.SetCapability("initialBrowserUrl", "https://www.fthecouch.com/portal/account/signin");
				capabilities.SetCapability("testobject_app_id", "1");
				capabilities.SetCapability("name", "iOS - Safari Browser - 	Real device - test env");
				capabilities.SetCapability("appiumVersion", "1.15.0");
				capabilities.SetCapability("autoWebview", true);
				capabilities.SetCapability("autoWebview", true);
			}
			else if (platform.Equals("android", StringComparison.InvariantCulture))
			{
				capabilities.SetCapability("testobjectApiKey", "06C8838A16A240D78DE312D18FF77BC3");
				capabilities.SetCapability("platformName", "Android");
				capabilities.SetCapability("deviceName", "Samsung_Galaxy_S6_sjc_free");
				capabilities.SetCapability("cacheId", "16ea26d56b5");
				capabilities.SetCapability("browserName", "chrome");
				capabilities.SetCapability("testobject_app_id", "1");
				capabilities.SetCapability("name", "Android - Chrome browser - Real device - test env");
				capabilities.SetCapability("appiumVersion", "1.15.0");
				capabilities.SetCapability("noReset", false);
				capabilities.SetCapability("unicodeKeyboard", true);
				capabilities.SetCapability("resetKeyboard", true);
				capabilities.SetCapability("autoGrantPermissions", true);
			}
			driver = new RemoteWebDriver(new Uri("http://us1-manual.app.testobject.com/wd/hub"), capabilities);
		}
	}
}
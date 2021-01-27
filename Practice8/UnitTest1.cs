using System;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Practice8
{
    [TestFixture]
    public class Tests
    {
        private static Uri testServerAddress = new Uri("http://localhost:4723/wd/hub");
        private static TimeSpan INIT_TIMEOUT_SEC = TimeSpan.FromSeconds(180);
      
        
        private  AndroidDriver<AndroidElement> driver;
        private  AppiumOptions capabilities;
        private LoginPage loginPage;

        [OneTimeSetUp]
        public void Setup()
        {
            capabilities =new AppiumOptions();
            capabilities.AddAdditionalCapability("browserstack.user", Environment.GetEnvironmentVariable("browserstack.user"));
            capabilities.AddAdditionalCapability("browserstack.key", Environment.GetEnvironmentVariable("browserstack.key"));

            // Set URL of the application under test
            capabilities.AddAdditionalCapability("app", "bs://16ca59803e95ce5206916cb67469fd69189551f6");

            // Specify device and os_version
            capabilities.AddAdditionalCapability("device", "Google Pixel 3");
            capabilities.AddAdditionalCapability("os_version", "10.0");

            // Specify the platform name
            capabilities.PlatformName = "Android";

            // Set other BrowserStack capabilities
            capabilities.AddAdditionalCapability("project", "First CSharp project");
            capabilities.AddAdditionalCapability("build", "CSharp Android");
            capabilities.AddAdditionalCapability("name", "first_test");
            //capabilities = new AppiumOptions();
            //capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, "6378e3f9");
            //capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            //capabilities.AddAdditionalCapability(MobileCapabilityType.App, @"C:\Users\yyuur\AndroidStudioProjects\Practice8\app\build\outputs\apk\debug\app-debug.apk");
            capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.example.practice8");
            capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "com.example.practice8.ui.login.LoginActivity");
            capabilities.AddAdditionalCapability(MobileCapabilityType.NoReset, true);

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                new Uri("http://hub-cloud.browserstack.com/wd/hub"), capabilities);
            loginPage = new LoginPage(driver)
            {
                UsernameField = driver.FindElementById("com.example.practice8:id/username"),
                PasswordField = driver.FindElementById("com.example.practice8:id/password"),
                LoginButton = driver.FindElementById("com.example.practice8:id/login")
            };
        }
        [TestCase("", "123456", TestName = "INVALID USERNAME ")]
        [TestCase("g", "123", TestName = "INVALID  PASS")]
        [TestCase("g", "123456", TestName = "VALID USERNAME AND PASS")]
        public void Test1(string username, string password)
        {

            loginPage.UsernameField.SendKeys(username);
            loginPage.PasswordField.SendKeys(password);

            Assert.True(loginPage.LoginButton.Enabled);
        }

    }
}
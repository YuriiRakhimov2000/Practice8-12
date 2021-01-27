using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;

namespace Practice8
{
    class LoginPage
    {
        public AppiumDriver<AndroidElement> driver;

        public LoginPage(AppiumDriver<AndroidElement> driver) => this.driver = driver;
        public AndroidElement UsernameField { get; set; }
        
        public AndroidElement PasswordField { get; set; }
        public AndroidElement LoginButton { get; set; }




    }
}

using System;
using System.Threading;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace ShoeBot
{
    /// <summary>
    /// C:\Users\zhhlb\AppData\Local\Android\Sdk\tools\bin
    /// </summary>
    public class ThunderAutomation
    {
        //private WindowsDriver<WindowsElement> _driver;
        private const string calApp = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";
        private const string appiumDriverURI = "http://127.0.0.1:4723";
        protected static WindowsDriver<WindowsElement> calSession;

        public void Auto()
        {
            WindowsDriver<WindowsElement> driver;
            AppiumOptions options = new AppiumOptions();
            //options.PlatformName = "Android";
            options.AddAdditionalCapability("deviceName", "MyDevice");
            options.AddAdditionalCapability("platformVersion", "PlatformV");
            options.AddAdditionalCapability("automationName", "UiAutomator2");
            options.AddAdditionalCapability("appPackage", "MyPackage");
            options.AddAdditionalCapability("appActivity", "MyActivity");

            Uri url = new Uri("http://127.0.0.1:4723/wd/hub");

            driver = new WindowsDriver<WindowsElement>(url, options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var username = "test";
            // Some example selectors
            var element = driver.FindElementByXPath("//*[@text='登录']");
            element.Click();
            //driver.FindElementByClassName("android.widget.EditText").SendKeys("test");
            //driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().className(\"android.widget.EditText\").instance(1)")).SendKeys(username);
        }

        public void beforeAll()
        {
            //DesiredCapabilities capabilities = new DesiredCapabilities();

            //capabilities.SetCapability("deviceName", "Android Emulator");
            //capabilities.SetCapability("platformName", "Android");
            //capabilities.SetCapability("platformVersion", "5");
            //capabilities.SetCapability("udid", "emulator-5554");
            //capabilities.SetCapability("appPackage", "com.tencent.mobileqq");
            //capabilities.SetCapability("appActivity", "com.tencent.mobileqq.activity.SplashActivity");
            //capabilities.SetCapability("unicodeKeyboard", "true"); //支持中文输入
            //capabilities.SetCapability("resetKeyboard", "true"); //支持中文输入，必须两条都配置
            //--------------------------------------------------------------------------------------------//
            DesiredCapabilities capabilities = new DesiredCapabilities();

            capabilities.SetCapability("deviceName", "Android Emulator");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "5");
            capabilities.SetCapability("udid", "emulator-5554");
            capabilities.SetCapability("appPackage", "com.android.settings");
            capabilities.SetCapability("appActivity", ".Settings");
            capabilities.SetCapability("unicodeKeyboard", "true"); //支持中文輸入
            capabilities.SetCapability("resetKeyboard", "true"); //支持中文輸入，必須兩條都配置

            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);

            //RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var element = driver.FindElementByXPath("//*[@text='蓝牙']");
            element.Click();

        }

        public void wechat()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("deviceName", "Android Emulator");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "5");
            capabilities.SetCapability("udid", "emulator-5554");
            capabilities.SetCapability("appPackage", "com.tencent.mm");
            capabilities.SetCapability("appActivity", ".ui.LauncherUI");
            capabilities.SetCapability("unicodeKeyboard", "true"); //support for Chinese
            capabilities.SetCapability("resetKeyboard", "true"); //support for Chinese

            //create remote driver
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);

            //step 1: click login
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var element = driver.FindElementByXPath("//*[@text='登录']");
            element.Click();

            //step 2: switch to use email and account number to login
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            element = driver.FindElementById("com.tencent.mm:id/cvf");
            element.Click();

            //step 3: input username
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            element = driver.FindElementByXPath("//*[contains(@text, '请填写微信号')]");
            element.SendKeys("hzhou55@asu.edu");

            //step 4: input password
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            element = driver.FindElementById("com.tencent.mm:id/cve").FindElement(By.Id("com.tencent.mm:id/li"));
            element.SendKeys("");

            //step 5: log in
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            element = driver.FindElementByXPath("//*[@text='登录']");
            element.Click();

            //直接登录步骤
            //step 6: find sombody
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            element = driver.FindElementByXPath("(//*[@class='android.widget.LinearLayout'])[9]");
            element.Click();

            //step 7: type sth
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            element = driver.FindElementById("com.tencent.mm:id/aom");
            element.SendKeys("shoe bot test sending message");

            //step 8: send message
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            element = driver.FindElementByXPath("//*[@text='发送']");
            element.Click();

            ////换密码后登录
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //var element = driver.FindElementByXPath("//*[@text='切换验证方式']");
            //element.Click();

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //element = driver.FindElementById("com.tencent.mm:id/lq");
            //element.Click();

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //element = driver.FindElementById("com.tencent.mm:id/cvo").FindElement(By.Id("com.tencent.mm:id/li"));
            //element.SendKeys("");
        }
    }
}

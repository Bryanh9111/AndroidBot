using System;
using System.Threading;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace ShoeBot
{
    class Program
    {
        public static void Main(string[] args)
        {
            ThunderAutomation automation = new ThunderAutomation();
            automation.wechat();
        }
    }
}

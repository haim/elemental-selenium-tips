﻿using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Drawing.Imaging;

public class Screenshot
{
    IWebDriver Driver;

    [SetUp]
    public void SetUp()
    {
        Driver = new FirefoxDriver();
    }

    [TearDown]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
            TakeScreenshot();

        Driver.Quit();
    }

    private void TakeScreenshot()
    {
        string SaveLocation = @"C:\Temp\" +
                               "failshot_" +
                               TestContext.CurrentContext.Test.FullName +
                               ".png";
        ITakesScreenshot ScreenshotDriver = (ITakesScreenshot) Driver;
        ScreenshotDriver.GetScreenshot().SaveAsFile(SaveLocation, ImageFormat.Png);
    }

    [Test]
    public void ScreenShotOnFailure()
    {
        Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com");
        Assert.That(false.Equals(true));
    }
}
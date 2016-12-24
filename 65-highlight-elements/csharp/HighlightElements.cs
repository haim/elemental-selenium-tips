﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;

public class HighlightElements
{
    IWebDriver Driver;
    IJavaScriptExecutor JSDriver;

    [SetUp]
    public void SetUp()
    {
        Driver = new FirefoxDriver();
        JSDriver = (IJavaScriptExecutor) Driver;
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }

    private void HighlightElement(IWebElement Element, int Duration = 3)
    {
        string OriginalStyle = Element.GetAttribute("style");

        JSDriver.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])",
                               Element,
                               "style",
                               "border: 2px solid red; border-style: dashed;");

        Thread.Sleep(Duration * 1000);
        JSDriver.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])",
                               Element,
                               "style",
                               OriginalStyle);
    }

    [Test]
    public void HighlightElementExample()
    {
        Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/large");
        IWebElement TargetElement = Driver.FindElement(By.Id("sibling-2.3"));
        HighlightElement(TargetElement);
    }

}
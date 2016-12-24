﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Net;

public class FileDownloadRevisited
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
        Driver.Quit();
    }

    [Test]
    public void CheckFileDownloadWithoutBrowser()
    {
        Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/download");
        string FileURL = Driver.FindElement(By.CssSelector(".example a")).GetAttribute("href");
        var Request = (HttpWebRequest)WebRequest.Create(FileURL);
        Request.Method = "HEAD";
        WebResponse Response = Request.GetResponse();
        Assert.That(Response.ContentType.Equals("application/octet-stream"));
        Assert.Greater(Response.ContentLength, 0);
    }
}
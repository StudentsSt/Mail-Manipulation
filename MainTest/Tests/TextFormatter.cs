using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MainTest.PageObjects.TextFormatterObjects;
using MainTest.FrameWork.TestBase;
using MainTest.FrameWork.WaitExtenstions;
using MainTest.FrameWork.TestConf;


namespace MainTest.Tests.TextFormat
{
    public class TextFormatter : TestMailBase
    {

       

        [OneTimeSetUp]

        public void PagePath()

        {

            
            driver.Navigate().GoToUrl("http://www.themaninblue.com/experiment/widgEditor/");
        }
       


        [Test]
        public void TextFormatterManipulation()
        {
            TextForamtterObjects textFormatObject = new TextForamtterObjects(driver);
            IWebElement textformat;

            WaitExtensions.PageLoadWait(driver);
            if (TestConfig.Browser == "IE")
            {

                textFormatObject.textformatIE.Clear();
                WaitExtensions.PageLoadWait(driver);
                textFormatObject.textformatIE.SendKeys("some text ");
                WaitExtensions.PageLoadWait(driver);
                textFormatObject.submitButton.Click();
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
                textFormatObject.textformatIE.Clear();
             

            }
            else
            {
                driver.SwitchTo().Frame("noiseWidgIframe");

                textFormatObject.textformat.Click();
                WaitExtensions.PageLoadWait(driver); ;
                textFormatObject.textformat.Clear();
                WaitExtensions.PageLoadWait(driver);
                textFormatObject.textformat.SendKeys("some text ");
                WaitExtensions.PageLoadWait(driver);
                Assert.IsTrue(textFormatObject.textformat.Text.Contains("some text"));
                driver.SwitchTo().DefaultContent();
                textFormatObject.submitButton.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
                driver.SwitchTo().Frame("noiseWidgIframe");
                textFormatObject.textformat.Clear();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            }



        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainTest.PageObjects.HomePages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;
using MainTest.PageObject.MailObject;
using MainTest.FrameWork.TestBase;
using MainTest.FrameWork.TestConf;
using MainTest.FrameWork.WaitExtenstions;
using CreateLetter;
using System.Threading;

using MainTest.FrameWork.WebDriverBrowsers;

namespace MainTest.Tests
{
    class SofiTest : TestMailBase
    {
        public virtual void GoToUrl()
        {
            driver.Navigate().GoToUrl("http://www.i.ua/");
            
        }

        [OneTimeTearDown]

        [Test]
        public void IncorrectLogin()
        {
            HomePage homePage = new HomePage(driver);
            MailPageObjects malePageObjects = new MailPageObjects(driver);
            homePage.LoginInput.SendKeys("sofi_mag");
            homePage.PassInput.SendKeys("agena123");
            homePage.DomnList.Click();
            homePage.Button.Click();
            Assert.AreEqual("Паспорт - I.UA ", driver.Title);
        }
    }
}

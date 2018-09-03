using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MainTest.PageObjects.HomePages;
using MainTest.PageObject.MailObject;
using MainTest.FrameWork.TestBase;
using MainTest.FrameWork.TestConf;
using MainTest.FrameWork.WebDriverBrowsers;
using MainTest.FrameWork.WaitExtenstions;
using OpenQA.Selenium.Interactions;

namespace MainTest.Tests
{
    class CheckObjects : TestMailBase
    {

        



            [OneTimeSetUp]

        public void GotoPage()

        {

          
            driver.Navigate().GoToUrl("http://www.i.ua/");
            }

        [OneTimeTearDown]

        public void CloseSession()
        {
            driver.Quit();
        }



        [Test]

        public void LoginId()

        {
            MailPageObjects checkObject = new MailPageObjects(driver);
            
            Actions action = new Actions(driver);
       
            action.MoveToElement(checkObject.loginField).Build();
            action.MoveToElement(checkObject.findLogo).Build();
            action.MoveToElement(checkObject.mobile).Build();
            action.MoveToElement(checkObject.postChapter).Build();
            action.MoveToElement(checkObject.jobChapter).Build();
            action.MoveToElement(checkObject.catalogChapter).Build();
            action.MoveToElement(checkObject.linkChapter).Build();
            action.MoveToElement(checkObject.rssChapter).Build();
            action.MoveToElement(checkObject.boardChapter).Build();
            action.MoveToElement(checkObject.weatheChapter).Build();
            action.MoveToElement(checkObject.weatheWidget).Build();


        }

      
     

    }
}

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


namespace MainTest
{

        public class EmailTests: TestMailBase
    {

        public override void GoToUrl()
        {
            driver.Navigate().GoToUrl("http://www.i.ua/");
        }


        [OneTimeSetUp]
        public virtual void LogIn()
        {
            HomePage homePage = new HomePage(driver);
            homePage.Login();
            
            
        }

        [Test]
        public void D_MailManipulation()
        {
            
            MailPageObjects mailPage = new MailPageObjects(driver);
            if (TestConfig.Browser == "IE")
            {
                mailPage.postChapter.Click();
            }


            Assert.IsTrue(mailPage.mailadress.Displayed);
            WaitExtensions.WaitForElement(driver, mailPage.drafts);        
            Assert.IsTrue(mailPage.mail.Text.Contains("Невелика довідка про"));
            Actions action = new Actions(driver);
            action.MoveToElement(mailPage.mail).Build().Perform();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(p => mailPage.checkpopup.Enabled);
            Assert.IsTrue(mailPage.checkpopup.Text.Contains("Пропонуємо Вам ознайомитися"));    
            mailPage.ChoosePopup("Невелика довідка про");
            mailPage.acceptbutton.Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Dismiss();
            mailPage.CheckMail();
        }


        [OneTimeTearDown]
        public void NewWindow()
        {

            IWebElement secondTab = driver.FindElement(By.XPath("//a[@class='ho_logo']"));
            secondTab.SendKeys(Keys.Control + Keys.Return);
            var Windows = driver.WindowHandles;
            driver.SwitchTo().Window(Windows[1]);
            WaitExtensions.PageLoadWait(driver);
            driver.FindElement(By.XPath("/html/body/div[2]/div[3]/ul[1]/li[8]/a")).Click();
            string SecondWindow = driver.CurrentWindowHandle;
            driver.SwitchTo().Window(Windows[0]);
            WaitExtensions.PageLoadWait(driver);
            driver.Navigate().Refresh();
            IWebElement checklogout = driver.FindElement(
          By.CssSelector("body > div.body_container > div:nth-child(6) > div.Right > dl > dd:nth-child(10) > a"));
            Assert.IsTrue(checklogout.Displayed);
        }
    }
}



using System;
using System.Net.Mime;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace UnitTestProject1
{

    public class UnitTest1
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.i.ua/");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }


        [Test]
        public void ALogin()
        {

            IWebElement log =    driver.FindElement(By.XPath("//input[@name = 'login']"));
            log.SendKeys("nicolas.bobryuk@i.ua");
            log.GetAttribute("value");
            Thread.Sleep(2000);


            IWebElement pass = driver.FindElement(By.XPath("//input[@name = 'pass']"));
            pass.SendKeys("magnis12");
            pass.GetAttribute("value");

            Thread.Sleep(2000);

            IWebElement select = driver.FindElement(By.XPath("//select[@name = 'domn']"));
            var selectElement = new SelectElement(select);
            selectElement.SelectByValue("i.ua");
            Thread.Sleep(2000);


            IWebElement checkbox;
             checkbox = driver.FindElement(By.Id("c00"));

            if (!checkbox.Selected)
            {
                checkbox.Click();
            }


            driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[3]/div[2]/div[1]/div[3]/form/p/input")).Click();

                 
        }

        [Test]
        public void CheckMailAdress()
        {
            IWebElement mailadress =
                driver.FindElement(
                    By.XPath("//span [ contains(text(),'nicolas.bobryuk@i.ua') and @class='sn_menu_title']"));
            Assert.IsTrue(mailadress.Displayed);

        }

        [Test]
        public void CheckMails()
        {
          
            IWebElement mail =
                driver.FindElement(By.CssSelector("#mesgList > form > div:nth-child(20) > a > span.sbj > span"));
           
            mail.Text.Contains("Обережно шахраї!");


        }


        [Test]
        public void CheckPopup()
        {
            Actions action = new Actions(driver);
            IWebElement mails =
                driver.FindElement(By.CssSelector("#mesgList > form > div:nth-child(20) > a > span.sbj > span"));
            action.MoveToElement(mails).Build().Perform();

            driver.FindElement(By.ClassName("list_underlined"));
            mails.Text.Contains(" Шановний користувач.");



        }






    }
}

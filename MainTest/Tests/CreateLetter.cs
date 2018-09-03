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
using MainTest.PageObject.MailObject;
using MainTest.FrameWork.TestBase;
using MainTest.FrameWork.TestConf;
using MainTest.FrameWork.WaitExtenstions;
using MainTest.PageObjects.HomePages;
using OpenQA.Selenium.IE;
using MainTest.FrameWork.WebDriverBrowsers;
using System.IO;

namespace CreateLetter
{
   
    public class CreateL : TestMailBase
    {
       
        public override void GoToUrl()
        {

            driver.Navigate().GoToUrl("http://www.i.ua/");

         



            
        }

       

        [OneTimeSetUp]
        public void LogIn()
        {
            HomePage homePage = new HomePage(driver);
            homePage.Login();



        }

       
       

    [Test]

        public void A_CreateLetter()
        {
            MailPageObjects mailPageObject = new MailPageObjects(driver);
            if (TestConfig.Browser == "IE")
            {
                mailPageObject.postChapter.Click();
            }

            mailPageObject.createLetterButton.Click();
            mailPageObject.fieldMail.SendKeys(TestConfig.Mail);
            mailPageObject.fieldTheme.SendKeys(TestConfig.Theme);
            mailPageObject.fieldText.SendKeys("Some very usefull information");
            mailPageObject.insert.Click();

            WaitExtensions.PageLoadWait(driver); //Was thread sleep
            // mailPageObject.insertButton.Click();


            Thread.Sleep(5000);
            string file = "Program.cs";
            string filePath = @"E:\Mail Manipulation\File\" + file;
          
                //задаємо шлях до файлу
                driver.FindElement(By.XPath("//input[@type='file']")).SendKeys(filePath);


           Thread.Sleep(5000);
            //вставляємо його в інпут



            // WaitExtensions.PageLoadWait(driver); //Was thread sleep
            mailPageObject.saveLetter.Click();
        }
        [Test]
        public void B_CheckLetter()
        {
          
            MailPageObjects mailPageObject = new MailPageObjects(driver);
            WaitExtensions.WaitForElement(driver, mailPageObject.drafts);
            mailPageObject.drafts.Click();   
            mailPageObject.CheckMail(TestConfig.Mail, TestConfig.Theme);    
            mailPageObject.CheckMailText(TestConfig.Theme);

            ChromeOptions chromeOptions = new ChromeOptions();

            string File = "Program.cs";
            string FilePath = @"E:\Mail Manipulation\Save Result\" + File;
           
            

            driver.FindElement(By.LinkText("Program.cs")).Click();
            
            mailPageObject.DeleteLetter();

        }

        [OneTimeTearDown]
        public void DeleteDrafts()
        {
           


        

            System.IO.DirectoryInfo di = new DirectoryInfo(@"E:\Mail Manipulation\Save Result\");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }




        }



    }

}




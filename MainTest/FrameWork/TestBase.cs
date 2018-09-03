using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainTest.FrameWork.WebDriverBrowsers;
using MainTest.FrameWork.TestConf;
using MainTest.PageObjects.HomePages;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace MainTest.FrameWork.TestBase
{
    public class  TestMailBase

    {

      public IWebDriver driver;


        [OneTimeSetUp]

        public void GotoPage()

        {
            driver =  WebDriverBrowser.GetInstance(); 

            GoToUrl();

        }
        public virtual void GoToUrl()
        {

            
     
        }



        [TearDown]
        public  void BaseTearDown()

        {

            Console.WriteLine(TestContext.CurrentContext.Test.Name);
            string status = TestContext.CurrentContext.Result.Outcome.Status.ToString();
           
            if
            (status.Equals("Failed"))
            {
                TakesScreenshot();
            
            }
            foreach (var proc in Process.GetProcessesByName("IEDriverServer"))
            {
                proc.Kill();
            }
        }

        public virtual void TakesScreenshot()
        { 
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

            string title = TestContext.CurrentContext.Test.Name;
            string runname = title + DateTime.Now.ToString(" yyyy-MM-dd-HH_mm_ss");
            string filePath = @"E:\Mail Manipulation\Screenshots\";


            ss.SaveAsFile(filePath + runname + ".jpg", ScreenshotImageFormat.Jpeg);
        }
      
      


   

       

    [OneTimeTearDown]

        public virtual void baseCloseSession()
        {
            driver.Quit();
        }


    }
}

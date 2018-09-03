using System;
using System.Runtime.InteropServices;
using System.Threading;
using MainTest;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using MainTest.FrameWork.TestConf;

namespace MainTest.PageObjects.HomePages
{
    #region UnitTest

    public class HomePage
    {

        public IWebDriver driver;



        public HomePage(IWebDriver driver) => this.driver = driver;
        public IWebElement LoginInput => driver.FindElement(By.XPath("//input[@name = 'login']"));
        public IWebElement PassInput => driver.FindElement(By.XPath("//input[@name = 'pass']"));
        public IWebElement SelectInput => driver.FindElement(By.XPath("//select[@name = 'domn']"));
        public IWebElement Checkbox => driver.FindElement(By.Id("c00"));
        public IWebElement Button => driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[3]/div[2]/div[1]/div[3]/form/p/input"));

        //SofiTest
        public IWebElement DomnList => driver.FindElement(By.Id("//select[@name='domn']/option[@value='email.ua']"));
       

        public void ChoosePopup(string name)
        {
            IWebElement checkbox = driver.FindElement(By.XPath("//span[text()='" + name + "']/ancestor::div[@class='row']//input"));
            checkbox.Click();
        }
        public void Login()
        {

            LoginInput.SendKeys(TestConfig.Username);
            PassInput.SendKeys(TestConfig.Password);
            var selectElement = new SelectElement(SelectInput);
            selectElement.SelectByValue("i.ua");
            Checkbox.Click();
            Button.Click();
        }


    }
}





////    //IWebDriver driver;



////    //[OneTimeSetUp]

////    //public void GotoPage()

////    //{

////    //    driver = new ChromeDriver();
////    //    driver.Navigate().GoToUrl(");
////    //}

////    //[OneTimeTearDown]

////    //public void CloseSession()
////    //{
////    //    driver.Quit();
////    //}

////    //#endregion

////    //#region Charters


////    //[Test]

////    //public void LoginId()

////    //{

////    //    IWebElement loginfield = driver.FindElement(By.Name("login"));
////    //    Assert.IsTrue(loginfield.Displayed);

////    //}

////    //[Test]

////    //public void FindLogo()
////    //{

////    //    IWebElement findlogo = driver.FindElement(By.ClassName("umh_logo"));
////    //    Assert.IsTrue(findlogo.Displayed);

////    //}

////    //[Test]

////    //public void MobileVersion()
////    //{


////    //    IWebElement findlogo = driver.FindElement(By.Id("i_wap"));
////    //    Assert.IsTrue(findlogo.Displayed);

////    //}
////    //[Test]

////    //public void PostChapter()
////    //{


////    //    IWebElement postchapter = driver.FindElement(By.XPath("//a[text()= 'Пошта']"));
////    //     postchapter = driver.FindElement(By.CssSelector("a.mail_16"));
////    //    Assert.IsTrue(postchapter.Displayed);

////    //}
////    //[Test]
////    //public void JobChapter()
////    //{


////    //    IWebElement jobchapter = driver.FindElement(By.XPath("//a[@class= 'job_16']"));
////    //    jobchapter = driver.FindElement(By.CssSelector("a.job_16"));
////    //    Assert.IsTrue(jobchapter.Displayed);
////    //}
////    //[Test]
////    //public void CatalogChapter()
////    //{


////    //    IWebElement catalogchapter = driver.FindElement(By.XPath("//a[text() = 'Каталог'and @class= 'catalog_16']"));

////    //    catalogchapter = driver.FindElement(By.CssSelector("body > div.Branding_body.page_medium > div.Body.clear > div.Left > div.Left > div.block_gamma_gradient.site_sections > div.content.clear > ul > li:nth-child(3) > a"));

////    //    Assert.IsTrue(catalogchapter.Displayed);
////    //}

////    //[Test]
////    //public void LinkChapter()
////    //{


////    //    IWebElement linkchapter =   driver.FindElement(By.XPath("//a[/html/body/div[3]/div[3]/div[3]/div[2]/div[2]/div[3]/ul/li[4]]"));
////    //    linkchapter = driver.FindElement(By.CssSelector("ul.site_sections > li:nth-child(4) > a"));
////    //    Assert.IsTrue(linkchapter.Displayed);
////    //}


////    //[Test]
////    //public void RSSChapter()
////    //{


////    //    IWebElement rsschapter = driver.FindElement(By.XPath("//a[@title = 'RSS']"));
////    //    rsschapter = driver.FindElement(By.CssSelector(" div.content.clear > ul > li:nth-child(5) > a"));
////    //    Assert.IsTrue(rsschapter.Displayed);

////    //}
////    //[Test]

////    //public void BoardChapter()
////    //{


////    //    IWebElement boardchapter =    driver.FindElement(By.XPath("//a[@href='http://board.i.ua/']"));
////    //    boardchapter = driver.FindElement(By.CssSelector("a[href='http://board.i.ua/']"));
////    //    Assert.IsTrue(boardchapter.Displayed);

////    //}

////    //[Test]

////    //public void WeatherChapter()
////    //{


////    //    IWebElement weathechapter =  driver.FindElement(By.XPath("//a[@title='Погода']"));
////    //    weathechapter = driver.FindElement(By.CssSelector("a[title='Погода']"));
////    //    Assert.IsTrue(weathechapter.Displayed);

////    //}
////    //#endregion

////    //#region Widget

////    //[Test]
////    //public void WeatherWidget()
////    //{


////    //    IWebElement weathewidget =  driver.FindElement(By.XPath("//div[@class='block_gamma_gradient weather']"));
////    //    weathewidget = driver.FindElement(By.CssSelector("div.Right > div"));
////    //    Assert.IsTrue(weathewidget.Displayed);

////    //}
////    //#endregion

////    //#region Login          
////    //[Test]
////    //public void WLogin()
////    //{
////    //    driver.FindElement(By.XPath("//input[@name='login']")).SendKeys("nicolas.bobryuk@i.ua");
////    //    Thread.Sleep(3000);
////    //    driver.FindElement(By.XPath("//input[@name='pass']")).SendKeys("magnis12");
////    //    Thread.Sleep(3000);
////    //    driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[3]/div[2]/div[1]/div[3]/form/p/input")).Click();


////    //}
////    //[Test]
////    //public void  ZCheckTitle()
////    //{
////    //    IWebElement zCheckTitle = driver.FindElement(By.XPath("//span[@class='sbj']"));

////    //    Assert.IsTrue(zCheckTitle.Displayed);
////    //}





////}

//#endregion


//        #region Mail manipulation

////        public class Login
////    {


////        IWebDriver driver;


////        [OneTimeSetUp]

////        public void GotoPage()

////        {

////            driver = new ChromeDriver();
////            driver.Navigate().GoToUrl("http://www.i.ua/");

////        }

////        [OneTimeTearDown]

////        public void CloseSession()
////        {
////            driver.Quit();
////        }


////        [Test]
////        public void ALogin()
////        {



////            IWebElement log = driver.FindElement(By.XPath("//input[@name = 'login']"));
////            log.SendKeys("nicolas.bobryuk@i.ua");
////            string logtext = log.GetAttribute("value");


////            IWebElement pass = driver.FindElement(By.XPath("//input[@name = 'pass']"));
////            pass.SendKeys("magnis12");
////            string passtext = pass.GetAttribute("value");




////            IWebElement select = driver.FindElement(By.XPath("//select[@name = 'domn']"));
////            var selectElement = new SelectElement(select);
////            selectElement.SelectByValue("i.ua");





////            IWebElement checkbox;
////            checkbox = driver.FindElement(By.Id("c00"));

////            if (!checkbox.Selected)
////            {
////                checkbox.Click();
////            }

////            Assert.Multiple(() =>
////            {
////                Assert.IsTrue(log.Displayed);
////                Assert.IsTrue(pass.Displayed);

////            });
////            driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[3]/div[2]/div[1]/div[3]/form/p/input")).Click();
////        }



////        [Test]
////        public void CheckMailAdress()
////        {
////            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
////            IWebElement mailadress = driver.FindElement(
////                By.CssSelector("#mesgList > form > div:nth-child(20) > a > span.sbj > span"));
////            Assert.IsTrue(mailadress.Displayed);

////        }

////        [Test]
////        public void CheckMails()
////        {
////            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

////            IWebElement mail =
////                driver.FindElement(By.CssSelector("#mesgList > form > div:nth-child(20) > a > span.sbj > span"));

////            Assert.IsTrue(mail.Text.Contains("Невелика довідка про"));


////        }

////        [Test]
////        public void CheckPopup()
////        {
////            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
////            Actions action = new Actions(driver);
////            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


////            IWebElement mails =
////                driver.FindElement(By.CssSelector("#mesgList > form > div:nth-child(20) > a > span.sbj > span"));


////            action.MoveToElement(mails).Build().Perform();
////            wait.Until(p => driver.FindElement(By.CssSelector("#mesgList > form > div:nth-child(20) > a > span.sbj > span")).Displayed);
////            IWebElement checkpopup = driver.FindElement(By.XPath("//*[@id='prflpudvmbox_userInfoPopUp']/ul/li[2]"));

////            Assert.IsTrue(checkpopup.Text.Contains("Пропонуємо Вам ознайомитися"));


////        }

////        public void DeleteMail(string name)
////        {
////            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
////            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

////            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
////            IWebElement checkbox = driver.FindElement(By.XPath("//span[text()='" + name + "']/ancestor::div[@class='row']//input"));
////            checkbox.Click();

////            driver.FindElement(By.XPath("//*[@id='fieldset2']/fieldset[3]/span")).Click();



////            IAlert alert = driver.SwitchTo().Alert();
////            alert.Dismiss();

////            CheckMail();

////        }
////        public void CheckMail()
////        {
////            try
////            {

////                IWebElement element = driver.FindElement(By.XPath("//*[@id='mesgList']/form/div[1]/span/input"));

////            }
////            catch (OpenQA.Selenium.NoSuchElementException)
////            {


////            }

////        }

////        [Test]

////        public void Delete()
////        {
////            DeleteMail("Невелика довідка про можливості пошти");
////        }


//////        [Test]
//////        public void DNewWindow()
//////        {

//////            IWebElement secondTab = driver.FindElement(By.XPath("//a[@class='ho_logo']"));
//////            secondTab.SendKeys(Keys.Control + Keys.Return);
//////            var Windows = driver.WindowHandles;
//////            driver.SwitchTo().Window(Windows[1]);

//////            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);


//////            driver.FindElement(By.XPath("/html/body/div[2]/div[3]/ul[1]/li[8]/a")).Click();
//////            string SecondWindow = driver.CurrentWindowHandle;
//////            driver.SwitchTo().Window(Windows[0]);

//////            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

//////            driver.Navigate().Refresh();
//////            IWebElement checklogout = driver.FindElement(
//////          By.CssSelector("body > div.body_container > div:nth-child(6) > div.Right > dl > dd:nth-child(10) > a"));
//////            Assert.IsTrue(checklogout.Displayed);
//////        }

////    }
////}

//#endregion

//#region Translator

//#endregion

////public class TextFormatter
//{
//    IWebDriver driver;

//    [OneTimeSetUp]

//    public void PagePath()

//    {

//        driver = new ChromeDriver();
//        driver.Navigate().GoToUrl("http://www.themaninblue.com/experiment/widgEditor/");
//    }
//    [OneTimeTearDown]

//    public void CloseSession()
//    {
//        driver.Quit();
//    }


//    [Test]
//    public void TextManipulation()
//    {
//        IWebElement textformat;
//        driver.SwitchTo().Frame("noiseWidgIframe");


//        textformat = driver.FindElement(By.CssSelector("body"));

//        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
//        driver.FindElement(By.CssSelector("body")).Clear();

//        textformat.SendKeys("some text ");
//        Assert.IsTrue(textformat.Text.Equals("some text "));


//        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

//        driver.SwitchTo().DefaultContent();
//        driver.FindElement(By.CssSelector("#content > form > fieldset.submit > input[type='submit']")).Click();

//        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

//        IAlert alert = driver.SwitchTo().Alert();
//        alert.Accept();


//        driver.SwitchTo().Frame("noiseWidgIframe");
//        driver.FindElement(By.CssSelector("body")).Clear();

//        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);




//    }

//}





#endregion
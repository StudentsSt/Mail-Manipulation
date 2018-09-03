using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainTest.FrameWork.WaitExtenstions;
using MainTest.FrameWork.TestConf;
namespace MainTest.PageObject.MailObject
{
    class MailPageObjects
    {

        IWebDriver driver;
        public MailPageObjects(IWebDriver driver) => this.driver = driver;

        // Objects for Check Object
        public IWebElement loginField => driver.FindElement(By.Name("login"));
        public IWebElement findLogo => driver.FindElement(By.ClassName("umh_logo"));
        public IWebElement mobile => driver.FindElement(By.Id("i_wap"));
        public IWebElement postChapter => driver.FindElement(By.XPath("//a[text()= 'Пошта']"));
        public IWebElement jobChapter => driver.FindElement(By.XPath("//a[@class= 'job_16']"));
        public IWebElement catalogChapter => driver.FindElement(By.XPath("//a[text() = 'Каталог'and @class= 'catalog_16']"));
        public IWebElement linkChapter => driver.FindElement(By.XPath("//a[/html/body/div[3]/div[3]/div[3]/div[2]/div[2]/div[3]/ul/li[4]]"));
        public IWebElement rssChapter => driver.FindElement(By.XPath("//a[@title = 'RSS']"));
        public IWebElement boardChapter => driver.FindElement(By.XPath("//a[@href='http://board.i.ua/']"));
        public IWebElement weatheChapter => driver.FindElement(By.XPath("//a[@title='Погода']"));
        public IWebElement weatheWidget => driver.FindElement(By.XPath("//div[@class='block_gamma_gradient weather']"));

        // Objects for  B_CreateLetter()

        // public IWebElement mailadress => driver.FindElement(By.CssSelector("#mesgList > form > div:nth-child(20) > a > span.sbj > span"));


        public IWebElement mailadress => driver.FindElement(By.XPath("//span[text() = 'nicolas.bobryuk@i.ua' and @class='sn_menu_title']"));
        public IWebElement mail => driver.FindElement(By.XPath("//span[text()='Невелика довідка про']"));
        public IWebElement maillists => driver.FindElement(By.CssSelector("#mesgList > form > div:nth-child(20) > a > span.sbj > span"));
        public IWebElement checkpopup => driver.FindElement(By.XPath("//*[@id='prflpudvmbox_userInfoPopUp']/ul/li[2]"));
        public IWebElement acceptbutton => driver.FindElement(By.XPath("//*[@id='fieldset2']/fieldset[3]/span"));
        // Objects for  C_CheckLetter()
        public IWebElement createLetterButton => driver.FindElement(By.XPath("/html/body/div[1]/div[4]/ul/li[2]/a"));
        public IWebElement fieldMail => driver.FindElement(By.Id("to"));
        public IWebElement fieldTheme => driver.FindElement(By.XPath("/html/body/div[4]/div[5]/div[1]/div[1]/div[1]/div/form/div[5]/div[2]/span/input[1]"));
        public IWebElement fieldText => driver.FindElement(By.Id("text"));
        public IWebElement saveLetter => driver.FindElement(By.CssSelector("body > div.body_container > div.Body > div.Cols_80_20.message_container > div.Left > p:nth-child(1) > input[type='submit']:nth-child(2)"));
        public IWebElement drafts => driver.FindElement(By.XPath("//a[contains(text(),'Чернетки')]"));

        public IWebElement insert => driver.FindElement(By.XPath("//*[@id='att']/div[2]/span[1]"));
        public IWebElement insertButton => driver.FindElement(By.XPath("//*[@id='cnrinpFromFileGroupuform']/fieldset[1]/div/input"));
        // Objects for  D_DeleteLetter()
        public IWebElement letterslist => driver.FindElement(By.XPath("//a[text()='Листи']"));
        public IList <IWebElement> Letterslists => driver.FindElements(By.XPath("//span[text()='Test: Дуже важливо бути чемним']"));

        // public IWebElement draftForDelete => driver.FindElement(By.XPath("//a[text.contains()='Чернетки']"));
        public IWebElement deleteButton => driver.FindElement(By.XPath("//span[text()='Видалити']"));


        // Objects for  DNewWindow()
        public IWebElement secondTab => driver.FindElement(By.XPath("//a[@class='ho_logo']"));
        public IWebElement butonExit => driver.FindElement(By.XPath("/html/body/div[2]/div[3]/ul[1]/li[8]/a"));
        public IWebElement checklogout => driver.FindElement(By.CssSelector("body > div.body_container > div:nth-child(6) > div.Right > dl > dd:nth-child(10) > a"));







        public void ChoosePopup(string name)
        {
            IWebElement checkbox = driver.FindElement(By.XPath("//span[text()='" + name + "']/ancestor::div[@class='row']//input"));
            checkbox.Click();
            //*[@id="mesgList"]/form/div[1]/span/input
        }
        //*[@id="mesgList"]/form/div[1]/span/input
        public void CheckMail(string mail, string title)
        {
            IWebElement mailAdress = driver.FindElement(By.XPath("//div[@id='mesgList']//span[text()='" + mail + "']"));
            mailAdress.GetAttribute("value");
            Assert.IsTrue(mailAdress.Text.Equals("nicolas.bobryuk@i.ua"));


            IWebElement mailTitle = driver.FindElement(By.XPath("//div[@id='mesgList']//span[text()='" + title + "']"));
            mailTitle.GetAttribute("value");
            Assert.IsTrue(mailTitle.Text.Equals("Test: Дуже важливо бути чемним"));
        }

        public void CheckMailText(string title)
        {

            driver.FindElement(By.XPath("//div[@id='mesgList']//span[text()='" + title + "']")).Click();


            IWebElement text = driver.FindElement(By.Id("text"));
            Assert.IsTrue(text.Text.Equals("Some very usefull information"));

        }

        public void CheckMail()
        {
            try
            {

                IWebElement element = driver.FindElement(By.XPath("//*[@id='mesgList']/form/div[1]/span/input"));

            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {


            }
        }
        public void DeleteLetter()
        {


            WaitExtensions.WaitForElement(driver, letterslist);
            letterslist.Click();
            drafts.Click();
            while (Letterslists.Count > 0)
            {
                WaitExtensions.WaitForElement(driver, mailadress);
                ChoosePopup(TestConfig.Theme);
                deleteButton.Click();
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
        }

    }
}
        

    


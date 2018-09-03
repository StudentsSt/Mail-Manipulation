using System;
using System.Runtime.InteropServices;
using System.Threading;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using MainTest.PageObjects.TranslatorObjects;
using MainTest.FrameWork.TestBase;
namespace Translator
{
    public class Translate : TestMailBase
    {
       


        [OneTimeSetUp]
        public void path()

        {

            driver.Navigate().GoToUrl("https://perevod.i.ua/");
        }

        [OneTimeTearDown]

        public void CloseSession()
        {
            driver.Quit();
        }


      


        [TearDown]
        public void Clear()
        {
            driver.FindElement(By.Id("first_textarea")).Clear();

        }

        [TestCase("Английский", "Украинский", "dog", "собака")]
        [TestCase("Латышский", "Украинский", "suns",  "собака")]
        [TestCase("Французский", "Украинский", "un chien", "собака")]
        public void TranslateText(string firstlang, string seclang, string word, string translatedWord)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            TranslatorObject translateObject = new TranslatorObject(driver);
            //Actions action = new Actions(driver);

            translateObject.selectFirstlang.Click();
            Thread.Sleep(1000);
            translateObject.SelectFirstLan(firstlang);
            Thread.Sleep(1000);
            wait.Until(p => translateObject.firstLangPopup.Displayed);
      
           // translateObject.FirstLan(firstlang);
          
            translateObject.selectSeclang.Click();
            Thread.Sleep(1000);
            wait.Until(p => translateObject.secondLangPopup.Displayed);
            Thread.Sleep(1000);
            translateObject.SecondLan(seclang);
            Thread.Sleep(1000);
            translateObject.SendWord(word);
            Thread.Sleep(1000);
            translateObject.TranslateButton.Click();
            translateObject.GetWord(translatedWord);
            
        }






        //     selectFirstlang = driver.FindElement(By.Id("first_lang_selector"));
        //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //selectFirstlang.Click();

        //wait.Until(p => driver.FindElement(By.Id("popup_language_menu_1")).Displayed);
        //driver.FindElement(By.XPath("//div[@id ='popup_language_menu_1']//a[text()='" + firstlang + "']")).Click();


        //IWebElement selectSeclang = driver.FindElement(By.Id("second_lang_selector"));
        //selectSeclang.Click();
        //wait.Until(p => driver.FindElement(By.Id("popup_language_menu_2")).Displayed);
        //driver.FindElement(By.XPath("//div[@id ='popup_language_menu_2']//a[text()='" + seclang + "']")).Click();

        //IWebElement firstTab = driver.FindElement(By.Id("first_textarea"));
        //firstTab.SendKeys(word);



        //driver.FindElement(By.CssSelector("#new_translate > div:nth-child(4) > div:nth-child(1) > div.form_item.form_item-submit > input")).Click();

        //IWebElement result = driver.FindElement(By.Id("second_textarea"));
        //result.GetAttribute("value");
        //Assert.IsTrue(result.Text.Equals("собака"));

    }
    } 

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
using MainTest.FrameWork.WaitExtenstions;

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

           WaitExtensions.PageLoadWait(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            TranslatorObject translateObject = new TranslatorObject(driver);
            Actions action = new Actions(driver);
            translateObject.selectFirstlang.Click();
            Thread.Sleep(1000);
            wait.Until(p => translateObject.firstLangPopup.Enabled);
            translateObject.SelectFirstLan(firstlang);    
            translateObject.selectSeclang.Click();
            wait.Until(p => translateObject.secondLangPopup.Enabled);
            translateObject.SecondLan(seclang);
            translateObject.SendWord(word);
            translateObject.TranslateButton.Click();
            translateObject.GetWord(translatedWord);
            
        }

    }
    } 

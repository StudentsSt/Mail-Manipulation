using System;
using System.Runtime.InteropServices;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using MainTest.FrameWork.WaitExtenstions;

namespace MainTest.PageObjects.TranslatorObjects
{
    public class TranslatorObject
    {
        public IWebDriver driver;
        public TranslatorObject(IWebDriver driver) => this.driver = driver;
        //language dropdown
        public IWebElement selectFirstlang => driver.FindElement(By.Id("first_lang_selector"));
        public IWebElement firstLangPopup => driver.FindElement(By.XPath("//div[@id ='popup_language_menu_1']"));
        public IWebElement selectSeclang => driver.FindElement(By.Id("second_lang_selector"));
        public IWebElement secondLangPopup => driver.FindElement(By.XPath("//div[@id ='popup_language_menu_2']"));

        //button translate
        public IWebElement TranslateButton => driver.FindElement(By.CssSelector("#new_translate > div:nth-child(4) > div:nth-child(1) > div.form_item.form_item-submit > input"));


        //Choose first language
        public void SelectFirstLan(string firstlang) 
        {
            IWebElement clickFirstLang = driver.FindElement(By.XPath("//div[@id ='popup_language_menu_1']//a[text()='" + firstlang + "']"));
            clickFirstLang.Click();
            Actions action = new Actions(driver);

            selectFirstlang.Click();


        
           // WaitForElement(firstLangPopup.Displayed);

        }

        //Choose second language
        public void SecondLan(string seclang)
        {
            IWebElement clickSecLang = driver.FindElement(By.XPath("//div[@id ='popup_language_menu_2']//a[text()='" + seclang + "']"));
            clickSecLang.Click();
        }
        //Word for translation
        public void SendWord(string word)
        {
            IWebElement firstTab = driver.FindElement(By.Id("first_textarea"));
            firstTab.SendKeys(word);

        }
        //Translation result
        public void GetWord(string translatedWord)
        {
             IWebElement secondTab = driver.FindElement(By.Id("second_textarea"));
            secondTab.GetAttribute("value");
    }
        

    }
}
    
  

    

 
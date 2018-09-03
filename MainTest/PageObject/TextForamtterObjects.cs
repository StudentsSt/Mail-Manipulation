using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainTest.PageObjects.TextFormatterObjects
{
   public class TextForamtterObjects
    {
    

   public IWebDriver driver;
   public TextForamtterObjects(IWebDriver driver) => this.driver = driver;
   public IWebElement textformat => driver.FindElement(By.CssSelector("body"));
   public IWebElement submitButton =>   driver.FindElement(By.CssSelector("#content > form > fieldset.submit > input[type='submit']"));
        //Elements for IE

  public IWebElement textformatIE => driver.FindElement(By.Id("noise"));




    }
    }


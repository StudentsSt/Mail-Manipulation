using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainTest.FrameWork.WaitExtenstions
{
  public static  class WaitExtensions
    {
       

        public static void WaitForElement(this IWebDriver driver, IWebElement element, double timeSpan= 300)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpan));
            wait.Until(p => element.Displayed);
        }
         public static void PageLoadWait(this IWebDriver driver)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300.00));
            wait.Until(p => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }



    }
}

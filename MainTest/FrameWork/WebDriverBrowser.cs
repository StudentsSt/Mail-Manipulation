using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainTest.FrameWork.TestConf;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using MainTest.FrameWork.TestBase;

namespace MainTest.FrameWork.WebDriverBrowsers
{
    class WebDriverBrowser 
    {
        private const string chrome = "CH";
        private const string fireFox = "FF";
        private const string internetExplorer = "IE";
        private const string edge = "EG";
        private static IWebDriver driver = null;

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {

                TestConfig configs = TestConfig.GetInstance();

            if(TestConfig.Browser == chrome)
                {
                    var chromeOptions = new ChromeOptions();

                    chromeOptions.AddUserProfilePreference("download.default_directory", @"E:\Mail Manipulation\Save Result\");
                    chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            
                    return new ChromeDriver(chromeOptions);
         

                }

                else if (TestConfig.Browser == fireFox)
                {


                    FirefoxOptions profile = new FirefoxOptions();

                    profile.SetPreference("browser.download.folderList", 2); //Use for the default download directory the last folder specified for a download
                    profile.SetPreference("browser.download.dir", @"E:\Mail Manipulation\Save Result\"); //Set the last directory used for saving a file from the "What should (browser) do with this file?" dialog.
                    profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "text/cs"); //list of MIME types to save to disk without asking what to use to open the file
                    profile.SetPreference("csjs.disabled", true);  // disable the built-in PDF viewer



                    //profile.SetPreference("browser.download.dir", @"E:\Mail Manipulation\Save Result\");


                    //profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application / cs");



                    return new FirefoxDriver(profile);

                }

            else if (TestConfig.Browser == internetExplorer)
                {
                    return new InternetExplorerDriver();

                 


                }
                else if (TestConfig.Browser == edge)
                {
                    return new EdgeDriver();


                }
                else
                {
                    throw new Exception("Invalid browser in settigns");
                }


            }

            return driver;

        }
    }
}

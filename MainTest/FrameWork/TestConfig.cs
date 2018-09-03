using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MainTest.FrameWork.WebDriverBrowsers;


namespace MainTest.FrameWork.TestConf
{
    public class TestConfig
    {
        public static string Browser;
        public static string Username;
        public static string Password;
        public static string Mail;
        public static string Theme;

        public static string Environment;
       

        public static  TestConfig configs;

        // Get Config File Path
        public static string GetConfigFilePath()
        {
            string executingAssembly = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = new DirectoryInfo(executingAssembly).Parent.Parent.Parent.FullName;
            return Path.Combine(path, "Config.xml");
         
        }
        // Read Config File
        public static void GetConfigs()
        {
            XmlDocument config = new XmlDocument();
            config.Load("E:\\Mail Manipulation\\MainTest\\Config.xml");        
            Browser = config.DocumentElement.SelectSingleNode("browser").InnerText;
            Username = config.DocumentElement.SelectSingleNode("username").InnerText;
            Password = config.DocumentElement.SelectSingleNode("password").InnerText;
            Mail = config.DocumentElement.SelectSingleNode("mail").InnerText;
            Theme = config.DocumentElement.SelectSingleNode("theme").InnerText;
            Environment = config.DocumentElement.SelectSingleNode("environment").InnerText;


        }

        //Get config instance
        public static TestConfig GetInstance()
        {
        if(configs == null)
            {
                GetConfigFilePath();
                GetConfigs();

            }
            return configs;
        }
    }
}

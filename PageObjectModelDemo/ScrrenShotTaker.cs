using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModelDemo
{
    public class ScrrenShotTaker
    {
        public static string Capture(ChromeDriver cd, string screenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)cd;
            Screenshot screenshot = ts.GetScreenshot();
            //string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            //string uptobinpath = path.Substring(0, path.LastIndexOf("packages")) + "Screenshots\\" + screenshotName + ".png";
            string folderpath = @"C:\Users\HP\source\repos\PageObjectModelDemo\Screenshots\\"+ screenshotName+".png";
            string localPath = new Uri(folderpath).LocalPath;
            screenshot.SaveAsFile(localPath, ScreenshotImageFormat.Png);
            return localPath;
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;

namespace PageObjectModelDemo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBox()
        {
            ChromeDriver cd = new ChromeDriver();
            //one browser window gets opened

            cd.Navigate().GoToUrl("https://demoqa.com/text-box");
            Elements elements = new Elements();
            elements.SetName(cd);
            elements.SetEmail(cd);
            elements.SetCurrentAddress(cd);
            elements.SetPermanentAddress(cd);
            elements.SetSubmitButton(cd);

        }

        [TestMethod]
        public void Buttons()
        {
            ChromeDriver cd = new ChromeDriver();
            //one browser window gets opened

            cd.Navigate().GoToUrl("https://demoqa.com/buttons");
            Elements elements = new Elements();
            elements.SetDoubleClickButton(cd);
            elements.SetRightClickButton(cd);
            elements.SetDynamicClickButton(cd);
        }

        [TestCleanup]
        public void GenerateReport()
        {
            Elements elements = new Elements();
            elements.quit();
        }
    }
}

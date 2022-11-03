using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModelDemo
{
    class Elements
    {
        ExtentReports rep = ExtentManager.getInstance();
        ExtentTest test;
        By name = By.Id("userName");
        By email = By.Id("userEmail");
        By currentAddress = By.Id("currentAddress");
        By permanentAddress = By.Id("permanentAddress");
        By submitButton = By.Id("submit");
        By doubleClickButton = By.Id("doubleClickBtn");
        By rightClickButton = By.Id("rightClickBtn");
        By dynamicClickButton = By.CssSelector("a#getPdfBtn.win8button.textless");

        public void SetName(ChromeDriver cd)
        {
            cd.FindElement(name).SendKeys("Squiddy Luna");
        }
        public void SetEmail(ChromeDriver cd)
        {
            cd.FindElement(email).SendKeys("rimapanja@gmail.com");
        }
        public void SetCurrentAddress(ChromeDriver cd)
        {
            cd.FindElement(currentAddress).SendKeys("Kolkata");
        }
        public void SetPermanentAddress(ChromeDriver cd)
        {
            cd.FindElement(permanentAddress).SendKeys("Kolkata");
        }
        public void SetSubmitButton(ChromeDriver cd)
        {
            IWebElement ele = cd.FindElement(submitButton);
            IJavaScriptExecutor js = (IJavaScriptExecutor)cd;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", ele); //move or scroll into view the required button
            ele.Click();
        }

        public void SetDoubleClickButton(ChromeDriver cd)
        {
            test = rep.CreateTest("Double Click Button Test");
            try
            {
                
                IWebElement doubleClick = cd.FindElement(doubleClickButton);
                Actions doubleClickaction = new Actions(cd);
                doubleClickaction.DoubleClick(doubleClick).Perform();
                string screenshotPath = ScrrenShotTaker.Capture(cd, "PassDoubleClicked");
                Console.WriteLine(cd.FindElementById("doubleClickMessage").Text);
                test.Log(Status.Pass, "Double Click Test Passed");
                test.AddScreenCaptureFromPath(screenshotPath);
            }
            catch(Exception e)
            {
                Console.WriteLine("Unsuccessful");
                test.Log(Status.Fail, "Test Failed");
            }
            //rep.Flush();
            
        }
        public void SetRightClickButton(ChromeDriver cd)
        {
            test = rep.CreateTest("Right Click Button Test");
            try
            {
                IWebElement rightClick = cd.FindElement(rightClickButton);
                Actions rightClickaction = new Actions(cd);
                rightClickaction.ContextClick(rightClick).Perform();
                test.Log(Status.Pass, "Right Click Test Passed");
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, "Test Failed");
            }
        }
        public void SetDynamicClickButton(ChromeDriver cd)
        {
            IWebElement dynamicClick = cd.FindElement(dynamicClickButton);
            Actions dynamicClickAction = new Actions(cd);
            dynamicClickAction.Click(dynamicClick).Perform();
        }

        public void quit()
        {
            rep.Flush();
        }
    }
}

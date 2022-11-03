using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModelDemo
{
    public class ExtentManager
    {
        public static ExtentHtmlReporter htmlReporter;
        private static ExtentReports extent;

        

        public static ExtentReports getInstance()
        {
            if(extent == null)
            {
                string reportpath = @"C:\Users\HP\source\repos\PageObjectModelDemo\Reports\Report.html";
                //string reportfile = DateTime.Now.ToString();
                htmlReporter = new ExtentHtmlReporter(reportpath);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                extent.AddSystemInfo("Operating System : ", Environment.OSVersion.ToString());
                extent.AddSystemInfo("Host Name : ", Dns.GetHostName());
                extent.AddSystemInfo("Browser : ", "Chrome");
                
            }
            return extent;
        }
    }
}

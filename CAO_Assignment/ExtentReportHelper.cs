using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CAO_Assignment
{
   public class ExtentReportHelper
    {
        public ExtentReports extent;

        public ExtentReports getReportInstance()
        {
            string projectDir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            extent = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(projectDir + @"\Report" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlreporter);
            return extent;
        }
    }
}

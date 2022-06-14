using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace CAO_Assignment
{
    public class Helpers
    {
        ExtentTest test;
        IWebDriver driver;
        public Helpers(IWebDriver driver, ExtentTest test)
        {
            this.driver = driver;
            this.test = test;
        }

        public void buttonClick(By locator)
        {
            try
            {
                WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                w.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
                driver.FindElement(locator).Click();
                Thread.Sleep(1000);
            }
            catch(Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }
            
        }
        public string getText(By locator)
        {
            string text=null;
            try
            {
                WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                w.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
                text= driver.FindElement(locator).Text;
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }
            return text;

        }
       
        public bool isElementDisplayed(By locator)
        {
            bool status=false;
            try
            {

                status= driver.FindElement(locator).Displayed ;
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }
            return status;
        }
        public void JavaScriptClick(By locator)
        {
            try
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].click();", driver.FindElement(locator));
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }
            
        }

        public void enterTextInTextbox(By locator, string entertext)
        {
            try
            {
                WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                w.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
                driver.FindElement(locator).SendKeys(entertext);
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }
           
        }

        public void JavaScriptExecutor_Entertext(By locator, String textvalue)
        {

            try
            {
                IWebElement element = driver.FindElement(locator);

                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                jse.ExecuteScript("arguments[0].value='" + textvalue + "';", element);
                // test.log(LogStatus.INFO, "Enter :" + textvalue + " in textbox");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }
        }

        public void UploadFile(string autoItPath, string filePath)
        {
            try
            {
                var processinfo = new ProcessStartInfo()
                {
                    FileName = @"C:\Users\Admin\Downloads\File+Upload\FileUpload.exe",
                    Arguments = @"C:\Users\Admin\Downloads\File+Upload\documentation-of-automation-projects.pdf"
                };
                using (var process = Process.Start(processinfo))
                {
                    process.WaitForExit();
                }
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }
           
        }
    }
}

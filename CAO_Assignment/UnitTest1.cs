using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace CAO_Assignment
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }
        IWebDriver driver;
        Helpers helpers;
        public static ExtentTest test;
       static  ExtentReports  extent;
      static  TestContext tc;
        [ClassInitialize]
        public static void Initialize(TestContext context1)
        {
            extent = null;
            ExtentReportHelper extent1 = new ExtentReportHelper();
            extent = extent1.getReportInstance();
            tc = context1;
        }

        //[ClassInitialize]
        //public  void classintializer(TestContext context)
        //{
        //    ExtentReportHelper extent1 = new ExtentReportHelper();
        //    extent = extent1.getReportInstance();
        //    test = extent.CreateTest("OrderRequest").Info("Order Request");
        //    driver = new ChromeDriver();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
        //    driver.Manage().Window.Maximize();
        //    driver.Navigate().GoToUrl("https://docs.google.com/forms/d/11VwHLRVZPorB9VBiOqHn_KGnnf47ohXMxWh9dCJu6F4/viewform?edit_requested=true");
        //    helpers = new Helpers(driver);
        //}
        [TestInitialize]
        public  void beforemethod()
        {
            test = null;
            Console.WriteLine(TestContext.TestName);
            test = extent.CreateTest(TestContext.TestName);
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://docs.google.com/forms/d/11VwHLRVZPorB9VBiOqHn_KGnnf47ohXMxWh9dCJu6F4/viewform?edit_requested=true");
            helpers = new Helpers(driver,test);
        }
        [TestMethod]
        public void OrderRequest()
        {
            helpers.enterTextInTextbox(By.XPath("//input[@type='email']"), "testcan459@gmail.com");
            helpers.buttonClick(By.XPath("//button/descendant::span[contains(text(),'Next')]"));
            Thread.Sleep(2000);
            helpers.enterTextInTextbox(By.XPath("//input[@type='password']"), "Pass123!");
            helpers.buttonClick(By.Id("passwordNext"));
            helpers.buttonClick(By.XPath("//div[@role='button']/descendant::span[ contains(text(),'Clear form')]"));
            helpers.buttonClick(By.XPath("(//div[@role='button']/descendant::span[ contains(text(),'Cancel')]/parent::span/parent::div)[2]/following-sibling::div"));

            helpers.buttonClick(By.XPath("(//div[@role='list']/div[@role='listitem']/descendant::span[contains(text(),'What is the item you would like to order?')]/parent::div/parent::div/parent::div/following-sibling::div[1]/descendant::div[@role='listitem'])[1]"));
            helpers.buttonClick(By.XPath("(//div[@role='list']/div[@role='listitem']/descendant::span[contains(text(),'What is the item you would like to order?')]/parent::div/parent::div/parent::div/following-sibling::div[1]/descendant::div[@role='listitem'])[2]"));
            helpers.buttonClick(By.XPath("(//div[@role='list']/div[@role='listitem']/descendant::span[contains(text(),'What is the item you would like to order?')]/parent::div/parent::div/parent::div/following-sibling::div[1]/descendant::div[@role='listitem'])[3]"));


            helpers.enterTextInTextbox(By.XPath("//span[contains(text(),'Which color would you like?')]/parent::div/parent::div/parent::div/following-sibling::div[1]/descendant::input"), "Blue");
            helpers.buttonClick(By.XPath("//span[contains(text(),'Were you able to find everything you are looking for?')]/parent::div/parent::div/parent::div/following-sibling::div[1]/descendant::label"));

            helpers.enterTextInTextbox(By.XPath("//span[contains(text(),'Name')]/parent::div/parent::div/parent::div/following-sibling::div[1]/descendant::input"), "name1");
            helpers.buttonClick(By.XPath("//span[contains(text(),'Add file')]"));
            Thread.Sleep(5000);
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//div/iframe")));
            Thread.Sleep(1000);
            ReadOnlyCollection<IWebElement> list = driver.FindElements(By.XPath("//*[@id=':f.select-files-button']/div"));
            foreach (var VARIABLE in list)
            {
                VARIABLE.Click();
            }

            Thread.Sleep(2000);
            helpers.UploadFile(@"C:\Users\Admin\Downloads\File+Upload\FileUpload.exe", @"C:\Users\Admin\Downloads\File+Upload\documentation-of-automation-projects.pdf");
         
            helpers.buttonClick(By.XPath("//div[@role='button' and contains(text(),'Upload')]"));
            driver.SwitchTo().DefaultContent();
            helpers.enterTextInTextbox(By.XPath("//span[contains(text(),'What is your favorite day of the year?')]/parent::div/parent::div/parent::div/following-sibling::div[1]/descendant::input"), "12122022");
            helpers.buttonClick(By.XPath("//span[contains(text(),'Preferred method of Notifications?')]/parent::div/parent::div/parent::div/following-sibling::div/descendant::div[@data-value='Phone']"));
            helpers.enterTextInTextbox(By.XPath("//span[contains(text(),'E-mail for Updates')]/parent::div/parent::div/parent::div/following-sibling::div/descendant::input"), "test@gmail.com");
            helpers.buttonClick(By.XPath("//div[@role='button']/descendant::span[contains(text(),'Next')]"));
            Thread.Sleep(3000);
            helpers.enterTextInTextbox(By.XPath("//div[text()='Your answer']/preceding-sibling::input"), "2266126050");
            helpers.buttonClick(By.XPath("(//span[contains(text(),'Can we send SMS notifications?')]/parent::div/parent::div/parent::div//following-sibling::div)[2]/descendant::label[2]"));
            helpers.buttonClick(By.XPath("//span[text()='Submit']"));
            Thread.Sleep(3000);
            if(helpers.isElementDisplayed(By.XPath("//span[text()='View score']")) ==true)
            {
                test.Log(Status.Pass,"Able to submit form");
            }
            else
            {
                test.Log(Status.Fail, "Unable to submit form");
            }
       

        }
        [TestMethod]
        public void OrderRequest_Negative()
        {
            helpers.enterTextInTextbox(By.XPath("//input[@type='email']"), "testcan459@gmail.com");
            helpers.buttonClick(By.XPath("//button/descendant::span[contains(text(),'Next')]"));
            Thread.Sleep(2000);
            helpers.enterTextInTextbox(By.XPath("//input[@type='password']"), "Pass123!");
            helpers.buttonClick(By.Id("passwordNext"));
            helpers.buttonClick(By.XPath("//div[@role='button']/descendant::span[ contains(text(),'Clear form')]"));
            helpers.buttonClick(By.XPath("(//div[@role='button']/descendant::span[ contains(text(),'Cancel')]/parent::span/parent::div)[2]/following-sibling::div"));

            helpers.buttonClick(By.XPath("(//div[@role='list']/div[@role='listitem']/descendant::span[contains(text(),'What is the item you would like to order?')]/parent::div/parent::div/parent::div/following-sibling::div[1]/descendant::div[@role='listitem'])[1]"));
            helpers.buttonClick(By.XPath("(//div[@role='list']/div[@role='listitem']/descendant::span[contains(text(),'What is the item you would like to order?')]/parent::div/parent::div/parent::div/following-sibling::div[1]/descendant::div[@role='listitem'])[2]"));
            helpers.buttonClick(By.XPath("(//div[@role='list']/div[@role='listitem']/descendant::span[contains(text(),'What is the item you would like to order?')]/parent::div/parent::div/parent::div/following-sibling::div[1]/descendant::div[@role='listitem'])[3]"));
            helpers.enterTextInTextbox(By.XPath("//span[contains(text(),'Name')]/parent::div/parent::div/parent::div/following-sibling::div[1]/descendant::input"), "name1");
            helpers.buttonClick(By.XPath("//div[@role='button']/descendant::span[contains(text(),'Next')]"));
            Thread.Sleep(3000);
            if (helpers.isElementDisplayed(By.XPath("//div[@role='alert']/descendant::span[text()='This is a required question']")) == true)
            {
                test.Log(Status.Pass, "Alert message is displayed, when fields are empty");
            }
            else
            {
                test.Log(Status.Fail, "Alert message is displayed, when fields are empty");
            }
        }
        [TestCleanup]
        public void aftermethod()
        {
            extent.Flush();
            driver.Quit();
        }

       
    }
}

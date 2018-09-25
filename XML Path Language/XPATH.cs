using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace XML_Path_Language
{
    [TestFixture]
    class XPATH
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("http://www.seleniumeasy.com/test/basic-first-form-demo.html");
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void XPATH_Try_0()
        {
            // 1/2/3/4 file system
            //Абсолютний шлях:
            IWebElement element0 = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[1]/div[2]/form/div/input"));
            element0.Click();
            element0.Clear();
            element0.SendKeys("SET");
            Thread.Sleep(5000);


            //$x("шлях")
        }

        [Test]
        public void XPATH_Try_1()
        {
            //4 зміна 1-х 3-х не впливає на 4
            //Відносний шлях:

            //Syntax = //tagname[@attribute='Value']
            //Example = //input[@id='user-message']

            IWebElement element1 = driver.FindElement(By.XPath("//div[@class='form-group']//input[@ id='user-message']"));
            element1.Click();
            element1.Clear();
            element1.SendKeys("SET >= Best");
            Thread.Sleep(5000);

            ////Пошук безпосереднього дочірнього елемента:
            //IWebElement element2 = driver.FindElement(By.XPath("//div/a"));
            ////Пошук дочірнього елемента будь-якого рівня:
            //IWebElement element3 = driver.FindElement(By.XPath("//div//a"));
        }

        [Test]
        public void XPATH_Try_2_Trio()
        {
            // Syntax: //tag[@attribute='value']

            //Example:
            driver.FindElement(By.XPath("//input[@id='user-message']"));
            driver.FindElement(By.XPath("//input[@type='send.text']"));//" ">>"."
            driver.FindElement(By.XPath("//label[@id='clkBtn']"));
            driver.FindElement(By.XPath("//input[@value='SEND']"));
            driver.FindElement(By.XPath("//*[@class='swtestacademy']"));//“*” means, search “swtestacademy” class for all tags.
            driver.FindElement(By.XPath("//a[@href='https://www.swtestacademy.com/']"));
            driver.FindElement(By.XPath("//input[@id='searchbox']"));//
            driver.FindElement(By.XPath("//img[@src='http://www.seleniumeasy.com/sites/default/files/seleniumEasy_0.jpg']"));//
        }

        [Test]
        public void XPATH_Try_3_Contains()
        {
            // Syntax: //tag[contains(@attribute, 'value')]

            //Example:
            driver.FindElement(By.XPath("//*[contains(@name,'btnClk')]"));//It searches “btnClk” for all name attributes in the DOM.
            driver.FindElement(By.XPath("//*[contains(text(),'here')]"));//It searches the text “here” in the DOM.
            driver.FindElement(By.XPath("//*[contains(@href,'swtestacademy.com')]"));//It searches “swtestacademy.com” link in the DOM.
            driver.FindElement(By.XPath("//div[contains(@class,'tem-log')]"));
            driver.FindElement(By.XPath("//a[contains(@href,'/login')]"));
        }

        [Test]
        public void XPATH_Try_4_StartsWith()
        {
            // Syntax: //tag[starts-with(@attribute, 'value')]

            //Example:
            driver.FindElement(By.XPath("//input[starts-with(@id, 'user')]"));
            driver.FindElement(By.XPath("//div[starts-with(@class,'item-lo')]"));
            driver.FindElement(By.XPath("//a[starts-with(@href,'/logi')]"));
        }

        [Test]
        public void XPATH_Try_5_ChainedXPath()
        {
            //Example:
            driver.FindElement(By.XPath("//div[@class='form-group']//input[@id='user-message']"));
        }

        [Test]
        public void XPATH_Try_6_Or()
        {
            //Syntax: //tag[XPath Statement-1 or XPath Statement-2]

            //Example:
            driver.FindElement(By.XPath("//*[@id='user-message' or @class='form-control']"));
        }

        [Test]
        public void XPATH_Try_7_And()
        {
            //Syntax: //tag[XPath Statement-1 and XPath Statement-2]

            //Example:
            driver.FindElement(By.XPath("//*[@id='user-message' and @class='form-control']"));
        }

        [Test]
        public void XPATH_Try_8_Text()
        {
            //Syntax: //tag[text()='text value‘]

            //Example:
            driver.FindElement(By.XPath("//label[text()='Enter message']"));
        }

        [Test]
        public void XPATH_Try_9_Ancestor()
        {
            //Syntax: //tag[XPath Statement-1]//ancentor::tag

            //Example:
            driver.FindElement(By.XPath("//*[@class='container-fluid']//ancestor::div"));
            driver.FindElement(By.XPath(".//*[@class='container-fluid']//ancestor::div[5]"));
        }

        [Test]
        public void XPATH_Try_10_Following()
        {
            //Syntax: //tag[XPath Statement-1]//following::tag

            //Example:
            driver.FindElement(By.XPath(".//form[@id='gettotal']//following::input"));
        }

        [Test]
        public void XPATH_Try_11_13_Child_Descendant_()
        {
            //Syntax: //tag[XPath Statement-1]//child||descendant::tag

            //Example:
            driver.FindElement(By.XPath("//nav[@class='fusion-main-menu']//ul[@id='menu-main']/child::li"));
            driver.FindElement(By.XPath("//nav[@class='fusion-main-menu']//ul[@id='menu-main']/child::li[4]"));
            driver.FindElement(By.XPath("//nav[@class='fusion-main-menu']//ul[@id='menu-main']/descendant::li"));
            driver.FindElement(By.XPath("//nav[@class='fusion-main-menu']//ul[@id='menu-main']/descendant::li[4]"));
        }

        [Test]
        public void XPATH_Try_12_Preceding_()
        {
            //Syntax: //tag[XPath Statement-1]//preceding::tag

            //Example:
            driver.FindElement(By.XPath("//input[contains(@id,'user-message')]//preceding::li"));
            driver.FindElement(By.XPath("//input[contains(@id,'user-message')]//preceding::li[2]"));
        }

                [Test]
        public void XPATH_Try_13_Parent()
        {
            //Syntax: //tag[XPath Statement-1]//parent::tag

            //Example:
            driver.FindElement(By.XPath(".//*[@id='get-input']/button//parent::form"));
        }
    }
}

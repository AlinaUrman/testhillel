using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace testhillel
{
    public class Tests
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }
        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void sighnin()
        {
            driver.Navigate().GoToUrl("https://guest:welcome2qauto@qauto.forstudy.space/");
            driver.Manage().Window.Size = new System.Drawing.Size(1052, 656);
            driver.FindElement(By.CssSelector(".btn-outline-white")).Click();
            driver.FindElement(By.Id("signinEmail")).Click();
            driver.FindElement(By.Id("signinEmail")).SendKeys("test_test1234@gmail.com");
            driver.FindElement(By.Id("signinPassword")).Click();
            driver.FindElement(By.Id("signinPassword")).SendKeys("Qwerty12345");
            driver.FindElement(By.CssSelector(".btn-primary:nth-child(2)")).Click();
            {
                WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));
                wait.Until(driver => driver.FindElements(By.LinkText("Log out")).Count > 0);
            }
            var elements = driver.FindElements(By.LinkText("Log out"));
            Assert.True(elements.Count > 0);
        }
    }

}

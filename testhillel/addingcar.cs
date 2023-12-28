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
    public class SighninTest
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
            driver.Navigate().GoToUrl("https://qauto.forstudy.space/panel/garage");
            driver.Manage().Window.Size = new System.Drawing.Size(1052, 656);
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.FindElement(By.Id("addCarBrand")).Click();
            driver.FindElement(By.Id("addCarModel")).Click();
            driver.FindElement(By.Id("addCarMileage")).Click();
            driver.FindElement(By.Id("addCarMileage")).SendKeys("123");
            driver.FindElement(By.CssSelector(".modal-footer > .btn-primary")).Click();
                  driver.Navigate().GoToUrl("https://qauto.forstudy.space/panel/garage");
                driver.Manage().Window.Size = new System.Drawing.Size(1052, 656);
                driver.FindElement(By.CssSelector(".car_add-expense")).Click();
                driver.FindElement(By.Id("addExpenseMileage")).Click();
                driver.FindElement(By.Id("addExpenseMileage")).SendKeys("1234");
                driver.FindElement(By.Id("addExpenseLiters")).Click();
                driver.FindElement(By.Id("addExpenseLiters")).SendKeys("10");
                driver.FindElement(By.Id("addExpenseTotalCost")).Click();
                driver.FindElement(By.Id("addExpenseTotalCost")).SendKeys("10");
                driver.FindElement(By.CssSelector(".modal-footer > .btn-primary")).Click();
            }
    }
}
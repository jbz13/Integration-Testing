using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Test2
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void The2Test()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.XPath("//form[@id='login_form']/div/div/label")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("fobstinate@gmail.com");
            driver.FindElement(By.Id("passwd")).Click();
            driver.FindElement(By.Id("passwd")).Clear();
            driver.FindElement(By.Id("passwd")).SendKeys("123456");
            driver.FindElement(By.XPath("//button[@id='SubmitLogin']/span")).Click();
            driver.FindElement(By.XPath("//div[@id='center_column']/div/div/ul/li/a/span")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'Dresses')])[5]")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'T-shirts')])[2]")).Click();
            driver.FindElement(By.XPath("//div[@id='center_column']/ul/li/div/div[2]/div[2]/a/span")).Click();
            driver.FindElement(By.XPath("//div[@id='layer_cart']/div/div[2]/div[4]/span/span")).Click();
            driver.FindElement(By.XPath("//header[@id='header']/div[3]/div/div/div[3]/div/div/div/div/dl/dt/span/a")).Click();
            driver.FindElement(By.LinkText("Sign out")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}


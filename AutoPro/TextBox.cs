using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoPro
{
    [TestClass]
    public class TextBox
    {
        public IWebDriver driver;

        [TestMethod]
        public void Auto_TextBox()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://demoqa.com/text-box";


            driver.FindElement(By.Id("userName")).SendKeys("Maaz Ahmed");
            driver.FindElement(By.Id("userEmail")).SendKeys("maaz1946@gmail.com");
            driver.FindElement(By.Id("currentAddress")).SendKeys("R - 51, Sec Z - VI, Gulshan - e - Maymar");
            driver.FindElement(By.Id("permanentAddress")).SendKeys("R - 65, Sec Z - VI, Gulshan - e - Maymar");

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,200)", "");

            driver.FindElement(By.Id("submit")).Click();
            //OR
            //driver.FindElement(By.Id("submit")).SendKeys(Keys.Return);
            Thread.Sleep(5000);

            //IWebDriver actVal = (IWebDriver)driver.FindElement(By.XPath("//*[@id=\"output\"]/div"));
            string actVal = driver.FindElement(By.Id("name")).Text;
            string expVal = "Name:Maaz Ahmed";
            Assert.AreEqual(expVal, actVal);

            driver.Quit();
        }
    }
}

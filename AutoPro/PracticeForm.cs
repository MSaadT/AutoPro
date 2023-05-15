using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoPro
{
    [TestClass]
    public class PracticeForm
    {
        IWebDriver driver;

        [TestMethod]
        public void PracForm()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://demoqa.com/";
            Thread.Sleep(2000);

            //Redirect from Main Page to Forms
            driver.FindElement(By.XPath("//*[@id='app']/div/div/div[2]/div/div[2]/div/div[1]")).Click();
            Thread.Sleep(2000);

            //Redirect from Forms to Practice Form
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[1]/div/div/div[2]/div/ul/li")).Click();
            Assert.AreEqual("Practice Form", driver.FindElement(By.ClassName("main-header")).Text);
            Thread.Sleep(2000);
        }
    }
}

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
    public class CheckBox
    {
        public IWebDriver driver;

        [TestMethod]
        public void Check_Box()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://demoqa.com/";
            Thread.Sleep(2000);

            //Redirect from Main Page to Elements
            driver.FindElement(By.XPath("//*[@id='app']/div/div/div[2]/div/div[1]/div/div[1]")).Click();
            Thread.Sleep(2000);

            //Redirect from Elements to Check Box
            driver.FindElement(By.XPath("//*[@id='item-1']")).Click();
            Assert.AreEqual("Home", driver.FindElement(By.ClassName("rct-title")).Text);
            Thread.Sleep(2000);

            //Select " + " Sign on left for Dropdown
            driver.FindElement(By.XPath("//*[@id='tree-node']/div/button[1]")).Click();
            Assert.AreEqual("Downloads", driver.FindElement(By.XPath("//*[@id='tree-node']/ol/li/ol/li[3]/span/label/span[3]")).Text);
            Thread.Sleep(2000);

            //Select "Notes" Check Box
            driver.FindElement(By.XPath("//*[@id='tree-node']/ol/li/ol/li[1]/ol/li[1]/span/label/span[1]")).Click();
            Thread.Sleep(2000);

            //Unselect "Notes" Check Box
            driver.FindElement(By.XPath("//*[@id='tree-node']/ol/li/ol/li[1]/ol/li[1]/span/label/span[1]")).Click();
            Thread.Sleep(2000);

            //Condition for "Commands" Check Box
            if (!driver.FindElement(By.XPath("//input[@id='tree-node-notes']")).Selected)
            {
                driver.FindElement(By.XPath("//*[@id='tree-node']/ol/li/ol/li[1]/ol/li[2]/span/label/span[1]")).Click();
            }
            Thread.Sleep(2000);

            driver.Quit();
        }
    }
}

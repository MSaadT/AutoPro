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
    public class RadioButton
    {
        public IWebDriver dr;
        [TestMethod]
        public void RadioButton_Click()
        {
            dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
            dr.Url = "https://demoqa.com/";
            Thread.Sleep(2000);

            //Redirect from Main Page to Elements
            dr.FindElement(By.XPath("//*[@id='app']/div/div/div[2]/div/div[1]/div/div[1]")).Click();
            Thread.Sleep(2000);

            //Redirect from Elements to Radio Button
            dr.FindElement(By.XPath("//*[@id='item-2']")).Click();
            Assert.AreEqual("Do you like the site?", dr.FindElement(By.ClassName("mb-3")).Text);
            Thread.Sleep(2000);

            //Select "Impressive" Radio Button
            dr.FindElement(By.XPath("//*[@id='app']/div/div/div[2]/div[2]/div[2]/div[3]/label")).Click();
            Thread.Sleep(2000);

            //dr.FindElement(By.XPath("//*[@id='app']/div/div/div[2]/div[2]/div[2]/div[2]")).Click();

            //Condition for the Selection of "Yes" Radio Button
            if (dr.FindElement(By.XPath("//*[@id='impressiveRadio']")).Selected)
            {
                dr.FindElement(By.XPath("//*[@id='app']/div/div/div[2]/div[2]/div[2]/div[2]/label")).Click();
            }

            bool val = false;

            if (dr.FindElement(By.XPath("//*[@id='yesRadio']")).Selected)
            {
                val = true;
            }
            Assert.IsTrue(val);
            Thread.Sleep(2000);

            dr.Quit();
        }
    }
}

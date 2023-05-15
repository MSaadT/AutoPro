using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AutoPro
{
    [TestClass]
    public class LoginFeatures : MainExecuction
    {
        #region Empty_Login
        /// <summary>
        /// This Test Case will check Login functionality with no details
        /// </summary>
        [TestMethod]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Parallelize.xml", "EmptyLogin", DataAccessMethod.Sequential)]
        public void EmptyLogin()
        {
            driver.FindElement(By.Id("login")).SendKeys(Keys.Return);

            //string expectedResult = "Enter Username";
            //string actualResult = driver.FindElement(By.XPath("//*[@id='username_span']")).Text;
            //Assert.AreEqual(expectedResult,actualResult);
            Assert.AreEqual("Enter Username", driver.FindElement(By.Id("username_span")).Text);
        }
        #endregion
        #region Invalid_Login
        /// <summary>
        /// This Test Case will check Login functionality using Invalid Credentials
        /// </summary>
        [TestMethod]
       //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Parallelize.xml", "InvalidLogin", DataAccessMethod.Sequential)]
        public void InvalidLogin()
        {
            driver.FindElement(By.Id("username")).SendKeys("admin08");
            driver.FindElement(By.Id("password")).SendKeys("power123");
            driver.FindElement(By.Id("login")).SendKeys(Keys.Return);

            string expResult = "Invalid Login details or Your Password might have expired. Click here to reset your password";
            string actResult = driver.FindElement(By.XPath("//*[@id='login_form']/table/tbody/tr[5]/td[2]/div/b")).Text;
            Assert.AreEqual(expResult, actResult);
        }
        #endregion
        #region Valid_Login
        /// <summary>
        /// This Test Case will check Login functionality using Valid Credentials
        /// </summary>
        //private const string Dataxml = "C:\\Users\\Hp\\source\\repos\\AutoPro\\AutoPro\\Data.xml";
        //private const string DataCSV = "C:\\Users\\Hp\\source\\repos\\AutoPro\\AutoPro\\Data.csv";
        [TestMethod]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "C:\\Users\\Hp\\source\\repos\\AutoPro\\AutoPro\\Data.xml", "ValidLogin", DataAccessMethod.Sequential)]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "C:\\Users\\Hp\\source\\repos\\AutoPro\\AutoPro\\Data.csv", "Data#csv", DataAccessMethod.Sequential)]
        //[DataRow("admin0813", "power123")]
        [DataRow("admin0812", "power123")]
        //string user, string pass
        public void ValidLogin(string user, string pass)
        {
            //string user = TestContext.DataRow["user"].ToString();
            //string pass = TestContext.DataRow["pass"].ToString();

            driver.FindElement(By.Id("username")).SendKeys(TestContext.DataRow[0].ToString());
            driver.FindElement(By.Id("password")).SendKeys(TestContext.DataRow[1].ToString());
            driver.FindElement(By.Id("login")).SendKeys(Keys.Return);

            Thread.Sleep(2000);

            Assert.AreEqual("Welcome to Adactin Group of Hotels", driver.FindElement(By.ClassName("welcome_menu")).Text);

            driver.FindElement(By.XPath("/html/body/table[2]/tbody/tr[1]/td[2]/a[4]")).SendKeys(Keys.Return);
            driver.FindElement(By.XPath("/html/body/table[2]/tbody/tr/td[1]/table/tbody/tr/td/a")).SendKeys(Keys.Return);
        }
        #endregion
    }
}

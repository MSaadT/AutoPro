using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPro
{
    [TestClass]
    public class SignupFeatures : MainExecuction
    {
        #region Redirect_to_Signup_Page
        /// <summary>
        /// This Test Case will check Signup functionality using New Credentials
        /// </summary>
        [TestMethod]
        public void SignupPage()
        {
            driver.FindElement(By.ClassName("login_register")).Click();
            string msg = driver.FindElement(By.XPath("//*[@id='register_form']/table/tbody/tr[1]/td/table/tbody/tr/td[1]")).Text;
            Assert.AreEqual("New User Registration Form (Fields marked with Red asterix (*) are mandatory)", msg);

            driver.FindElement(By.XPath("//*[@id='register_form']/table/tbody/tr[1]/td/table/tbody/tr/td[2]/a")).Click();
            Assert.AreEqual("Adactin Launches The Adactin Hotel App!", driver.FindElement(By.XPath("/html/body/table[2]/tbody/tr/td[1]/p")).Text);
        }
        #endregion
    }
}

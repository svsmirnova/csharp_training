using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class NovigationHelper
    {
        private IWebDriver driver;
        private string baseURL;

        public NovigationHelper(IWebDriver driver, string baseURL)
        {
            this.driver = driver;
            this.baseURL = baseURL;
        }
        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
        public void ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }
        public void GoToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}

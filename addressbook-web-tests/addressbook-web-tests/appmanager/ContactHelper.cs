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
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {}

        public ContactHelper Remove()
        {
            manager.Navigator.GoToHomePage();
            SelectContact();
            RemoveContact();
            manager.Navigator.GoToHomePage();
            return this;
        }
        private List<ContactData> contactCache = null;
        internal List<ContactData> GetContactsList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
                foreach (IWebElement element in elements)
                {
                    var cells = element.FindElements(By.XPath("./td"));
                    //contactCache.Add(new ContactData(cells[2].Text, cells[1].Text, cells[4].Text));
                    element.FindElements(By.XPath("//tr[@name='entry']/td[@class='center']"));
                    contactCache.Add(new ContactData(cells[2].Text, cells[1].Text, cells[4].Text) { Id = element.FindElement(By.TagName("input")).GetAttribute("value") });

                }
            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactsCount()
        {
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count();
        }

        internal ContactHelper Create(ContactData contact)  
        {
            manager.Navigator.GoToHomePage();
            InitContactCreation();
            FillContactData(contact);
            SubmitContactCreation();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Modify(int v, ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            SelectContact();
            InitContactModification();
            FillContactData(contact);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }
        public ContactHelper SelectContact()
        {
            if (IsElementPresent(By.Name("selected[]")))
            {
                driver.FindElement(By.XPath("(//input[@name='selected[]'])[1]")).Click();
                return this;
            }
            else
            {
                ContactData contact = new ContactData("testFirstName", "testLastName", "testEmail")
                {
                    NickName = "testNickname",
                    Company = "testCompany",
                    Address = "testAddress"
                };
                Create(contact);
                driver.FindElement(By.XPath("(//input[@name='selected[]'])[1]")).Click();
                return this;
            }
                
        }
        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper FillContactData(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.SecondName);
            Type(By.Name("nickname"), contact.NickName);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("email"), contact.Email);
            return this;
        }
    }
}

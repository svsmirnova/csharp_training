using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void TheUntitledTestCaseTest()
        {
            novigationHelper.GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            contactHelper.InitContactCreation();
            ContactData contact = new ContactData("testFirstName", "testLastName", "testEmail");
            contact.NickName = "testNickname";
            contact.Company = "testCompany";
            contact.Company = "testAddress";
            contactHelper.FillContactData(contact);
            novigationHelper.ReturnToHomePage();
        }
    }
}

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
        public void ContactCreationTest()
        {
            app.Contacts.InitContactCreation();
            ContactData contact = new ContactData("testFirstName", "testLastName", "testEmail");
            contact.NickName = "testNickname";
            contact.Company = "testCompany";
            contact.Company = "testAddress";
            app.Contacts.FillContactData(contact);
            app.Contacts.SubmitContactCreation();
            app.Navigator.ReturnToHomePage();
        }
    }
}

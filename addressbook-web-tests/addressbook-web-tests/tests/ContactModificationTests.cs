using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData("testFirstNameModified", "testLastNameModified", "testEmailModified");
            if (app.Contacts.ContactCheckExistence())
            {
                app.Contacts.Modify(1, contact);
            }
            else
            {
                ContactData newContact = new ContactData("testFirstName", "testLastName", "testEmail")
                {
                    NickName = "testNickname",
                    Company = "testCompany",
                    Address = "testAddress"
                };
                app.Contacts.Create(newContact);
                app.Contacts.Modify(1, contact);
            }
        }
    }
}

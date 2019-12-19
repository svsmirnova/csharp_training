using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("testFirstName", "testLastName")
            {
                NickName = "testNickname",
                Company = "testCompany",
                Address = "testAddress"
            };
            List<ContactData> oldContacts = app.Contacts.GetContactsList();
            app.Contacts.Create(contact);
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactsCount());
            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}

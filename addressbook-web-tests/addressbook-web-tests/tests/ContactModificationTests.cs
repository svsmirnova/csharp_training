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
            List<ContactData> oldContacts = app.Contacts.GetContactsList();
            app.Contacts.Modify(1, contact);
            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts[0].FirstName = contact.FirstName;
            oldContacts[0].SecondName = contact.SecondName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

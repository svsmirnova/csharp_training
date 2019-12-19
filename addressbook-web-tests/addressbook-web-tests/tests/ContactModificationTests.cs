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
            ContactData contact = new ContactData("testFirstNameModified", "testLastNameModified");
            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            ContactData oldContactData = oldContacts[0];

            app.Contacts.Modify(1, contact);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactsCount());
            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts[0].FirstName = contact.FirstName;
            oldContacts[0].SecondName = contact.SecondName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact1 in newContacts)
            {
                if (contact1.Id == oldContactData.Id)
                {
                    Assert.AreEqual(oldContactData.FirstName, contact1.FirstName);
                }
            }
        }
    }
}

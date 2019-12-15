using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactsList();
            app.Contacts.Remove();
          //  Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount()); 
            List<ContactData> newContacts = app.Contacts.GetContactsList();

            Assert.AreEqual(oldContacts.Count - 1, newContacts.Count); // а вот так все работает

            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData group in newContacts)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}

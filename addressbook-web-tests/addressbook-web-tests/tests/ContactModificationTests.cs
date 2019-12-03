using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests :TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData("testFirstNameModified", "testLastNameModified", "testEmailModified");
            app.Contacts.Modify(1,contact);
        }
    }
}

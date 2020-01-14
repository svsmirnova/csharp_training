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
            if (app.Contacts.ContactCheckExistence())
            {
                app.Contacts.Remove();
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
                app.Contacts.Remove();
            }
        }
    }
}

﻿using System;
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
            ContactData contact = new ContactData("testFirstName", "testLastName", "testEmail")
            {
                NickName = "testNickname",
                Company = "testCompany",
                Address = "testAddress"
            };
            app.Contacts.Create(contact);
        }
    }
}

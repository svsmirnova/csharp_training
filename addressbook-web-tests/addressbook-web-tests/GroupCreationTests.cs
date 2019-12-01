﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            novigationHelper.GoToHomePage();
            loginHelper.Login(new AccountData ("admin", "secret"));
            novigationHelper.GoToGroupPage();
            groupHelper.InitGroupCreation();
            GroupData group = new GroupData("testName");
            group.Header = "testHeader";
            group.Footer = "testFooter";
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitGroupCreation();
            novigationHelper.ReturnToGroupPage();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("testNameModified");
            newData.Header = null;
            newData.Footer = null;
            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            app.Groups.Modify(1, newData);
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();   
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

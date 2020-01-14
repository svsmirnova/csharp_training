using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("testName")
            {
                Header = "testHeader",
                Footer = "testFooter"
            };
            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            app.Groups.Create(group);
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("")
            {
                Header = "",
                Footer = ""
            };
            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            app.Groups.Create(group);
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

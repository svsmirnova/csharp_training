using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (app.Groups.GroupCheckExistence())
            {
                app.Groups.Remove(1);
            }
            else
            {
                GroupData group = new GroupData("testName")
                {
                    Header = "testHeader",
                    Footer = "testFooter"
                };
                app.Groups.Create(group);
                app.Groups.Remove(1);
            }
        }
    }
}

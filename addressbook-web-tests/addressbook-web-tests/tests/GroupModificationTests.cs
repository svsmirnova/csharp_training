using System;
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
            if (app.Groups.GroupCheckExistence())
            {
                app.Groups.Modify(1, newData);
            }
            else
            {
                GroupData group = new GroupData("testName")
                {
                    Header = "testHeader",
                    Footer = "testFooter"
                };
                app.Groups.Create(group);
                app.Groups.Modify(1, newData);
            }
                
        }
    }
}

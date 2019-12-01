using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            novigationHelper.GoToHomePage();
            loginHelper.Login(new AccountData ("admin", "secret"));
            novigationHelper.GoToGroupPage();
            groupHelper.SelectGroup(1);
            groupHelper.RemoveGroup();
            novigationHelper.ReturnToGroupPage();
        }
    }
}

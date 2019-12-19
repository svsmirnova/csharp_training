using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;

        public bool Equals(ContactData other)
        {
            if (other is null)
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName & SecondName == other.SecondName;
        }

        public override int GetHashCode()
        {
            return (FirstName+SecondName).GetHashCode();
        }
        public override string ToString()
        {
            return "name = " + (FirstName + SecondName);
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (other.SecondName == SecondName)
            {
                if (other.FirstName == FirstName)
                {
                    return (FirstName).CompareTo(other.FirstName); ;
                }
            }
            return (SecondName).CompareTo(other.SecondName);
        }

        public ContactData(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;
        }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string NickName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace("", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string details;
        private string allEmail;

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
        public string Fax { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string Address2 { get; set; }
        public string Phone2 { get; set; }
        public string Notes { get; set; }

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

        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    return CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3).Trim();
                }
            }
            set
            {
                allEmail = value;
            }
        }

        public string Details
        {
            get
            {
                if (details != null)
                {
                    return details;
                }
                else
                {
                    return FirstName + " " + SecondName + "\r\n\r\n" + 
                        Add(HomePhone, "H: ") + Add(MobilePhone, "M: ") + Add(WorkPhone, "W: ") + "\r\n"
                        + Add(Email, "") + Add(Email2, "") + Add(Email3, "").Trim();
                }
            }
            set
            {
                details = value;
            }
        }

        private string Add(string field, string prefix)
        {
            if (!string.IsNullOrEmpty(field))
            {
                return $"{prefix}{field}\r\n";
            }
            return string.Empty;
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }
    }
}

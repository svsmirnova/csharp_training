using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName;
        private string secondName;
        private string nickName = "";
        private string company = "";
        private string address = "";
        private string email;

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

        public ContactData(string firstName, string secondName, string email)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.email = email;
        }

        public string FirstName 
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; }
        }
        public string NickName
        {
            get { return nickName; }
            set { nickName = value; }
        }
        public string Company
        {
            get { return company; }
            set { company = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Id { get; set; }

    }
}

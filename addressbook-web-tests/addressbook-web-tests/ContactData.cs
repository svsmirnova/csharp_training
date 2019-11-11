using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class ContactData
    {
        private string firstName;
        private string secondName;
        private string nickName = "";
        private string company = "";
        private string address = "";
        private string email;

        public ContactData (string firstName, string secondName, string email)
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

    }
}

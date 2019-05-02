using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCorp.IMS.MobileLibrary {
    public class Contact {
        public string Name { get; set; }
        public List<string> PhoneNumber { get; set; }

        public Contact(string name, string number) {
            Name = name;
            PhoneNumber = new List<string>();
            PhoneNumber.Add(number);
        }

        public Contact(string name, List<string> numbers) {
            Name = name;
            PhoneNumber = new List<string>(numbers);
        }

        public Contact(Contact contact) {
            Name = string.Copy(contact.Name);
            PhoneNumber = new List<string>(contact.PhoneNumber);
        }

        public void AddPhoneNumber(string number) {
            PhoneNumber.Add(number);
        }

        public override bool Equals(object obj) {
            try {
                obj = (Contact)obj;
            } catch {
                throw new ArgumentException("Objects to compare should be type Contact.");
            }
            return Name.Equals(((Contact)obj).Name);
        }
    }
}

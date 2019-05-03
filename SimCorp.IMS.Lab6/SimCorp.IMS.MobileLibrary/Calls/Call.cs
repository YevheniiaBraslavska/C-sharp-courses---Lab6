using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCorp.IMS.MobileLibrary {
    public class Call : IComparable{
        public enum CallDirection {
            Incoming,
            Outcoming
        }

        public Contact Contact { get; set; }
        public DateTime Time { get; set; }
        public CallDirection Direction { get; set; }

        public Call(Contact contact, DateTime time, CallDirection direction) {
            Contact = new Contact(contact);
            Time = time;
            Direction = direction;
        }

        public int CompareTo(object obj) {
            try {
                obj = (Call)obj;
            } catch {
                throw new ArgumentException("Objects to compare should be type Calls.");
            }
            return ((Call)obj).Time.CompareTo(Time); 
        }

        public override bool Equals(object obj) {
            return obj is Call && Contact.Equals(((Call)obj).Contact) && Direction.Equals(((Call)obj).Direction);
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}

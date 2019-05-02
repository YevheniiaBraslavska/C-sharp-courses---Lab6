using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCorp.IMS.MobileLibrary {
    public class CallsGroup : IComparable {
        public List<Call> Calls;
        public int Count
        {
            get { return Calls.Count; }
        }
        public Contact Contact
        {
            get { return Calls[0].Contact; }
        }

        public DateTime Time
        {
            get { return Calls[0].Time; }
        }

        public Call.CallDirection Direction
        {
            get { return Calls[0].Direction; }
        }

        public CallsGroup(List<Call> calls) {
            Calls = new List<Call>(calls);
        }

        public CallsGroup(Call call) {
            Calls = new List<Call>();
            Calls.Add(call);
        }

        public void AddCall(Call call) {
            Calls.Add(call);
        }

        public int CompareTo(object obj) {
            try {
                obj = (CallsGroup)obj;
            } catch {
                throw new ArgumentException("Objects to compare should be type CallsGroup.");
            }
            return ((CallsGroup)obj).Time.CompareTo(Time);
        }

        public override bool Equals(object obj) {
            try {
                obj = (CallsGroup)obj;
            } catch {
                throw new ArgumentException("Objects to compare should be type CallsGroup.");
            }
            return ((CallsGroup)obj).Calls[0].Equals(Calls[0]);
        }
    }
}

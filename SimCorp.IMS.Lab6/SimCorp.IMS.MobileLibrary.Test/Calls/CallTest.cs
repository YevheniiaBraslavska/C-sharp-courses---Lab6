using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimCorp.IMS.MobileLibrary;

namespace MobileLibrary.Test {
    [TestClass]
    public class CallTest {
        [TestMethod]
        public void GIVEN_CallOn01012018AndCallOn01012019_THEN_SortInDescendingOrder() {
            var calllist = new List<Call>();
            calllist.Add(new Call(new Contact("Name 1", "1"), new DateTime(2018, 1, 1), Call.CallDirection.Incoming));
            calllist.Add(new Call(new Contact("Name 2", "2"), new DateTime(2019, 1, 1), Call.CallDirection.Incoming));

            calllist.Sort();

            Assert.AreEqual(new DateTime(2019, 1, 1), calllist[0].Time);
            Assert.AreEqual(new DateTime(2018, 1, 1), calllist[0].Time);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareCallToNotCall() {
            var call = new Call(new Contact("Name 1", "1"), new DateTime(2018, 1, 1), Call.CallDirection.Incoming);

            var result = call.CompareTo(new DateTime(2019,1,1));
        }

        [TestMethod]
        public void GIVEN_CallContact1IncomingAndCallContact1Outcoming_THEN_NotEqual() {
            var call1 = new Call(new Contact("Name 1", "1"), new DateTime(2018, 1, 1), Call.CallDirection.Incoming);
            var call2 = new Call(new Contact("Name 1", "1"), new DateTime(2019, 1, 1), Call.CallDirection.Outcoming);

            Assert.AreEqual(false, call1.Equals(call2));
        }

        [TestMethod]
        public void GIVEN_CallContact1IncomingAndCallContact1Incoming_THEN_Equal() {
            var call1 = new Call(new Contact("Name 1", "1"), new DateTime(2018, 1, 1), Call.CallDirection.Incoming);
            var call2 = new Call(new Contact("Name 1", "1"), new DateTime(2019, 1, 1), Call.CallDirection.Incoming);

            Assert.AreEqual(true, call1.Equals(call2));
        }

        [TestMethod]
        public void GIVEN_CallContact1IncomingAndCallContact2Incoming_THEN_NotEqual() {
            var call1 = new Call(new Contact("Name 1", "1"), new DateTime(2018, 1, 1), Call.CallDirection.Incoming);
            var call2 = new Call(new Contact("Name 2", "2"), new DateTime(2019, 1, 1), Call.CallDirection.Incoming);

            Assert.AreEqual(false, call1.Equals(call2));
        }
    }
}

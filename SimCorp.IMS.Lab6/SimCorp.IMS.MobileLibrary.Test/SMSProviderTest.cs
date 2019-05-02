using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimCorp.IMS.MobileLibrary;

namespace MobileLibrary.Test {
    [TestClass]
    public class SMSProviderTest {
        [TestMethod]
        public void WHEN_PushMessage_THEN_EventRize() {
            var receivedEvents = new List<string>();
            var simcorpmobile = new SimCorpMobile();

            simcorpmobile.AddMessanger(delegate (object sender, SMSRecieverEventArgs e) {
                receivedEvents.Add(e.Message.Text);
            });

            var message = new UserMessage("User", "message");
            simcorpmobile.Memory.Write(simcorpmobile, new SMSRecieverEventArgs(message));

            Assert.AreEqual(1, receivedEvents.Count);
            Assert.AreEqual("message", receivedEvents[0]);
        }

        [TestMethod]
        public void WHEN_PushMessage_THEN_MessageAddedToMobileMemory() {
            var receivedEvents = new List<string>();
            var simcorpmobile = new SimCorpMobile();

            simcorpmobile.AddMessanger(delegate (object sender, SMSRecieverEventArgs e) {
                receivedEvents.Add(e.Message.Text);
            });

            var message = new UserMessage("User", "message");
            simcorpmobile.Memory.Write(simcorpmobile, new SMSRecieverEventArgs(message));

            var output = simcorpmobile.Memory.Messages;
            var expect = new List<UserMessage> {message};
            Assert.AreEqual(!expect.Except(output).Any(), !output.Except(expect).Any());
        }
    }
}

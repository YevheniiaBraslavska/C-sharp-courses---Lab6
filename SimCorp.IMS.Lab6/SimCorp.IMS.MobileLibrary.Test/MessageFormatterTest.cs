using System;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimCorp.IMS.MobileLibrary;

namespace MobileLibrary.Test {
    [TestClass]
    public class MessageFormatterTest {
        [TestMethod]
        public void StartWithTimeRightOutput() {
            var message = new UserMessage("user", "message");

            var act_message = MessageFormatter.StartWithTime(message);

            Assert.AreEqual(act_message, $"[{message.ReceivingTime}] {message.Text}");
        }

        [TestMethod]
        public void EndWithTimeRightOutput() {
            var message = new UserMessage("user", "message");

            var act_message = MessageFormatter.EndWithTime(message);

            Assert.AreEqual(act_message, $"{message.Text} [{message.ReceivingTime}]");
        }

        [TestMethod]
        public void LowerCaseRightOutput() {
            var message = new UserMessage("user", "message");

            var act_message = MessageFormatter.LowerCase(message);

            Assert.AreEqual(act_message, "message");
        }

        [TestMethod]
        public void UpperCaseRightOutput() {
            var message = new UserMessage("user", "message");

            var act_message = MessageFormatter.UpperCase(message);

            Assert.AreEqual(act_message, "MESSAGE");
        }

        [TestMethod]
        public void CustomRightOutput() {
            var message = new UserMessage("user", "message");

            var act_message = MessageFormatter.Custom(message);

            Assert.AreEqual(act_message, "egassem");
        }
    }
}

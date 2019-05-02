using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimCorp.IMS.MobileLibrary;

namespace MobileLibrary.Test {
    [TestClass]
    public class MessagesFilterTest {

        //---------------------
        // GetAllUsers 
        //--------------------------
        [TestMethod]
        public void GetAllUsersEmptyList() {
            var list = new List<UserMessage>();

            var output = MessagesFilter.GetAllUsers(list);

            Assert.AreEqual(0, output.Count);
        }

        [TestMethod]
        public void GetAllUsersNullList() {
            var a = MessagesFilter.GetAllUsers(null);
            Assert.AreEqual(null, MessagesFilter.GetAllUsers(null));
        }

        [TestMethod]
        public void GetAllUsersNormalFlow() {
            var list = new List<UserMessage>
            {
                new UserMessage("User 1", "Message 1"),
                new UserMessage("User 2", "Message 2"),
                new UserMessage("User 2", "Message 3"),
            };

            var output = MessagesFilter.GetAllUsers(list);

            var expect = new List<string> { "User 1", "User 2" };
            Assert.AreEqual(!expect.Except(output).Any(), !output.Except(expect).Any());
        }

        //-------------------------
        // GetMessagesForUser
        //---------------------------------
        [TestMethod]
        public void GetMessagesForUserEmptyListAndNotEmptyUser() {
            var list = new List<UserMessage>();

            var output = MessagesFilter.GetMessagesForUser(list, "User 1");

            Assert.AreEqual(0, output.Count());
        }

        [TestMethod]
        public void GetMessagesForUserNullListAndNotEmptyUser() {
            Assert.AreEqual(null, MessagesFilter.GetMessagesForUser(null, "User 1"));
        }

        [TestMethod]
        public void GetMessagesForUserNotEmptyListAndEmptyUser() {
            var list = new List<UserMessage>
            {
                new UserMessage("User 1", "Message 1"),
                new UserMessage("User 2", "Message 2"),
                new UserMessage("User 2", "Message 3"),
            };

            var output = MessagesFilter.GetMessagesForUser(list, "");

            Assert.AreEqual(0, output.Count());
        }

        [TestMethod]
        public void GetMessagesForUserNotEmptyListAndNullUser() {
            var list = new List<UserMessage>
            {
                new UserMessage("User 1", "Message 1"),
                new UserMessage("User 2", "Message 2"),
                new UserMessage("User 2", "Message 3"),
            };

            var output = MessagesFilter.GetMessagesForUser(list, null);

            Assert.AreEqual(list.Count(), output.Count());
        }

        [TestMethod]
        public void GetMessagesForUserNotEmptyListAndAllUser() {
            var list = new List<UserMessage>
            {
                new UserMessage("User 1", "Message 1"),
                new UserMessage("User 2", "Message 2"),
                new UserMessage("User 2", "Message 3"),
            };

            var output = MessagesFilter.GetMessagesForUser(list, "All");

            Assert.AreEqual(list.Count(), output.Count());
        }

        [TestMethod]
        public void GetMessagesForUserNormalFlow() {
            var list = new List<UserMessage>
            {
                new UserMessage("User 1", "Message 1"),
                new UserMessage("User 2", "Message 2"),
                new UserMessage("User 2", "Message 3"),
            };

            var expect = new List<UserMessage>
            {
                new UserMessage("User 2", "Message 2"),
                new UserMessage("User 2", "Message 3"),
            };

            var output = MessagesFilter.GetMessagesForUser(list, "User 2");

            Assert.AreEqual(!expect.Except(output).Any(), !output.Except(expect).Any());
        }

        //----------------------
        // GetSearchMessages
        //-------------------
        [TestMethod]
        public void GetSearchMessagesEmptyListAndNotEmptySearch() {
            var list = new List<UserMessage>();

            var output = MessagesFilter.GetSearchMessages(list, "1");

            Assert.AreEqual(0, output.Count());
        }

        [TestMethod]
        public void GetSearchMessagesNullListAndNotEmptySearch() {
            Assert.AreEqual(null, MessagesFilter.GetSearchMessages(null, "1"));
        }

        [TestMethod]
        public void GetSearchMessagesNotEmptyListAndEmptySearch() {
            var list = new List<UserMessage>
            {
                new UserMessage("User 1", "Message 1"),
                new UserMessage("User 2", "Message 2"),
                new UserMessage("User 2", "Message 3"),
            };

            var output = MessagesFilter.GetSearchMessages(list, "");

            Assert.AreEqual(!list.Except(output).Any(), !output.Except(list).Any());
        }

        [TestMethod]
        public void GetSearchMessagesNotEmptyListAndNullSearch() {
            var list = new List<UserMessage>
            {
                new UserMessage("User 1", "Message 1"),
                new UserMessage("User 2", "Message 2"),
                new UserMessage("User 2", "Message 3"),
            };

            var output = MessagesFilter.GetSearchMessages(list, null);

            Assert.AreEqual(list.Count(), output.Count());
        }

        [TestMethod]
        public void GetSearchMessagesNormalFlow() {
            var list = new List<UserMessage>
            {
                new UserMessage("User 1", "Message 1"),
                new UserMessage("User 2", "Message 2"),
                new UserMessage("User 2", "Message 3"),
            };

            var expect = new List<UserMessage>
            {
                new UserMessage("User 2", "Message 2"),
            };

            var output = MessagesFilter.GetSearchMessages(list, "2");

            Assert.AreEqual(!expect.Except(output).Any(), !output.Except(expect).Any());
        }

        //------------------------
        // GetFromToDateMessages
        //-------------------------
        [TestMethod]
        public void GetFromToDateMessagesEmptyListAndNotEmptyFromDateAndToDate() {
            var list = new List<UserMessage>();
            var fromdate = new DateTime(2019, 01, 01);
            var todate = new DateTime(2019, 01, 01);

            var output = MessagesFilter.GetFromToDateMessages(list, fromdate, todate);

            Assert.AreEqual(0, output.Count());
        }

        [TestMethod]
        public void GetFromToDateMessagesNullListAndNotEmptyFromDateAndToDate() {
            var fromdate = new DateTime(2019, 01, 01);
            var todate = new DateTime(2019, 01, 01);
            Assert.AreEqual(null, MessagesFilter.GetFromToDateMessages(null, fromdate, todate));
        }

        [TestMethod]
        public void GetFromToDateMessagesNormalFlow() {
            var list = new List<UserMessage>
            {
                new UserMessage("User 1", "Message 1"),
                new UserMessage("User 2", "Message 2"),
                new UserMessage("User 2", "Message 3"),
            };
            var fromdate = DateTime.Now;
            var todate = DateTime.Now;

            var output = MessagesFilter.GetFromToDateMessages(list, fromdate, todate);

            Assert.AreEqual(!list.Except(output).Any(), !output.Except(list).Any());
        }

        public void GetFromToDateMessagesToDateEarlyThenFromDate() {
            var list = new List<UserMessage>
            {
                new UserMessage("User 1", "Message 1"),
                new UserMessage("User 2", "Message 2"),
                new UserMessage("User 2", "Message 3"),
            };
            var fromdate = new DateTime(2019,01,01);
            var todate = new DateTime(2018,01,01);

            var output = MessagesFilter.GetFromToDateMessages(list, fromdate, todate);

            var expect = new List<UserMessage>();

            Assert.AreEqual(!expect.Except(output).Any(), !output.Except(expect).Any());
        }
    }
}

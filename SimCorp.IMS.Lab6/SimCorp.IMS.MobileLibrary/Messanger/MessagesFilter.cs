using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCorp.IMS.MobileLibrary {
    public static class MessagesFilter {
        public static List<string> GetAllUsers(List<UserMessage> messages) {
            return messages?
                .Select(e => e.User)
                .Distinct()
                .ToList();
        }

        public static IEnumerable<UserMessage> GetMessagesForUser(List<UserMessage> messages, string user) {
            if (messages == null)
                return null;
            if (user == null || user == "All")
                return messages.ToList();
            return from message in messages
                   where message.User == user
                   select message;
        }

        public static IEnumerable<UserMessage> GetSearchMessages(List<UserMessage> messages, string search) {
            if (messages == null)
                return null;
            if (search == null)
                return messages.ToList();
            return from message in messages
                   where message.Text.Contains(search)
                   select message;
        }

        public static IEnumerable<UserMessage> GetFromToDateMessages(List<UserMessage> messages, DateTime fromdate, DateTime todate) {
            if (messages == null)
                return null;
            return from message in messages
                   where message.ReceivingTime.Date >= fromdate.Date && message.ReceivingTime.Date <= todate.Date
                   select message;
        }
    }
}

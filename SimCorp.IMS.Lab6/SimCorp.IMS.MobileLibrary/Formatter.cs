using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SimCorp.IMS.MobileLibrary {
    public class MessageFormatter {
        public delegate string FormatHandler(UserMessage text);

        public FormatHandler Formatter;

        public void SetFormat(FormatHandler del) {
            Formatter = del;
        }

        public bool NullFormatter() {
            return Formatter == null;
        }

        public void ClearFormat() {
            Formatter = null;
        }

        public static string StartWithTime(UserMessage message) {
            return $"[{message.ReceivingTime}] {message.Text}";
        }

        public static string EndWithTime(UserMessage message) {
            return $"{message.Text} [{message.ReceivingTime}]";
        }

        public static string LowerCase(UserMessage message) {
            return message.Text.ToLower();
        }

        public static string UpperCase(UserMessage message) {
            return message.Text.ToUpper();
        }

        public static string Custom(UserMessage message) {
            var charArray = message.Text.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}

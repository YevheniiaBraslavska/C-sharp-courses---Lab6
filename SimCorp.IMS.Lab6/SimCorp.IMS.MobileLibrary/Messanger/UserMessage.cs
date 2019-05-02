using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimCorp.IMS.MobileLibrary {
    public class UserMessage {
        public string User { get; set; }
        public string Text { get; set; }
        public DateTime ReceivingTime { get; set; }

        public UserMessage(string user, string text) {
            User = user;
            Text = text;
            ReceivingTime = DateTime.Now;
        }

        public UserMessage(string user, string text, DateTime time) : this(user, text)
        {
            ReceivingTime = time;
        }
    }
}

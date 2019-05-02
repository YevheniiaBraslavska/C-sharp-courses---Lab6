using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using SimCorp.IMS.MobileLibrary;

namespace SimCorp.IMS.MobileLibrary {
    internal class SMSProvider {
        public event EventHandler<SMSRecieverEventArgs> SMSRecieved;
        public MessageGenerator Generator;

        public SMSProvider(MessageGenerator generator) {
            Generator = generator;
        }

        public void RaiseSmsRecievedEvent(object sender, SMSRecieverEventArgs args) {
            SMSRecieved?.Invoke(sender, args);
        }
    }
}

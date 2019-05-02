using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SimCorp.IMS.MobileLibrary {
    public class MessageGenerator {
        public event EventHandler<SMSRecieverEventArgs> SMSCreated;
        private static int _vMessageCounter;
        protected bool _vWork = false;

        public MessageGenerator() {
            StartWork();
        }

        public void AddOnSmsCreated(EventHandler<SMSRecieverEventArgs> handler) {
            SMSCreated += handler;
        }

        public void RaiseSmsCreatedEvent(object sender, SMSRecieverEventArgs args) {
            SMSCreated?.Invoke(sender, args);
        }

        public void SMSPushTimer_Tick(object sender, ElapsedEventArgs e) {
            //Random choise of user, who send new message
            var users = GetUsers();
            var random = new Random();
            var randomusernumber = random.Next(0, users.Count);
            var randomuser = users[randomusernumber];
            _vMessageCounter += 1;
            var message = GenMessage(randomuser);
            var user = "User " + (randomuser + 1).ToString(CultureInfo.InvariantCulture);
            RaiseSmsCreatedEvent(this, new SMSRecieverEventArgs(message));
        }

        public List<string> GetUsers() {
            List<string> users = new List<string>();
            for (var i = 0; i < 3; i++) {
                users.Add("User " + (i + 1));
            }
            return users;
        }

        /// <summary>
        /// Generete a standart message and get a user name from mobile number
        /// </summary>
        /// <returns>Generated message structure</returns>
        private UserMessage GenMessage(string user) {
            var text = "Message " + _vMessageCounter;
            return new UserMessage(user, text);
        }

        public void StartGeneration() {
            _vWork = true;
        }

        public void StopGeneration() {
            _vWork = false;
        }

        public void StartTimer() {
            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += SMSPushTimer_Tick;
            while (true) {
                if (_vWork && !timer.Enabled) {
                    timer.Start();
                }
                if (!_vWork && timer.Enabled) {
                    timer.Stop();
                }
            }
        }

        public virtual void StartWork() {

        }      
    }
}

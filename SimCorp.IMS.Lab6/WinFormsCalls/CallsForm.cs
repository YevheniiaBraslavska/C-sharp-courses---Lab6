using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using SimCorp.IMS.MobileLibrary;

namespace SimCorp.IMS.WinFormsCalls {
    public partial class CallsForm : Form {
        public CallsForm() {
            InitializeComponent();
            StartCallsGenertion();
            Contacts = InitContacts(3);
            CallsList = new List<CallsGroup>();
        }

        private Thread CallsGenerator;
        private List<Contact> Contacts;
        private static Random random = new Random();
        private List<CallsGroup> CallsList;
        private bool Work = true;

        private void StartCallsGenertion() {
            Work = true;
            CallsGenerator = new Thread(GenCall);
            CallsGenerator.IsBackground = true;
            CallsGenerator.Start();
        }

        private List<Contact> InitContacts(int numberofcontacts) {
            var list = new List<Contact>();
            for (int i = 0; i < numberofcontacts; i++) {
                list.Add(new Contact("Contact " + (i + 1).ToString(), (i + 1).ToString() + "-623-125-32-56"));
            }
            return list;
        }

        private void GenCall() {
            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += TimerTick;
            timer.Start();
            while (Work) {
            }
        }

        private void TimerTick(object sender, ElapsedEventArgs e) {
            var randomuser = random.Next(Contacts.Count);
            var direction = random.Next(2);
            var newcall = new Call(Contacts[randomuser], DateTime.Now, (Call.CallDirection)direction);
            AddCall(newcall);
            PushCall(this);
        }

        private void PushCall(object sender) {
            if (InvokeRequired) {
                Invoke((MethodInvoker)delegate () {
                    PushCall(sender);
                });
            } else {
                CallsViewList.Items.Clear();
                CallsList.Sort();
                for (int i = 0; i < CallsList.Count; i++) {
                    var call = CallsList[i];
                    CallsViewList.Items.Add(new ListViewItem(new[] {
                        call.Contact.Name + " (" + call.Count.ToString() + ")",
                        "[" + call.Time.ToString() + "] " + call.Direction.ToString()
                    }));
                }
            }
        }

        private void AddCall(Call call) {
            CallsList.Sort();
            if (CallsList.Count == 0) {
                CallsList.Add(new CallsGroup(call));
            } else if (CallsList[0].Calls[0].Equals(call)) {
                CallsList[0].AddCall(call);
            } else {
                CallsList.Add(new CallsGroup(call));
            }
        }
    }
}

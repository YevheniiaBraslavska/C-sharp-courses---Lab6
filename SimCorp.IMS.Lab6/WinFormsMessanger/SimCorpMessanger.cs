using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using SimCorp.IMS.MobileLibrary;
using SimCorp.IMS.WinFormApp;

namespace SimCorp.IMS.WinFormsMessanger {
    public partial class SimCorpMessanger : Form {
        public SimCorpMessanger() {
            InitializeComponent();

            //Init
            Mobile.AddMessanger(PushMessage);
            Mobile.AddOnCreatedEvent(OnSmsRecieved);
            Mobile.AddChargeEvent(OnChargeChanged);
            AddFormatTypesToComboBox();
        }

        private SimCorpMobile Mobile = new SimCorpMobile();
        private readonly MessageFormatter _vFormatter = new MessageFormatter();

        private void FormatTypesBox_SelectedIndexChanged(object sender, EventArgs e) {
            SetFormatter();
        }

        public void OnSmsRecieved(object sender, SMSRecieverEventArgs args) {
            if (InvokeRequired) {
                Invoke(new EventHandler<SMSRecieverEventArgs>(OnSmsRecieved), sender, args);
            }
            Mobile.Memory.Write(Mobile, args);
        }

        /// <summary>
        /// Push message onto the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void PushMessage(object sender, SMSRecieverEventArgs args) {
            ShowMessages(Mobile.Memory.Messages);
            SelectedUser(Mobile.Memory.Messages);
        }

        private void ShowMessages(List<UserMessage> messages) {
            if (InvokeRequired) {
                Invoke((MethodInvoker)delegate () {
                    ShowMessages(messages);
                });
            } else {
                MessageListView.Items.Clear();
                var messagestoshow = GetValidMessages(messages);
                foreach (var message in messagestoshow) {
                    var formattedstring = _vFormatter.NullFormatter() ? message.Text : _vFormatter.Formatter(message);
                    MessageListView.Items.Add(new ListViewItem(new[] { message.User, formattedstring }));
                }
            }
        }

        private IEnumerable<UserMessage> GetValidMessages(List<UserMessage> messages) {
            var userfilterres = MessagesFilter.GetMessagesForUser(messages, UsersComboBox.SelectedItem?.ToString());
            var searchfilterres = MessagesFilter.GetSearchMessages(messages, SearchBox.Text);
            var datafilterres = MessagesFilter.GetFromToDateMessages(messages, FromDate.Value, ToDate.Value);
            var messagestoshow = userfilterres.Intersect(searchfilterres);
            messagestoshow = messagestoshow.Intersect(datafilterres);
            return messagestoshow;
        }

        /// <summary>
        /// Set Formatting type to formatter due to active formatting in combo box
        /// </summary>
        private void SetFormatter() {
            switch (FormatTypesBox.SelectedItem.ToString()) {
                case "Start with DateTime":
                _vFormatter.SetFormat(MessageFormatter.StartWithTime);
                break;
                case "End with DateTime":
                _vFormatter.SetFormat(MessageFormatter.EndWithTime);
                break;
                case "Custom":
                _vFormatter.SetFormat(MessageFormatter.Custom);
                break;
                case "Lowercase":
                _vFormatter.SetFormat(MessageFormatter.LowerCase);
                break;
                case "Uppercase":
                _vFormatter.SetFormat(MessageFormatter.UpperCase);
                break;
                default:
                _vFormatter.ClearFormat();
                break;
            }
        }

        private void AddFormatTypesToComboBox() {
            var items = new string[]
            {
                "None",
                "Start with DateTime",
                "End with DateTime",
                "Custom",
                "Lowercase",
                "Uppercase"
            };
            FormatTypesBox.Items.AddRange(items);
            FormatTypesBox.SelectedItem = "None";
        }

        private void SelectedUser(List<UserMessage> messages) {
            AddUsersToComboBox(MessagesFilter.GetAllUsers(messages));
        }

        private void AddUsersToComboBox(List<string> users) {
            if (InvokeRequired) {
                Invoke((MethodInvoker)delegate () {
                    AddUsersToComboBox(users);
                });
            } else {
                var selecteditem = UsersComboBox.SelectedItem;
                UsersComboBox.Items.Clear();
                users.Add("All");
                var items = users.ToArray();
                UsersComboBox.Items.AddRange(items);
                UsersComboBox.SelectedItem = selecteditem;
            }
        }

        private void ClearUnactiveInGroup(GroupBox group) {
            foreach (var control in group.Controls) {
                if (control is GroupBox) {
                    if (CountFocusedInGroup((GroupBox)control) != 0)
                        continue;
                    ClearUnactiveInGroup((GroupBox)control);
                    continue;
                }
                if (((Control)control).Focused)
                    continue;
                if (control is TextBox) {
                    ((TextBox)control).Text = "";
                } else if (control is ComboBox) {
                    ((ComboBox)control).SelectedItem = "All";
                } else if (control is DateTimePicker) {
                    ((DateTimePicker)control).ResetText();
                } else { throw new ArgumentException(); }
            }
        }

        private int CountFocusedInGroup(GroupBox group) {
            return @group.Controls.Cast<object>().Count(control => ((Control)control).Focused);
        }

        private void FromDate_CloseUp(object sender, EventArgs e) {
            if (!MultyFilterCheck.Checked)
                ClearUnactiveInGroup(FiltersGroup);
        }

        private void ToDate_CloseUp(object sender, EventArgs e) {
            if (!MultyFilterCheck.Checked)
                ClearUnactiveInGroup(FiltersGroup);
        }
        private void SearchBox_TextChanged(object sender, EventArgs e) {
            if (!MultyFilterCheck.Checked)
                ClearUnactiveInGroup(FiltersGroup);
        }

        private void UsersComboBox_SelectionChangeCommitted(object sender, EventArgs e) {
            if (!MultyFilterCheck.Checked)
                ClearUnactiveInGroup(FiltersGroup);
        }

        private void Start_Click(object sender, EventArgs e) {
            Mobile.StartGenMessages();
        }

        private void Stop_Click(object sender, EventArgs e) {
            Mobile.StopGenMessages();
        }

        private void Charge_Click(object sender, EventArgs e) {
            if (Charge.Text == "Charge") {
                Mobile.Battery.Charger.StartCharging();
                Charge.Text = "Stop";
            } else if (Charge.Text == "Stop") {
                Mobile.Battery.Charger.StopCharging();
                Charge.Text = "Charge";
            }
        }

        private void OnChargeChanged(object sender, int charge) {
            if (InvokeRequired) {
                Invoke((MethodInvoker)delegate () {
                    OnChargeChanged(sender, charge);
                });
            }
            ChargeBar.Value = charge;
        }
    }
}

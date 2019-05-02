using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCorp.IMS.MobileLibrary {
    public class TaskSMSProvider : MessageGenerator {
        private Task _vTimerTask;

        public override void StartWork() {
            _vTimerTask = new Task(StartTimer);
            _vTimerTask.Start();
        }
    }
}

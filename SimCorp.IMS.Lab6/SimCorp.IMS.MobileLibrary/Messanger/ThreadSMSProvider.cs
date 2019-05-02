using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimCorp.IMS.MobileLibrary {
    public class ThreadSMSProvider : MessageGenerator {
        private Thread _vTimerThread;

        public override void StartWork() {
            _vTimerThread = new Thread(new ThreadStart(StartTimer));
            _vTimerThread.IsBackground = true;
            _vTimerThread.Start();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimCorp.IMS.MobileLibrary {
    public class ThreadCharging : Charging {
        private Thread _vChargeOn;
        private Thread _vChargeOff;

        public override void InitCharging() {
            _vChargeOn = new Thread(new ThreadStart(AddCharge));
            _vChargeOn.IsBackground = true;
            _vChargeOn.Start();
            _vChargeOff = new Thread(new ThreadStart(DecCharge));
            _vChargeOff.IsBackground = true;
            _vChargeOff.Start();
        }
    }
}

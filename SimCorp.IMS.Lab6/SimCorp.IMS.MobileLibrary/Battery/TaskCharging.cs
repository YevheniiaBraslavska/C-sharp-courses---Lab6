using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCorp.IMS.MobileLibrary {
    public class TaskCharging : Charging {
        private Task _vChargeOn;
        private Task _vChargeOff;
        public override void InitCharging() {
            _vChargeOn = new Task(AddCharge);
            _vChargeOn.Start();
            _vChargeOff = new Task(DecCharge);
            _vChargeOff.Start();
        }
    }
}

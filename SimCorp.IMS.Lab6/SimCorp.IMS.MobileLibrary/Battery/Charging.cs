using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace SimCorp.IMS.MobileLibrary {
    public class Charging {
        public delegate void ChargeHandler(object sender, int charge);
        public ChargeHandler OnChargeEvent;
        private bool IsCharging = false;
        private int _vCharge;
        public int Charge
        {
            get
            {
                return _vCharge;
            }
            set
            {
                lock (new Object()) {
                    if (value < 0) {
                        _vCharge = 0;
                    } else if (value > 100) {
                        _vCharge = 100;
                    } else {
                        _vCharge = value;
                    }
                }
            }
        }

        public Charging() {
            InitCharging();
        }

        public virtual void InitCharging() {

        }

        private void OnChargeOnTick(object sender, ElapsedEventArgs e) {
            Charge++;
            OnChargeEvent?.Invoke(this, Charge);
        }

        private void OnChargeOffTick(object sender, ElapsedEventArgs e) {
            Charge--;
            OnChargeEvent?.Invoke(this, Charge);
        }

        protected void AddCharge() {
            System.Timers.Timer chargeontimer = new System.Timers.Timer(500);
            chargeontimer.Elapsed += OnChargeOnTick;
            while (true) {
                if (IsCharging && !chargeontimer.Enabled) {
                    chargeontimer.Start();
                }
                if (!IsCharging && chargeontimer.Enabled) {
                    chargeontimer.Stop();
                }
            }
        }

        protected void DecCharge() {
            System.Timers.Timer chargeofftimer = new System.Timers.Timer(1000);
            chargeofftimer.Elapsed += OnChargeOffTick;
            while (true) {
                if (IsCharging && chargeofftimer.Enabled) {
                    chargeofftimer.Stop();
                }
                if (!IsCharging && !chargeofftimer.Enabled) {
                    chargeofftimer.Start();
                }
            }
        }

        public void SubscribeOnCharge(Action<object, int> func) {
            OnChargeEvent += new ChargeHandler(func);
        }

        public void StartCharging() {
            IsCharging = true;
        }

        public void StopCharging() {
            IsCharging = false;
        }
    }
}


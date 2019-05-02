using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimCorp.IMS.MobileLibrary;

namespace MobileLibrary.Test {
    [TestClass]
    public class ChargingTest {
        [TestMethod]
        public void ChargeCannotBeMoreThan100() {
            Charging Charger = new Charging();

            Charger.Charge = 110;

            Assert.AreEqual(100, Charger.Charge);
        }

        [TestMethod]
        public void ChargeCannotBeLessThan0() {
            Charging Charger = new Charging();

            Charger.Charge = -10;

            Assert.AreEqual(0, Charger.Charge);
        }

        [TestMethod]
        public void WHEN_ThreadChargeOn_THEN_ChargeInc() {
            ThreadCharging Charge = new ThreadCharging();
            Charge.Charge = 10;
            int act_charge = 0;
            bool hit = false;
            Charge.SubscribeOnCharge((obj, charge) => { act_charge = charge; hit = true; });

            Charge.StartCharging();

            while (!hit)
                Task.Delay(5).Wait();
            Assert.AreEqual(11, act_charge);
        }

        [TestMethod]
        public void WHEN_ThreadChargeOff_THEN_ChargeDec() {
            ThreadCharging Charge = new ThreadCharging();
            Charge.Charge = 10;
            int act_charge = 0;
            bool hit = false;
            Charge.SubscribeOnCharge((obj, charge) => { act_charge = charge; hit = true; });

            Charge.StopCharging();

            while (!hit)
                Task.Delay(5).Wait();

            Assert.AreEqual(9, act_charge);
        }

        [TestMethod]
        public void WHEN_TaskChargeOn_THEN_ChargeInc() {
            TaskCharging Charge = new TaskCharging();
            Charge.Charge = 10;
            int act_charge = 0;
            bool hit = false;
            Charge.SubscribeOnCharge((obj, charge) => { act_charge = charge; hit = true; });

            Charge.StartCharging();

            while (!hit)
                Task.Delay(5).Wait();
            Assert.AreEqual(11, act_charge);
        }

        [TestMethod]
        public void WHEN_TaskChargeOff_THEN_ChargeDec() {
            TaskCharging Charge = new TaskCharging();
            Charge.Charge = 10;
            int act_charge = 0;
            bool hit = false;
            Charge.SubscribeOnCharge((obj, charge) => { act_charge = charge; hit = true; });

            Charge.StopCharging();

            while (!hit)
                Task.Delay(5).Wait();

            Assert.AreEqual(9, act_charge);
        }
    }
}

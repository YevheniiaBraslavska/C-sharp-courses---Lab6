using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimCorp.IMS.MobileLibrary;

namespace MobileLibrary.Test {
    [TestClass]
    public class USBChargerTest {
        [TestMethod]
        public void ChargeValidOutputText() {
            var output = new FakeOutput();
            var charger = new USBCharger(output,1.5f,USBCharger.Ports.DedicatedChargingPort);

            charger.Charge();

            Assert.AreEqual("Charge with USBCharger\n", output.OutputResult);
        }
    }
}

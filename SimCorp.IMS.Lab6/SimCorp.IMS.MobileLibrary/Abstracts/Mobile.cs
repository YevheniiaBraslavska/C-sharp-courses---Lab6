using System;
using System.Collections.Generic;
using System.Text;

namespace SimCorp.IMS.MobileLibrary {
    public abstract class Mobile {
        public abstract ScreenAttribute Screen { get; }
        public abstract KeyboardAttribute Keyboard { get; }
        public abstract BatteryAttribute Battery { get; }
        public abstract SlotAttribute Slot { get; }
        public IPlayback PlaybackComponent { get; set; }
        public ICharger ChargingComponent { get; set; }
        internal SMSProvider SmsProvider { get; set; }
        public static double Id { get; private set; }
        public Storage Memory { get; set; }

        public void Play(object data) {
            PlaybackComponent.Play(data);
        }

        public void Charge() {
            ChargingComponent.Charge();
        }

        private void Show(IScreenImage screenImage) {
            Screen.Show(screenImage);
        }

        public double GetNumber() {
            return Id++;
        }

        public override string ToString() {
            var descriptionBuilder = new StringBuilder();
            descriptionBuilder.AppendLine($"Screen Type: {Screen.ToString()}");
            descriptionBuilder.AppendLine($"Keyboard Type: {Keyboard.ToString()}");
            descriptionBuilder.AppendLine($"Battery Type: {Battery.ToString()}");
            descriptionBuilder.AppendLine($"Slot Type: {Slot.ToString()}");
            return descriptionBuilder.ToString();
        }

        public void AddMessanger(EventHandler<SMSRecieverEventArgs> func) {
            SmsProvider.SMSRecieved += func;
        }

        public void AddOnCreatedEvent(EventHandler<SMSRecieverEventArgs> func) {
            SmsProvider.Generator.AddOnSmsCreated(func);
        }

        public void AddChargeEvent(Action<object, int> func) {
            Battery.Charger.SubscribeOnCharge(func);
        }

        public void StartGenMessages() {
            SmsProvider.Generator.StartGeneration();
        }

        public void StopGenMessages() {
            SmsProvider.Generator.StopGeneration();
        }
    }
}
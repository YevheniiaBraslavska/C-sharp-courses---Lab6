using System;
using System.Threading;
using System.Timers;

namespace SimCorp.IMS.MobileLibrary {
    public class BatteryAttribute {
        public enum Types {
            LitiumIon = 1,
            NickelMetalHydride = 2,
        }

        public int Capacity { get; }
        public Types Type { get; }
        public Charging Charger;

        public BatteryAttribute(Types type, int capacity, Charging charger) {
            Type = type;
            Capacity = capacity;
            Charger = charger;
        }

        public override string ToString() {
            return Type.ToString() + " Battery";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimCorp.IMS.MobileLibrary;

namespace SimCorp.IMS.MobileLibrary {
    public class SimCorpMobile : Mobile {
        private readonly MultyTouchScreen vScreen;
        private readonly OnScreenKeyboard vKeyboard;
        private readonly BatteryAttribute vBattery;
        private readonly SimCardSlot vSlot;
        public double Number { get; private set; }

        public override ScreenAttribute Screen
        {
            get
            {
                return vScreen;
            }
        }

        public override KeyboardAttribute Keyboard
        {
            get
            {
                return vKeyboard;
            }
        }

        public override BatteryAttribute Battery
        {
            get
            {
                return vBattery;
            }
        }

        public override SlotAttribute Slot
        {
            get
            {
                return vSlot;
            }
        }

        public SimCorpMobile() {
            Number = GetNumber();

            vScreen = new MultyTouchScreen(10);

            var layouts = new List<Layout>();

            //Layout of letters
            var set = new List<char>();
            set.AddRange(Enumerable.Range('A', 26).Select(x => (char)x));
            var layout = new Layout(set);
            layouts.Add(layout);

            //Layout of numbers
            set = new List<char>();
            set.AddRange(Enumerable.Range('1', 9).Select(x => (char)x));
            layouts.Add(layout);

            vKeyboard = new OnScreenKeyboard(layouts);

            vBattery = new BatteryAttribute(BatteryAttribute.Types.LitiumIon, 2500, new TaskCharging());
            vSlot = new SimCardSlot(SimCardSlot.FormFactors.MicroSim, 100, 200);

            SmsProvider = new SMSProvider(new TaskSMSProvider());
            Memory = new Storage();
        }
    }
}

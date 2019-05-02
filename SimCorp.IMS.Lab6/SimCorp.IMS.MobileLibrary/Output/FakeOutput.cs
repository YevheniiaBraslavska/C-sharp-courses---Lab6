using SimCorp.IMS.MobileLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCorp.IMS.MobileLibrary {
    public class FakeOutput : IOutput {
        public string OutputResult { get; set; }

        public FakeOutput() {
            OutputResult = "";
        }

        public void Write(string text) {
            OutputResult = text;
        }

        public void WriteLine(string text) {
            OutputResult = text + "\n";
        }

        public void Clean() { }
    }
}

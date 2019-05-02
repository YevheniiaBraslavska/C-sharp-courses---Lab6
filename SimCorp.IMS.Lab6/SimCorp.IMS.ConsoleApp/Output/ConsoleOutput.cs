using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCorp.IMS.MobileLibrary {
    public class ConsoleOutput : IOutput {
        public void Write(string text) {
            Console.WriteLine(text);
        }

        public void WriteLine(string text) {
            Console.WriteLine(text);
        }

        public void Clean() { }
    }
}

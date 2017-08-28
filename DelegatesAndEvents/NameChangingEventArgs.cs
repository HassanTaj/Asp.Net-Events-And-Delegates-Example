using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents {
   
/// step  2. CREATE CUSTOM EVENT ARGUMENT CLASS IF NEDDED 
/// (this is required when you want to make it do things your way)
// this class will inherit from EventArgs or any of its Child class
    class NameChangingEventArgs : EventArgs {

        private string oldName;
        public string OldName {
            get { return oldName; }
           // set { oldName = value; }
        }

        private string newName;
        public string NewName {
            get { return newName; }
           // set { newName = value; }
        }

        public NameChangingEventArgs() { }
        public NameChangingEventArgs(string oName , string nName) {
            this.oldName = oName;
            this.newName = nName;
        }

    }
}

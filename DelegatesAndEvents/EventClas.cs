using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents {
    class EventClas {

        public event myEventHandlerDele valueChanged;

        private string myVal;

        public string MyVal {
            set {
                myVal = value;
                // raise the event
                this.valueChanged(myVal);
            }
        }

    }
}

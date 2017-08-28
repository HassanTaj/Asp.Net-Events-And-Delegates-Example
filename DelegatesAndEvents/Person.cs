using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents {
    class Person {


        ///  Step 1. DECLARE AN EVERNT
        public event EventHandler<EventArgs> NameChangedEvent;
        public event EventHandler<NameChangingEventArgs> NameChangingEvent;


        // calls properties
        private int age;

        public int Age {
            get { return age; }
            set { age = value; }
        }

        private string name;

        public string Name {
            get { return name; }
            set {

                ///Step 4. WRITE A DEFAULT EVENT HANDLER (this is only required if you some how don't want to handle the evernt)
                // professionally its called subscribing to an event handler
                // and if you don't know how to use lambda expression 
                // just write this.NameOfTheEvent += means subscribe and press TAB

                // NOTE : if you don't use default event handlers here then you must handle it else it will throw nullRefferance exception
                //this.NameChangedEvent += Person_NameChangedEvent;
                //this.NameChangingEvent += Person_NameChangingEvent;

                // but when you know lambda
                // you can also do this 

                this.NameChangedEvent += (sender, aggs) => { };
                this.NameChangingEvent += (oldName, newName) => { };

                //  CustomEventClass(source, new EventArgs

                ///step 3. RAIS THE EVENT
                NameChangingEvent(this, new NameChangingEventArgs(name, value));
                name = value;
                ///step 3. RAIS THE EVENT
                // event (s,e)
                NameChangedEvent(this, new EventArgs());
            }
        }

        // default event handlers
        //private void Person_NameChangingEvent(object sender, NameChangingEventArgs e) { }
        //private void Person_NameChangedEvent(object sender, EventArgs e) { }
        // /////////////////////

        private string address;

        public string Address {
            get { return address; }
            set { address = value; }
        }

    }
}

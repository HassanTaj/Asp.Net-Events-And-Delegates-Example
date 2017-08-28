using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents {

    /// ////////////////////////////////////////////
    ///  just as i have said before Delegates are not defined inside a class
    ///  they are defined in a namespace

    // this can be an example of action delegate that doesn't return anything
    
        // remember a simple delegate doesn't have any return type 
    public delegate void SimpleDelegateWithOutPram<T>(T num1 , T num2, out T result); 

    // this can also be done but  i'll use a delegate that returns something
    public delegate int SimpleDelegate(int num1, int num2);


    //class SimpleDelegate {
    //}
}

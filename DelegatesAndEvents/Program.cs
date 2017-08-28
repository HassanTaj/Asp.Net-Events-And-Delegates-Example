//#define LOCAL_DELEGATE_DEMO
//#define SIMPLE_DELEGATE_DEMO
//#define GENERIC_DELEGATE_DEMO
//#define ACTION_n_FUNC_DELEGATE_DEMO
//#define LOCAL_EVENT_HANDLING_DEMO
//#define EVENT_HANDLING_WITH_4_STEPS_DEMO
//#define BONOUS

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents {
    
    // delegates and eventHandlers are defined 
    // in the namespace rather than inside the class

    // defining a local delegate 
    public delegate int numberFunctionDelegate(int number);  // this is a local delegate that takes 1 argument and returns 1 result
    // defining a local Event Handler Delegate
    public delegate void myEventHandlerDele(string str);
    class Program {
        static void Main(string[] args) {


            #region BONOUS STUFF DEMO
#if BONOUS

            //method to return multiple values from a function
            double a = 9.0, square, squareRoot;
            double b = 3.0, squareB, squareRootB;
            double c = 12.0, squareC, squareRootC;

            SquareAndRoot(a, out square, out squareRoot);
            SquareAndRoot(b, out squareB, out squareRootB);
            SquareAndRoot(c, out squareC, out squareRootC);

            Console.WriteLine("Square of the number {0} = {1} and its Square Root = {2}", a, square, squareRoot);
            Console.WriteLine("Square of the number {0} = {1} and its Square Root = {2}", b, squareB, squareRootB);
            Console.WriteLine("Square of the number {0} = {1} and its Square Root = {2}", c, squareC, squareRootC);

            //method to calculate average of n Numbers
            int numberOfParams = 0;
            Console.Write("Enter number of things you would like take average of : ");
            while (!Int32.TryParse(Console.ReadLine(), out numberOfParams)) {
                Console.Write("Enter A number please : ");
            }
            GetN_Numbers(numberOfParams);

#endif
            #endregion

            /*--------------------------------------------------------------------------------------------------------*/

            #region ALL TYPES OF EVENT HANDELING

            #region  Events Discription
            /// ///////////////////////////////////////////////////////////////
            //            Events Discription
            /// ///////////////////////////////////////////////////////////////
            /// Steps for creating an event
            ///  There are 4
            /// . Declare an event
            /// . Create custom event argument class if needed
            /// . Raise the event
            /// . Write a default event handler.
            /// 
            /// Data type of an event handler is delegate( System.EventHandler )
            ///   And event args should be EventArgs or one of its is child class.
            ///   PriceChanged(source, new EventArgs());
            /// ///////////////////////////////////////////////////////////////
            #endregion

            #region EVENT HANDLING PRO WAY DEMO WITH 4 STEPS
#if EVENT_HANDLING_WITH_4_STEPS_DEMO

            /// /////////////////////////////////////////////////////////
            //      WE HAVE 4 STEPS IN THIS WAY 
            /// ////////////////////////////////////////////
            /// 1. DECLARE AN EVERNT
            /// 2. CREATE CUSTOM EVENT ARGUMENT CLASS IF NEDDED and that class will inherit from EventArgs or any of its Child class
            /// (this is required when you want to make it do things your way).
            /// 3. RAIS THE EVENT
            /// 4. WRITE A DEFAULT EVENT HANDLER (this is only required if you some how don't want to handle the evernt)
            /// 
            ///  For this example we will create 
            ///  a. A PERSON class 
            ///  b. With Two even nameChangedEvent and Name ChangingEvent
            ///  c. A NameChangingEvent Args Class
            ///  d. default event handlers
            ///  e. we'll  raise the event and  then handle the event 
            ///  
            /// Note : We'll use Builtin EventHandler (its a builtin generic delegate used to handle events)
            /// //////////////////////////////////////////////////////////

            // create object of any class that has events 

            Person person = new Person();

            //Step 5 : handle the events here

            // i'm lazy to do that long shit
            person.NameChangedEvent += (sender, eventArgs) => {
                Console.WriteLine(" Name Changed ");
            };
            person.NameChangingEvent += (s, e) => {
                Console.WriteLine(" {0} ----> {1} ", e.OldName, e.NewName);
            };

            person.Name = "Hassan";
            person.Name = "Salman";
            person.Name = "Waseen";
            person.Name = "Usman";
            person.Name = "Ahmer";

#endif
            #endregion

            #region LOCAL EVENT HANDLING DEMO
#if LOCAL_EVENT_HANDLING_DEMO

            // create an object of the cals with the event
            EventClas myEvt = new EventClas();

            // subscribe to the event 
            myEvt.valueChanged += new myEventHandlerDele(MyEvtClas_valueChanged);

            // we can also do something like this
            //myEvt.valueChanged += (sender) => {
            //    Console.WriteLine("Lambda Handle ->> {0}", sender);
            //};

            string str;
            while (true) {
                Console.Write(" Enter something : ");
                str = Console.ReadLine();
                if (str.Equals("exit"))
                    break;
                else
                    myEvt.MyVal = str;
            }

 



#endif
            #endregion

            #endregion

            /*--------------------------------------------------------------------------------------------------------*/

            #region ALL TYPE OF  DELEGATE DEMOS

            #region Delegates Discription
            /// ///////////////////////////////////////////////////////////////
            //             Delegate Discription
            /// //////////////////////////////////////////////////////////////
            ///  Delegate is a type to encapsulate a method.
            ///  It's used to represent a method by a variable.
            ///  
            ///  Types of delegate
            ///  Uni cast.
            ///  Multi cast.
            ///  
            ///  Action delegate is used to represent a method with
            ///  Void return type.
            ///  
            ///  Func delegate is used to represent methods with at least
            ///  One return type and will return something.
            ///         Also
            ///  Delegates are like callback functions  in other languages
            /// 
            /// ///////////////////////////////////////////////////////////////
            #endregion

            #region  ACTION AND FUNC DELEGATE DEMO
#if ACTION_n_FUNC_DELEGATE_DEMO

            //  Action delegate is used to represent a method with
            //  Void return type.
            // in simple action delegate doesn't return a value 
            Action a1 = () => Console.WriteLine("It is a test");
            Action<string> a2 = (msg) => Console.WriteLine(msg);  
            Action<string, int> a3 = (msg, counter) => {
                for (int i = 1; i <= counter; i++) {
                    Console.WriteLine(msg);
                }
            };

            // call to the functions
            a1();
            a2("the Message goes here");
            a3("just a random repeting message", 5);

            //  Func delegate is used to represent methods with at least
            //  One return type and will return something
            // in simple func delegate will always return at least one value
            Func<int> f1 = () => 10;  // this returns an int
            Func<string, int> f2 = str => str.Length; // this will return a string and an int
            Func<string, int, int> f3 = (str, num) => str.Length * num; // this just is a fucking dumb example

#endif
            #endregion

            #region Generic Delegate Demo
#if GENERIC_DELEGATE_DEMO

            double dnumA = 6;
            double dnumB = 3;
            GenericDelegate<string> ConcatDelegate = new GenericDelegate<string>(CombinStrings);
            //ConcatDelegate <double> avg = AverageOfTwo; // this can't be done  because the types don't match

            Console.WriteLine("Concatination of two strings {0}+{1} = {2}", dnumA, dnumB, ConcatDelegate(dnumA.ToString(), dnumB.ToString()));

            GenericDelegate<double>  mathsDelegate = AverageOfTwo;
            Console.WriteLine("Average of two numbers {0} + {1} / 2 = {2}",dnumA,dnumB, mathsDelegate(dnumA,dnumB));
            mathsDelegate = ModOFTwo;
            Console.WriteLine("Mod of two numbers {0} % {1} = {2}", dnumA, dnumB, mathsDelegate(dnumA, dnumB));

            // this is called an annonymous delegate
            GenericDelegate<string> myDelegate = delegate (string val,string val2){ return val + val2; };

            // variation in lambda is 
            GenericDelegate<string> myDeleWLambda = (thing1,thing2) => { return thing1 + thing2; };
            GenericDelegate<int> integerLambdaDelegate = (thing1, thing2) => { return thing1 * thing2; };

#endif
            #endregion

            #region  Simple Delegate Demo
#if SIMPLE_DELEGATE_DEMO

            int numA = 6;
            int numB = 2;

            SimpleDelegate simpDele = new SimpleDelegate(Add);
            Console.WriteLine("{0} + {1} = {2} ", numA, numB, simpDele(numA, numB));

            simpDele += Mul; // changing function on the fly 
            Console.WriteLine("{0} x {1} = {2} ", numA, numB, simpDele(numA, numB));

            simpDele += Div; // again changing value of delegate to devision function
            Console.WriteLine("{0} / {1} = {2} ", numA, numB, simpDele(numA, numB));

            simpDele += Sub;// and again changing it 
            Console.WriteLine("{0} - {1} = {2} ", numA, numB, simpDele(numA, numB));

            // a dictionary of FUnctions 
            Dictionary<string, SimpleDelegate> simpleDelegateFuncs = new Dictionary<string, SimpleDelegate>();
            simpleDelegateFuncs.Add("Addition       : ", Add);
            simpleDelegateFuncs.Add("Multiplication : ", Mul);
            simpleDelegateFuncs.Add("Subtraction    : ", Sub);
            simpleDelegateFuncs.Add("Division       : ", Div);

            // using usual method
            //foreach (KeyValuePair<string, SimpleDelegate> pair in simpleDelegateFuncs) {
            //    Console.WriteLine("{0} of {1} and {2} = {3}", pair.Key, numA, numB, pair.Value(numA, numB);
            //}

            // using Lambda expression 
            simpleDelegateFuncs.ToList().ForEach((pair) => Console.WriteLine("{0} of {1} and {2} = {3}", pair.Key, numA, numB, pair.Value(numA, numB)));
    
            // there is no differen in output just saves your time this way
#endif
            #endregion

            #region Local Delegate Demo
#if LOCAL_DELEGATE_DEMO

            numberFunctionDelegate nf;

            nf = Square;
            Console.WriteLine(" Square of 5 is {0} ", nf(5));
            nf = Cube;
            Console.WriteLine(" Cube of 5 is {0} ", nf(5));

            List<numberFunctionDelegate> functions = new List<numberFunctionDelegate>();
            functions.Add(Square);
            functions.Add(Cube);

            //// simple way
            foreach (var function in functions) {
                Console.WriteLine(function(5));
            }

            // dictionary way with lambda expression
            Dictionary<string, numberFunctionDelegate> functionDictionary = new Dictionary<string, numberFunctionDelegate>();
            functionDictionary.Add("Square", Square);
            functionDictionary.Add("Cube", Cube);

            //functionDictionary.ToList<KeyValuePair<string, numberFunction>>().
            //    ForEach((pair) => Console.WriteLine(pair.Key+" : "+ pair.Value(5)));

            functionDictionary.ToList().ForEach((pair) => Console.WriteLine(pair.Key + " : " + pair.Value(5)));

            //foreach (KeyValuePair<string, numberFunctionDelegate> item in functionDictionary) {

            //}

            //foreach (var key in functionDictionary.Keys) {
            //    foreach (var val in functionDictionary.Values) {

            //    }
            //}

#endif
            #endregion

            #endregion
            Console.ReadKey();
        }

        #region Event Handler Implimentation METODS
        private static void MyEvtClas_valueChanged(string newValue) {
            Console.WriteLine("The value changed to ----> {0}", newValue);
        }
        #endregion

        #region METHODS FOR DELEGATES
        /// /////////////////////////////////////////////////////
        ////            METHODS FOR  delegates
        /// //////////////////////////////////////////////////// 
        /// 

        //----------- Methods used in Generic Delegate Demo
        /* methods that are callable by  delegate with two Generic parameter */

        static string CombinStrings(string a, string b) { return a + b; }
        static double AverageOfTwo(double a, double b) { return a + b / 2; }
        static double ModOFTwo(double a, double b) { return a % b; }

        //----------- Methods used in Simple Delegate Demo
        /* methods that are callable by  delegate with two  parameter */
        static int Add(int a, int b) { return a + b; }
        static int Mul(int a, int b) { return a * b; }
        static int Div(int a, int b) { return a / b; }
        static int Sub(int a, int b) { return a - b; }
        /*--------------------------------------------------------*/

        //----------- Methods used in Local Delegate Demo
        /* methods that are callable with delegate with one parameter */
        static int Square(int number) { return number * number; }
        static int Cube(int number) { return number * number * number; }
        /*-------------------------------------------------------*/
        /// ////////////////////////////////////////////////////
        #endregion

        #region BONOUS THINGS 
        /// ///////////////////////////////////////////////////
        //    Todays Bonus 
        /// ///////////////////////////////////////////////////

        // how to return a value using parameters and without return type so you can return multiple values
        static void SquareAndRoot(double a,out double square, out double squareRoot) {
            square = a * a;
            squareRoot = Math.Sqrt(a);
        }

        // a method that can calculate the average of N numbers
        static double AverageOfMany(params double[] numbs) {
            double totalAvg = 0;
            int divisor = numbs.Length;
            foreach (var number in numbs) {
                totalAvg += number;
            }
            return totalAvg / divisor;
        }
        static void GetN_Numbers(int howManyNumbers) {
            int count = 1;
            int index = 0;
            double[] nNumbers = new double[howManyNumbers];
            nNumbers.ToList().ForEach(
                element => {
                    double value;
                    Console.Write("Enter a value for item at {0} index :", count);
                    while (!Double.TryParse(Console.ReadLine(), out value)) {
                        Console.Write("Enter Correct value for item at {0} index : ", count);
                    }
                    nNumbers[index] = value;
                    count++;
                    index++;
                });
            double resultOfnNumbers = AverageOfMany(nNumbers);
            Console.WriteLine("Average of {0} numbers is = {1} ", nNumbers.Length, resultOfnNumbers);
        }
   
        #endregion
    }
}
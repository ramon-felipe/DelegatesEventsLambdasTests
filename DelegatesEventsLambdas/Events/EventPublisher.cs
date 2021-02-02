using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesEventsLambdas
{
    public delegate void myEventHandler(string value);

    class EventPublisher
    {
        private string myVar;
        public string MyVar
        {
            set 
            { 
                myVar = value;
                ValueChanged(myVar);
            }
        }

        public event myEventHandler ValueChanged;

        public static void Obj_valueChanged(string value)
        {
            Console.WriteLine("The value changed to {0}", value);
        }

        public static void Obj_valueChanged2(string value)
        {
            Console.WriteLine("xxxxxxxxxxxxxxxx  {0}  xxxxxxxxxxxxxxxx  ", value);
        }

    }
}

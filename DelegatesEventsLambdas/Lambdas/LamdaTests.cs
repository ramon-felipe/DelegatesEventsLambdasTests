using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesEventsLambdas.Lambdas
{
    public delegate int MyDelegate(int x);
    public delegate void MyDelegate2(int x, string prefix);
    public delegate bool ExprDelegate(int x);
    public delegate void MyEventHandler(string value);

    class LambdaTests
    {
        private string _val;
        public event myEventHandler ValueChanged;

        public string Val 
        {
            get { return _val; }
            set 
            {
                _val = value;
                ValueChanged(_val);
            } 
        }

        public static void Test1()
        {
            MyDelegate foo = (x) => x * x;
            Console.WriteLine("Result {0}", foo(5));

            foo = (x) => x * 10;
            Console.WriteLine("Result {0}", foo(5));

            MyDelegate2 bar = (x, y) =>
            {
                Console.WriteLine("Arguments x:{0} and y:{1}", x, y);
            };

            bar(25, "Some string");

            ExprDelegate baz = (x) => x > 10;
            Console.WriteLine("Baz with 5: {0}", baz(5));
            Console.WriteLine("Baz with 10: {0}", baz(15));
        }
    }
}

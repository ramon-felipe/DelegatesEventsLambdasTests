using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesEventsLambdas
{

    public delegate void MyDelegate3(string a);
    
    class EventPublisher2
    {
        public event MyDelegate3 MyEvent;

        public void MyFuncTest1(string a) => Console.WriteLine("MyFuncTest1 >>> {0}", a);
        public void MyFuncTest2(string a) => Console.WriteLine("MyFuncTest2 {0} <<<", a);
        public void MyFuncTest3() => Console.WriteLine("MyFuncTest3");


        public void ActivateEvent(string a)
        {

            MyEvent(a);
        }
    }

    public class EventPublisherNet
    {
        public string MyClassProperty { get; set; }
        public EventPublisherNet(string a)
        {
            MyClassProperty = a;
        }

        public void OnActivateEvent(EventPublisherNetArgs e)
        {
            MyEvent(this, e);
        }

        public event EventHandler<EventPublisherNetArgs> MyEvent;
    }

    public class EventPublisherNetArgs : EventArgs
    {
        public string MyProperty { get; set; }
        public string MyProperty2 { get; set; }
    }
}

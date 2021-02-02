using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesEventsLambdas
{
    class MyDelegateClass
    {
        public string InstanceMethod1(int arg1, int arg2)
        {
            return ((arg1 + arg2) * arg1).ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesEventsLambdas
{

    public delegate int MyIntDelegate(int n, ref int n2);

    class DelegateTests
    {
        public DelegateTests()
        {
            var num = 20;
            MyIntDelegate func = CalcInt1;
            var r = func(10, ref num);

            if (r > 10)
            {
                var num2 = 300;
                func += CalcInt2;
                func += delegate (int n, ref int n2)
                {
                    return n + n2;
                };

                r = func(10, ref num2);
            }

            Console.WriteLine("Resultado {0}", r);
        }

        private static int CalcInt1(int n, ref int n2)
        {
            n2 += n;
            return n2;
        }

        private static int CalcInt2(int n, ref int n2)
        {
            n2 = 100;
            return 1;
        }

    }
}

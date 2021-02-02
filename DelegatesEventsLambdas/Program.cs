using DelegatesEventsLambdas.Events;
using DelegatesEventsLambdas.Lambdas;
using System;

namespace DelegatesEventsLambdas
{
    public delegate string MyDelegate(int arg1, int arg2);
    public delegate string MyDelegate2(int arg1, ref int arg2);

    class Program
    {

        
        static void Main()
        {
            var p = new Program();
            p.TestLambda2();
        }

        private void TestLambda2()
        {
            var pb = new LambdaPigBank();
            string word;

            pb.BalanceChanged += (amount) => Console.WriteLine("Balance changed! {0}", amount);
            pb.BalanceChanged += (amount) =>
            {
                if (amount > 500m)
                {
                    Console.WriteLine("You reached your goal ({0})!", 500m);
                }
            };

            do
            {
                Console.WriteLine("Inform your amount: ");
                word = Console.ReadLine();
                if (word == "exit") return;

                if (decimal.TryParse(word, out decimal amount))
                    pb.Balance += amount;
                else
                    Console.WriteLine("Not a valid amount!!");

            } while (true);
        }

        private void TestLambda1()
        {
            var l = new LambdaTests();
            l.ValueChanged += (x) =>
            {
                Console.WriteLine("Value changed {0}", x);
            };

            l.Val = "aa";
        }

        private void TestEvent3()
        {
            var pb = new PigBank();
            var bl = new BalanceLogger();
            var bw = new BalanceWatcher(300m);
            string word;

            pb.BalanceChanged += bl.BalanceLog;
            pb.BalanceChanged += bw.BalanceWatch;

            do
            {
                Console.WriteLine("Inform your amount: ");
                word = Console.ReadLine();
                if (word == "exit") return;

                if (decimal.TryParse(word, out decimal amount))
                    pb.ChangeBalance(amount);
                else
                    Console.WriteLine("Not a valid amount!!");

            } while (true);
        }

        private void TestEvent()
        {
            var eventPublisher = new EventPublisherNet("hihihi");
            eventPublisher.MyEvent += Func;
            eventPublisher.MyEvent += (object sender, EventPublisherNetArgs e) =>
            {
                Console.WriteLine("Anonymous delegate: The {0} class changed {1}", sender, e.MyProperty);
                Environment.ExitCode = 0;
            };

            var eventPublisherArgs = new EventPublisherNetArgs()
            {
                MyProperty = eventPublisher.MyClassProperty
            };

            eventPublisher.OnActivateEvent(eventPublisherArgs);
        }

        private void Func(object sender, EventPublisherNetArgs e)
        {
            Console.WriteLine("The {0} class changed {1}", sender, e.MyProperty);
        }

        private static void TestEvent2()
        {
            var eventPublisher = new EventPublisher2();
            eventPublisher.MyEvent += eventPublisher.MyFuncTest1;
            eventPublisher.MyEvent += eventPublisher.MyFuncTest2;

            eventPublisher.ActivateEvent("XXX");
        }
    }
}

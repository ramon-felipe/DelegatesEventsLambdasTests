using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesEventsLambdas.Lambdas
{
    class LambdaPigBank
    {
        private decimal balance;

        public decimal Balance
        {
            get { return balance; }
            set { 
                balance = value;
                BalanceChanged(value);
            }
        }

        public delegate void BalanceEventHandler(decimal amount);
        public event BalanceEventHandler BalanceChanged;
    }

    public class LambdaBalanceLogger
    {
        public void LogBalance(decimal amount)
        {
            Console.WriteLine("Your balance is: {0}", amount);
        }
    }

    public class LambdaBalanceWatcher
    {
        public decimal Goal { get; set; }
        public LambdaBalanceWatcher(decimal goal)
        {
            Goal = goal;
        }
        public void WatchBalance(decimal amount)
        {
            if (amount > Goal)
            {
                Console.WriteLine("You reached your goal! ({0})", Goal);
            }
        }
    }
}

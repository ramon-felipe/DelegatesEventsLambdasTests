using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesEventsLambdas.Events
{
    public class PigBank
    {
        private decimal balance;

        public decimal Balance
        {
            get { return balance; }
            private set { 
                balance = value;
                BalanceChanged(value);
            }
        }

        public void ChangeBalance(decimal value)
        {
            Balance += value;
        }

        public delegate void BalanceEventHandler(decimal value);
        public event BalanceEventHandler BalanceChanged;
    }

    class BalanceLogger
    {
        public void BalanceLog(decimal value)
        {
            Console.WriteLine("The balance was changed to {0}", value);
        }
    }

    class BalanceWatcher
    {
        public decimal Goal { get; private set; }

        public BalanceWatcher(decimal goal)
        {
            Goal = goal;
        }

        public void BalanceWatch(decimal value)
        {
            if (value >= Goal)
                Console.WriteLine("You reached your goal ({0})!", Goal);
        }
    }
}

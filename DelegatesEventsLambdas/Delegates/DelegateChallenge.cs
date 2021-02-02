using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesEventsLambdas
{
    public delegate void CalcShipDeletage(decimal price, ref decimal fee);

    public class DelegateChallenge
    {

        public static void CalculateShip()
        {
            CalcShipDeletage calcShipDelegate;

            do
            {
                Console.WriteLine("What is the destination zone?");
                string inputDest;
                if ((inputDest = Console.ReadLine()) == "exit") break;
                var dest = ShippingDestination.GetDestinationInfo(inputDest);

                if (dest != null)
                {
                    Console.WriteLine("What is the item price?");
                    string inputPrice = Console.ReadLine();
                    var itemPriceResult = decimal.TryParse(inputPrice, out decimal itemPrice);

                    if (itemPriceResult)
                    {
                        calcShipDelegate = dest.CalcFees;

                        if (dest.IsHighRisk)
                        {
                            calcShipDelegate += delegate (decimal thePrice, ref decimal itemFee)
                            {
                                itemFee += 25.0m;
                            };
                        }

                        decimal theFee = 0.0m;
                        calcShipDelegate(itemPrice, ref theFee);

                        Console.WriteLine("The sheeping fees are: {0}", theFee);
                    }
                }
                else
                {
                    Console.WriteLine("Hmm, you seem to have entered an unknows destination.");
                }
            } while (true);
        }
    }

    public abstract class ShippingDestination
    {
        public bool IsHighRisk { get; set; }
        public virtual void CalcFees(decimal price, ref decimal fee) { }

        public static ShippingDestination GetDestinationInfo(string dest)
        {
            if (dest.Equals("zone1"))
                return new Dest_Zone1();

            if (dest.Equals("zone2"))
                return new Dest_Zone2();

            if (dest.Equals("zone3"))
                return new Dest_Zone3();

            if (dest.Equals("zone4"))
                return new Dest_Zone4();

            return null;
        }
    }

    public class Dest_Zone1 : ShippingDestination
    {
        public Dest_Zone1()
        {
            IsHighRisk = false;
        }

        public override void CalcFees(decimal price, ref decimal fee)
        {
            fee = price * .25m;
        }
    }
    public class Dest_Zone2 : ShippingDestination
    {
        public Dest_Zone2()
        {
            IsHighRisk = true;
        }

        public override void CalcFees(decimal price, ref decimal fee)
        {
            fee = price * .12m;
        }
    }
    public class Dest_Zone3 : ShippingDestination
    {
        public Dest_Zone3()
        {
            IsHighRisk = false;
        }

        public override void CalcFees(decimal price, ref decimal fee)
        {
            fee = price * .08m;
        }
    }
    public class Dest_Zone4 : ShippingDestination
    {
        public Dest_Zone4()
        {
            IsHighRisk = true;
        }

        public override void CalcFees(decimal price, ref decimal fee)
        {
            fee = price * .04m;
        }
    }
}

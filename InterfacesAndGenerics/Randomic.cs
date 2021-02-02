using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesAndGenerics
{
    class Randomic : IRandomizable
    {
        public double GetRandomNum(double upperBound)
        {
            var rnd = new Random();
            var seed = rnd.NextDouble();

            return seed * upperBound;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeProject
{
    class Person
    {
        public Person()
        {
            Console.WriteLine("First constructor");
        }

        public Person(int idade): this()
        {
            Console.WriteLine("Age: {0}", idade);
        }

        public Person(string name): this(31)
        {
            Console.WriteLine("Second constructor... \nPerson name: {0}", name);
         }
    }
}

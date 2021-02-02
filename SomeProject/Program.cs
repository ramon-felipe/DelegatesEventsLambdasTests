using System;
using System.Text.RegularExpressions;

namespace SomeProject
{
    class Program
    {
        private static string myJob;
        /// <summary>
        /// Test method
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <exception cref="ArgumentNullException">Exceção a ser lançada</exception>
        static void Main(string[] args)
        {
            myJob = "x";
            var pp = myJob;

            Test1(1, ")");
            double root = Math.Sqrt(16);

            Console.WriteLine("Root: {0}", root);

            var x = "38030457898";
            var r = Regex.Replace(x, @"(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4");
            Console.WriteLine(r);

            // ----

            var p = new Person();
            var p2 = new Person("Nah");

        }

        /// <summary>
        /// testando...
        /// </summary>
        /// <param name="n1">veja em <see cref="int"/></param>
        /// <param name="a">olha ali <see cref="string"/> st<seealso cref="String"/> a<paramref name="n1"/></param>
        /// <exception cref="ArgumentNullException">Excecion</exception>
        private static void Test1(int n1, string a)
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

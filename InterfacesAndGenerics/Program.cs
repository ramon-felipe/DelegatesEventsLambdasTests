using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace InterfacesAndGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee("Ramon 1", 39),
                new Employee("Ramon 2", 34),
                new Employee("Ramon 3", 33),
                new Employee("Ramon 4", 34)
            };

            Console.WriteLine("empList count: {0}", empList.Count);
            empList.Sort();

            foreach (var emp in empList)
            {
                Console.WriteLine("Name: {0} Salary: {1}", emp.Name, emp.Salary);
            }

        }
        private static void Test1()
        {
            int? n1 = null;
            int n2 = 2;
            int n3 = n1 ?? 100;
            int? n4 = null;

            n4 ??= n2;
            n4 ??= 100;

        }

        private static void Test2()
        {
            var s = new Sheet("doc");

            s.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                Console.WriteLine("Document property changed: {0}", e.PropertyName);
            };

            s.DocName = "Teste";
        }

        private static void Test3()
        {
            var r = new Randomic();
            string n;

            do
            {
                Console.WriteLine("Enter a number for the upper bound:");
                n = Console.ReadLine();

                if (double.TryParse(n, out double upperBound))
                    Console.WriteLine("Random number between 0 and {0}: {1}", upperBound, r.GetRandomNum(upperBound));

            } while (!n.Equals("exit"));
        }
    }



    public interface IStorable
    {
        void Load();
        void Save();
    }

    // planilha = document
    class Sheet : IStorable
    {
        public Sheet(string docName)
        {
            Console.WriteLine("Initializing: {0}", docName);
        }

        private string docName;

        public string DocName
        {
            get => docName;
            set
            {
                docName = value;
                NotifyPropChanged("DocName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropChanged(string propName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }

    // imagem = drawing != document
    class Imagem : IStorable
    {
        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}

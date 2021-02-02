using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesAndGenerics
{
    class Employee : IComparable<Employee>
    {
        public string Name { get; set; }
        public int Salary { get; set; }

        public Employee(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }

        public int CompareTo(Employee other)
        {
            if (this.Salary > other.Salary)
                return 1;
            if (this.Salary == other.Salary)
                return 0;

            return -1;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalRegister
{
    internal class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }

        public Employee(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }

        public void ChangeSalary(int newSalary) { 
            this.Salary = newSalary;
        }
    }
}

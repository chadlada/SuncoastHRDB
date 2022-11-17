using System;
using System.Collections.Generic;
using System.Linq;

namespace SuncoastHRDB
{
    public class EmployeeDatabase
    {
        private List<Employee> employees = new List<Employee>();

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        public void AddEmployee(Employee newEmployee)
        {
            employees.Add(newEmployee);
        }

        public Employee FindOneEmployee(string name)
        {
Employee foundEmployee = employees.FirstOrDefault(employees => employees.Name == name);
return foundEmployee;
        }
    }
}
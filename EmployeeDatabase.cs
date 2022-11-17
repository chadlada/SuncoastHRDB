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
    }
}
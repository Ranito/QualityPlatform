using System.Collections.Generic;

namespace EmployeeTracker
{
    public class EmployeeService
    {
        private readonly List<IEmployee> _employees = new();

        public void AddEmployee(IEmployee employee)
        {
            _employees.Add(employee);
        }

        public IEnumerable<IEmployee> GetAll()
        {
            return _employees;
        }
    }
}

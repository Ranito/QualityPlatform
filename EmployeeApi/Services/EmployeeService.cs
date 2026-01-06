using System.Collections.Generic;
using System.Linq;
using EmployeeApi.Data;
using EmployeeApi.Models;

namespace EmployeeApi.Services
{
    public class EmployeeService
    {
        private readonly EmployeeDbContext _context;

        public EmployeeService(EmployeeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
    }
}

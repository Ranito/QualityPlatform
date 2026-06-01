using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Services;
using EmployeeApi.Models;


namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _service;

        public EmployeesController(EmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _service.GetById(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _service.Add(employee);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _service.GetById(id);

            if (employee == null)
                return NotFound();

            _service.Delete(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee updatedEmployee)
        {
            var employee = _service.GetById(id);

            if (employee == null)
                return NotFound();

            employee.Name = updatedEmployee.Name;
            employee.Department = updatedEmployee.Department;
            employee.Salary = updatedEmployee.Salary;

            _service.Update(employee);

            return Ok(employee);
        }

        [HttpPatch("{id}/salary")]
        public IActionResult UpdateSalary(int id, [FromBody] int salary)
        {
            var employee = _service.GetById(id);

            if (employee == null)
                return NotFound();

            employee.Salary = salary;

            _service.Update(employee);

            return Ok(employee);
        }

        [HttpGet("department/{department}")]
        public IActionResult GetByDepartment(string department)
        {
            var employees = _service.GetByDepartment(department);

            return Ok(employees);
        }
    }
}

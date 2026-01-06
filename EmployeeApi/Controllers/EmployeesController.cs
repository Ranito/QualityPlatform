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

    }
}

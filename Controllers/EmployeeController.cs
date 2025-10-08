using Microsoft.AspNetCore.Mvc;
using WebApi_Core_Collection.Models;
using WebApi_Core_Collection.Repository;

namespace WebApi_Core_Collection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _repo;

        public EmployeeController(IEmployee repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult ShowAllEmployees()
        {
            return Ok(_repo.GetAllEmployees());
        }


        [HttpGet("id/{id}")]
        public IActionResult ShowById([FromRoute] int id)
        {
            var employee = _repo.GetEmployeeById(id);
            if (employee == null)
                return NotFound($"Employee with ID {id} not found.");
            return Ok(employee);
        }
        [HttpGet("Dept")]
        public IActionResult ShowByDept([FromQuery] string dept)
        {
            var employees = _repo.GetEmployeesByDept(dept);
            if (employees == null || !employees.Any())
                return NotFound($"No employees found in department '{dept}'.");
            return Ok(employees);
        }
        
        [HttpPost("Add")]
        public IActionResult Add([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest("Invalid employee data.");

            _repo.AddEmployee(employee);
            return Ok("Employee added successfully.");
        }


        [HttpPut("Update_Emlpoyee")]
        public IActionResult Edit([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest("Invalid employee data.");

            _repo.UpdateEmployee(employee);
            return Ok("Employee updated successfully.");
        }

        [HttpPatch("Update_Email/{id}")]
        public IActionResult Patch([FromRoute] int id, [FromQuery] string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return BadRequest("Email cannot be empty.");

            _repo.UpdateEmployeeEmail(id, email);
            return Ok("Updated Email ID.");
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _repo.DeleteEmployee(id);
            return Ok("Deleted Employee.");
        }

        [HttpHead("count")]
        public IActionResult GetEmployeeCountHeader()
        {

            var employees = _repo.GetAllEmployees();

            Response.Headers.Append("Employees-Total-Count", employees.Count().ToString());

            return Ok();
        }
    }
}

using JWT_Authorization_Authentication.Interfaces;
using JWT_Authorization_Authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWT_Authorization_Authentication.Controllers
{
    [Route("api/employee")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("getall")]
        [Authorize(Roles = "User,Admin")]
        public List<Employee> GetEmployees()
        {
            return _employeeService.GetEmployeeDetails();
        }

        [HttpPost]
        public Employee AddEmployee([FromBody] Employee employee)
        {
            var emp = _employeeService.AddEmployee(employee);
            return emp;
        }
    }
}

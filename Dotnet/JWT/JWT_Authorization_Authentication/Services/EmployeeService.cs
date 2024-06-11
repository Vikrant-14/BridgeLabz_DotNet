using JWT_Authorization_Authentication.Context;
using JWT_Authorization_Authentication.Interfaces;
using JWT_Authorization_Authentication.Models;

namespace JWT_Authorization_Authentication.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly JwtContext _context;

        public EmployeeService(JwtContext context)
        {
            _context = context;
        }

        public Employee AddEmployee(Employee employee)
        {
            var emp = _context.Employees.Add(employee);
            _context.SaveChanges();

            return emp.Entity;
        }

        public List<Employee> GetEmployeeDetails()
        {
            var employees = _context.Employees.ToList();

            return employees;
        }
    }
}

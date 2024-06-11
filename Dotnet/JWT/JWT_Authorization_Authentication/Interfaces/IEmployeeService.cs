using JWT_Authorization_Authentication.Models;

namespace JWT_Authorization_Authentication.Interfaces
{
    public interface IEmployeeService
    {
        public List<Employee> GetEmployeeDetails();

        public Employee AddEmployee(Employee employee);
    }
}

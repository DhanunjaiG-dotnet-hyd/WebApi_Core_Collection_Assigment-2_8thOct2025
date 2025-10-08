using WebApi_Core_Collection.Models;

namespace WebApi_Core_Collection.Repository
{
    public interface IEmployee
    {
        public List<Employee> GetAllEmployees();
        public Employee GetEmployeeById(int id);
        public List<Employee> GetEmployeesByDept(string name);
        public void AddEmployee(Employee employee);
        public void UpdateEmployee(Employee employee);
        public void UpdateEmployeeEmail(int id, string email);
        public void DeleteEmployee(int id);

        
    }
}

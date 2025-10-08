using WebApi_Core_Collection.Models;

namespace WebApi_Core_Collection.Repository
{
    public class EmployeeRepository:IEmployee
    {
        static List<Employee> employees = new List<Employee>() { 
        new Employee(){Id=101, Name="Dhanunjai", Department="Development", Email="dhanunjai@gmail.com",MobileNo="8367463968" },
        new Employee(){Id=102, Name="Jai", Department="Testing", Email="jai@gmail.com",MobileNo="8185922161" },
        new Employee(){Id=103, Name="Dhanu", Department="Development", Email="dhanu@gmail.com",MobileNo="8186927458" }
        };

        public List<Employee> GetAllEmployees() =>employees;

        public Employee GetEmployeeById(int id) => employees.FirstOrDefault(e=>e.Id==id);

        public List<Employee> GetEmployeesByDept(string dept)
        {
            List<Employee> emp = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (employee.Department == dept)
                {
                    emp.Add(employee);
                }
            }

            return emp;
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            Employee emp = employees.FirstOrDefault(e => e.Id == employee.Id);
            emp.Name = employee.Name;
            emp.Department = employee.Department;
            emp.MobileNo = employee.MobileNo;
            emp.Email = employee.Email;

        }

        public void UpdateEmployeeEmail(int  id, string email)
        {
            Employee emp = employees.FirstOrDefault(e => e.Id == id);
            emp.Email=email;
        }

        public void DeleteEmployee(int id)
        {
            Employee emp = GetEmployeeById(id);
            employees.Remove(emp);
        }
    }
}

using EmployeePaySlip.Models;
using EmployeePaySlip.Models.Tables;

namespace EmployeePaySlip.Interface
{
    public interface IEmployeeRepository
    {
       
           // IEnumerable<Employee> GetAllEmployee();
        public List<Employee> GetAllEmployee();
        void AddEmployee(AddEmpViewModel employee);
        void Delete(int id);
        public List<Employee> GetEmpById (int id,string name);
        void Update(Employee employee );

    }
}

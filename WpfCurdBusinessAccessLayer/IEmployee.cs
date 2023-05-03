using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfCurd.BusinessEntityLayer;

namespace WpfCurd.BusinessAccessLayer
{
    public interface IEmployee
    {
        Task<List<EmployeeDetails>> GetEmployees();
        Task<EmployeeDetails> CreateEmployee(EmployeeDetails employeeDetails);
        Task<EmployeeDetails> UpdateEmployee(EmployeeDetails employeeDetails);
        Task<List<EmployeeDetails>> DeleteEmployee(int id);
    }
}

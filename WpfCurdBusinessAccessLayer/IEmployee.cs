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
        Task<string> GetEmployees();
        Task<HttpResponseMessage> CreateEmployee(EmployeeDetails employeeDetails);
        Task<HttpResponseMessage> UpdateEmployee(EmployeeDetails employeeDetails);
        Task<string> DeleteEmployee(int id);
    }
}

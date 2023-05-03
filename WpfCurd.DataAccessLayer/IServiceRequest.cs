using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfCurd.BusinessEntityLayer;

namespace WpfCurd.DataAccessLayer
{
    public interface IServiceRequest
    {
        Task<List<EmployeeDetails>> GetEmployeeListRequest();
        Task<EmployeeDetails> CreateEmployeeRequest(EmployeeDetails employeeDetails);
        Task<EmployeeDetails> UpdateEmployeeRequest(EmployeeDetails employeeDetails);
        Task<List<EmployeeDetails>> DeleteEmployeeRequest(int id);
    }
}

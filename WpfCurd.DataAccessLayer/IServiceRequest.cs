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
        Task<string> GetEmployeeListRequest();
        Task<HttpResponseMessage> CreateEmployeeRequest(EmployeeDetails employeeDetails);
        Task<HttpResponseMessage> UpdateEmployeeRequest(EmployeeDetails employeeDetails);
        Task<string> DeleteEmployeeRequest(int id);
    }
}

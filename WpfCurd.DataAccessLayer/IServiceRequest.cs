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
        Task<Usrerlist> GetEmployeeListRequest(int ispage);
        Task<Usrer> CreateEmployeeRequest(EmployeeDetails employeeDetails);
        Task<Usrer> UpdateEmployeeRequest(EmployeeDetails employeeDetails);
        Task<Usrer> DeleteEmployeeRequest(int id);
    }
}

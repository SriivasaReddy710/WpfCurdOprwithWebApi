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
        Task<Usrerlist> GetEmployees(int ispage);
        Task<Usrer> CreateEmployee(EmployeeDetails employeeDetails);
        Task<Usrer> UpdateEmployee(EmployeeDetails employeeDetails);
        Task<Usrer> DeleteEmployee(int id);
    }
}

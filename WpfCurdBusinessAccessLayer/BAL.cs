using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WpfCurd.BusinessEntityLayer;
using WpfCurd.DataAccessLayer;
using WpfCurd.DataAccessLayer.Constants;

namespace WpfCurd.BusinessAccessLayer
{
    public class BAL : IEmployee
    {
        private IServiceRequest _serviceRequest;
        public BAL(IServiceRequest serviceRequest)
        {
            _serviceRequest = serviceRequest;
        }

        public async Task <Usrerlist> GetEmployees(int ispage)
        {
            var response = await _serviceRequest.GetEmployeeListRequest(ispage);
            return response;
        }

        public async Task<Usrer> CreateEmployee(EmployeeDetails employeedetails)
        {
            var response = await _serviceRequest.CreateEmployeeRequest(employeedetails);
            return response;
        }

        public async Task<Usrer> UpdateEmployee(EmployeeDetails employeedetails)
        {
            var response = await _serviceRequest.UpdateEmployeeRequest(employeedetails);
            return response;
        }

        public async Task<Usrer> DeleteEmployee(int id)
        {
            var response = await _serviceRequest.DeleteEmployeeRequest(id);
            return response;
        }
    }
}

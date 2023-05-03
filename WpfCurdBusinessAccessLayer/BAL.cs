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

        public async Task<List<EmployeeDetails>> GetEmployees()
        {
            var response = await _serviceRequest.GetEmployeeListRequest();
            return response;
        }

        public async Task<EmployeeDetails> CreateEmployee(EmployeeDetails employeedetails)
        {
            var response = await _serviceRequest.CreateEmployeeRequest(employeedetails);
            return response;
        }

        public async Task<EmployeeDetails> UpdateEmployee(EmployeeDetails employeedetails)
        {
            var response = await _serviceRequest.UpdateEmployeeRequest(employeedetails);
            return response;
        }

        public async Task<List<EmployeeDetails>> DeleteEmployee(int id)
        {
            var response = await _serviceRequest.DeleteEmployeeRequest(id);
            return response;
        }
    }
}

using System.Net.Http;
using System.Threading.Tasks;
using WpfCurd.BusinessEntityLayer;
using WpfCurd.DataAccessLayer;
namespace WpfCurd.BusinessAccessLayer
{
    public class BAL : IEmployee
    {
        private IServiceRequest _serviceRequest;
        public BAL(IServiceRequest serviceRequest)
        {
            _serviceRequest = serviceRequest;
        }

        public async Task<string> GetEmployees()
        {
            var response = await _serviceRequest.GetEmployeeListRequest();
            return response;
        }

        public async Task<HttpResponseMessage> CreateEmployee(EmployeeDetails employeedetails)
        {
            HttpResponseMessage response = await _serviceRequest.CreateEmployeeRequest(employeedetails);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateEmployee(EmployeeDetails employeedetails)
        {
            HttpResponseMessage response = await _serviceRequest.UpdateEmployeeRequest(employeedetails);
            return response;
        }

        public async Task<string> DeleteEmployee(int id)
        {
            var response = await _serviceRequest.DeleteEmployeeRequest(id);
            return response;
        }
    }
}

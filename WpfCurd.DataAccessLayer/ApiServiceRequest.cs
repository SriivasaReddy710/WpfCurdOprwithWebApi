using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using WpfCurd.BusinessEntityLayer;
using Newtonsoft.Json;
using System.Text;
using WpfCurd.DataAccessLayer.Utilities;
using WpfCurd.DataAccessLayer.Constants;

namespace WpfCurd.DataAccessLayer
{
    public class ApiServiceRequest : IServiceRequest
    {
        private readonly HttpClient _client;
        private readonly AppSettingURL  _appSettingURL;
        public ApiServiceRequest()
        {
            _appSettingURL= new AppSettingURL();
            _client = new HttpClient();
            AddHeaders();
        }

        public async Task<string> GetEmployeeListRequest()
        {
            try
            {
                var requesturl = string.Concat(_appSettingURL.WebapiBaseUrl, GAConstants.ENDPOINT_Employe);
                HttpResponseMessage response = await _client.GetAsync(new Uri(requesturl));
                string result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<HttpResponseMessage> CreateEmployeeRequest(EmployeeDetails employeeDetails)
        {
            try
            {
                HttpContent byteContent = CreateHttpContent(employeeDetails);
                var requesturl = string.Concat(_appSettingURL.WebapiBaseUrl, GAConstants.ENDPOINT_Employe);
                HttpResponseMessage response = await _client.PostAsync(new Uri(requesturl), byteContent);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public async Task<HttpResponseMessage> UpdateEmployeeRequest(EmployeeDetails employeeDetails)
        {
            try
            {
                HttpContent byteContent = CreateHttpContent(employeeDetails);
                var requesturl = string.Concat(_appSettingURL.WebapiBaseUrl, GAConstants.ENDPOINT_Employe_slash, employeeDetails.id);
                HttpResponseMessage response = await _client.PutAsync(new Uri(requesturl), byteContent);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> DeleteEmployeeRequest(int id)
        {
            try
            {
                var requesturl = string.Concat(_appSettingURL.WebapiBaseUrl, GAConstants.ENDPOINT_Employe_slash, id);
                HttpResponseMessage response = await _client.DeleteAsync(new Uri(requesturl));
                string result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private HttpContent CreateHttpContent<EmployeeDetails>(EmployeeDetails employeeDetails)
        {
            var json = JsonConvert.SerializeObject(employeeDetails);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }

        private void AddHeaders()
        {
            _client.DefaultRequestHeaders
                               .Accept
                               .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
              GAConstants.ENDPOINT_TOKEN, _appSettingURL.AccessToken);
        }
       
    }
}

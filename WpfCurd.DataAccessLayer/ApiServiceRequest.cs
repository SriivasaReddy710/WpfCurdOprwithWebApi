using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WpfCurd.BusinessEntityLayer;
using WpfCurd.DataAccessLayer.Constants;
using WpfCurd.DataAccessLayer.Utilities;

namespace WpfCurd.DataAccessLayer
{
    public class ApiServiceRequest : IServiceRequest
    {
        private readonly HttpClient _client;
        private readonly AppSettingURL _appSettingURL;
        public ApiServiceRequest()
        {
            _appSettingURL = new AppSettingURL();
            _client = new HttpClient();
            AddHeaders();
        }

        public async Task<Usrerlist> GetEmployeeListRequest(int ispage)
        {
            try
            {
                var endpoint = ispage > 0 ? string.Concat(GAConstants.ENDPOINT_Employe_pages,ispage) : GAConstants.ENDPOINT_Employe;
                var requesturl = string.Concat(_appSettingURL.WebapiBaseUrl, endpoint);
                var response = await _client.GetAsync(new Uri(requesturl));
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Usrerlist>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Usrer> CreateEmployeeRequest(EmployeeDetails employeeDetails)
        {
            try
            {
                HttpContent byteContent = CreateHttpContent(employeeDetails);
                var requesturl = string.Concat(_appSettingURL.WebapiBaseUrl, GAConstants.ENDPOINT_Employe);
                var response = await _client.PostAsync(new Uri(requesturl), byteContent);
                response.EnsureSuccessStatusCode();
                var employeeDetail = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Usrer>(employeeDetail);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<Usrer> UpdateEmployeeRequest(EmployeeDetails employeeDetails)
        {
            try
            {
                HttpContent byteContent = CreateHttpContent(employeeDetails);
                var requesturl = string.Concat(_appSettingURL.WebapiBaseUrl, GAConstants.ENDPOINT_Employe_slash, employeeDetails.id);
                var response = await _client.PutAsync(new Uri(requesturl), byteContent);
                response.EnsureSuccessStatusCode();
                var employeeDetail = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Usrer>(employeeDetail); ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Usrer> DeleteEmployeeRequest(int id)
        {
            try
            {
                var requesturl = string.Concat(_appSettingURL.WebapiBaseUrl, GAConstants.ENDPOINT_Employe_slash, id);
                HttpResponseMessage response = await _client.DeleteAsync(new Uri(requesturl));
                string result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Usrer>(result);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfCurdOprwithWebApi.Model;
using Newtonsoft.Json;
namespace WpfCurdOprwithWebApi.Services
{
    public class ServiceRequests
    {
        private const string BaseUrl = "https://gorest.co.in/public/v2/";
        private const string Token = "b0a3d0ec453c97345c4e2534dbd77010f860332303907ad8aec9ef05d46e5073";

        HttpClient client = new HttpClient();

        public async Task<string> GetAsync()
        {
            client.DefaultRequestHeaders
                                .Accept
                                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization= new AuthenticationHeaderValue(
               "Bearer", Token);
            HttpResponseMessage response = await client.GetAsync(new Uri(BaseUrl + "users"));
            string result = await response.Content.ReadAsStringAsync();
            return result;
        }

        /// <summary>
        /// CreateandUpdateEmployeeRequest
        /// </summary>
        /// <param name="employeedetails"></param>
        /// <param name="isCheck"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateandUpdateEmployeeRequest(EmployeeModel employeedetails, bool isCheck)
        {
            client.DefaultRequestHeaders
                                .Accept
                                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
               "Bearer", Token);

            var json = JsonConvert.SerializeObject(employeedetails);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (isCheck)
            {
                HttpResponseMessage response = await client.PostAsync(new Uri(BaseUrl + "users"), byteContent);
                return response;
            }
            else
            {
                HttpResponseMessage response = await client.PutAsync(new Uri(BaseUrl+"users/"+ employeedetails.id), byteContent);
                return response;
            }
        }

        public async Task<string> DeleteEmployeeRequest(int id)
        {
            client.DefaultRequestHeaders
                                .Accept
                                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
               "Bearer", Token);
            HttpResponseMessage response = await client.DeleteAsync(new Uri(BaseUrl + "users/" + id));
            string result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}

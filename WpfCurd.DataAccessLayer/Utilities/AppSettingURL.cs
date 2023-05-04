using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace WpfCurd.DataAccessLayer.Utilities
{
    public class AppSettingURL
    {
        public string WebapiBaseUrl { get; set; } = "https://gorest.co.in/public-api/";
        public string AccessToken { get; set; } = "b0a3d0ec453c97345c4e2534dbd77010f860332303907ad8aec9ef05d46e5073";
    }
}

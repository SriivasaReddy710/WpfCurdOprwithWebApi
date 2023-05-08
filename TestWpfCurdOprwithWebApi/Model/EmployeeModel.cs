using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfCurdOprwithWebApi.Model
{
    public class EmployeeModel
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? gender { get; set; }
        public string? status { get; set; }
        public string? field { get; set; }
        public string? message { get; set; }
    }
}

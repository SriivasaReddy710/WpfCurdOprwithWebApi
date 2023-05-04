using System.Collections.Generic;
namespace WpfCurd.BusinessEntityLayer
{
    public class EmployeeDetails
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string status { get; set; }
    }

    public class Meta
    {
        public Pagination pagination { get; set; }
    }

    public class Pagination
    {
        public int total { get; set; }
        public int pages { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
    }

    public class Usrerlist
    {
        public int code { get; set; }
        public Meta meta { get; set; }
        public List<EmployeeDetails> data { get; set; }
    }

    public class Usrer
    {
        public int code { get; set; }
        public Meta meta { get; set; }
        public EmployeeDetails data { get; set; }
    }
}

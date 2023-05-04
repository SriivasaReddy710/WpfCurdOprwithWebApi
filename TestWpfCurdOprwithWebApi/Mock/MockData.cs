using System.Threading.Tasks;
using WpfCurd.BusinessAccessLayer;
using WpfCurd.BusinessEntityLayer;

namespace TestWpfCurdOprwithWebApi.Mock
{
    public static class MockData
    {
        public static Task<Usrerlist> GetTestEmployee()
        {
            var employee = new List<EmployeeDetails>() {
            new EmployeeDetails()
            {
                id = 1,
                name ="test1",
                email = "test1",
                gender = "test1",
                status = "test1" ,
            },
             new EmployeeDetails()
            {
                id = 2,
                name ="test2",
                email = "test2",
                gender = "test2",
                status = "test2" ,
            },
             new EmployeeDetails()
            {
                id = 3,
                name ="test3",
                email = "test3",
                gender = "test3",
                status = "test3" ,
            },
            };
            Meta metadata = new ()
            {
              pagination = new Pagination()
              {
                  page = 1,
                  limit = 10,
                  pages= 299
              }
            };

            Usrerlist userDetails = new()
            {
                code = 200,
                meta = metadata,
                data     = employee
            };
            return Task.FromResult(userDetails);
        }

        public static Task<Usrer> GetTestEmployeeId(int id)
        {
            Meta metadata = new()
            {
                pagination = new Pagination()
                {
                    page = 1,
                    limit = 10,
                    pages = 299
                }
            };

            Usrer userDetail = new()
            {
                code = 200,
                meta = metadata,
                data = new EmployeeDetails()
                {
                    id = 1,
                    name = "test1",
                    email = "test1",
                    gender = "test1",
                    status = "test1",
                }
            };
            return Task.FromResult(userDetail);
        }

        public static Task<Usrer> CreateandUpdateTestEmployee()
        {

            Meta metadata = new()
            {
                pagination = new Pagination()
                {
                    page = 1,
                    limit = 10,
                    pages = 299
                }
            };

            Usrer userDetail = new()
            {
                code = 200,
                meta = metadata,
                data     = new EmployeeDetails()
                {
                    id = 3,
                    name = "test3",
                    email = "test3",
                    gender = "test3",
                    status = "test3",
                }
            };
            return Task.FromResult(userDetail);
        }


    }
}

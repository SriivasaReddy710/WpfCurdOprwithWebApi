using System.Threading.Tasks;
using WpfCurd.BusinessAccessLayer;
using WpfCurd.BusinessEntityLayer;

namespace TestWpfCurdOprwithWebApi.Mock
{
    public static class MockData
    {
        public static Task<List<EmployeeDetails>> GetTestEmployee()
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
            return Task.FromResult(employee);
        }

        public static Task<List<EmployeeDetails>> GetTestEmployeeId(int id)
        {
            var employee = new List<EmployeeDetails>() {
            new EmployeeDetails()
            {
                id = 1,
                name ="test1",
                email = "test1",
                gender = "test1",
                status = "test1" ,
            }
            };
            return Task.FromResult(employee);
        }

        public static Task<EmployeeDetails> CreateandUpdateTestEmployee()
        {

            var employee1 = new EmployeeDetails()
            {
                id = 1,
                name = "test1",
                email = "test1",
                gender = "test1",
                status = "test1",
                message = "Sussed",
            };
            var response = employee1;
            return Task.FromResult(response);
        }

        public static bool UpdateEmployee(EmployeeDetails employeeModel)
        {
            var employee = new EmployeeDetails()
            {
                id = 1,
                name = "test1",
                email = "test1",
                gender = "test1",
                status = "test1",
            };
            if (employee.id != employeeModel.id)
            {
                var employee1 = employeeModel;
                employee = employee1;
                return employee.id == employee1.id;
            }
            return false;

        }
    }
}

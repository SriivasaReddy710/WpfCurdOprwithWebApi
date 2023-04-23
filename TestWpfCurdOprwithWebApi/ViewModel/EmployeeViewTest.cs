using Moq;
using TestWpfCurdOprwithWebApi.Model;
using TestWpfCurdOprwithWebApi.Services;

namespace TestWpfCurdOprwithWebApi.ViewModel
{
    public class EmployeeViewTest
    {
        // private readonly Mock<IEmployeeService> _serviceMock;
        EmployeeServices _services;
        [SetUp]
        public void Setup()
        {
        }
        public EmployeeViewTest()
        {
            _services = new EmployeeServices();
        }

        [Test]
        public void GetEmployee_returnAllResult()
        {
            var result = _services.GetEmployee().Result;
            List<EmployeeModel> value = result as List<EmployeeModel>;
            Assert.That(value.Count, Is.EqualTo(3));
        }

        [Test]
        public void GetEmployeeById_retuns_CorrectResult()
        {
            var result = _services.GetEmployee(1).Result;
            List<EmployeeModel> value = result as List<EmployeeModel>;
            Assert.That(value.Count, Is.EqualTo(result.Count));
        }

        [Test]
        public void GetEmployee_returnAllResult_NotNull()
        {
            var result = _services.GetEmployee().Result;
            List<EmployeeModel> value = result as List<EmployeeModel>;
            Assert.IsNotNull(value);
        }

        [Test]
        public void GetEmployee_returnAllResult_NotFoundl()
        {
            var result = _services.GetEmployee().Result;
            List<EmployeeModel> value = result as List<EmployeeModel>;
            Assert.That(value.Count, Is.Not.EqualTo(4));
        }

        [Test]
        public void CreateEmployee_retuns_OkResult()
        {
            EmployeeModel employeeModel = new EmployeeModel()
            {
                id = 1,
                name = "test1",
                email = "test1",
                gender = "test1",
                status = "test1",
            };
            var result = _services.CreateEmployee(employeeModel);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CreateEmployee_retuns_NoResult()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            var result = _services.CreateEmployee(employeeModel);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void CreateEmployee_retuns_NotFoundResult()
        {
            EmployeeModel employeeModel = new EmployeeModel()
            {
                id = 2,
                name = "test2",
                email = "test2",
                gender = "test2",
                status = "test2",
            };
            var result = _services.CreateEmployee(employeeModel);
            Assert.That(result, Is.Not.EqualTo(true));
        }


        [Test]
        public void UpdateEmployee_retuns_OkResult()
        {
            EmployeeModel employeeModel = new EmployeeModel()
            {
                id = 2,
                name = "test2",
                email = "test2",
                gender = "test2",
                status = "test2",
            };
            var result = _services.UpdateEmployee(employeeModel);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void UpdateEmployee_retuns_NotFoundResult()
        {
            EmployeeModel employeeModel = new EmployeeModel()
            {
                id = 1,
                name = "test1",
                email = "test1",
                gender = "test1",
                status = "test1",
            };
            var result = _services.UpdateEmployee(employeeModel);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void DeleteEmployee_OkResult()
        {
            var result = _services.GetEmployee().Result;
            List<EmployeeModel> value = result as List<EmployeeModel>;
            value.RemoveAt(0);
            var count= value.Count;
            Assert.That(count, Is.EqualTo(2));
        }

        [Test]
        public void DeleteEmployee_NotFoundResult()
        {
            var result = _services.GetEmployee().Result;
            List<EmployeeModel> value = result as List<EmployeeModel>;
            value.RemoveAt(0);
            var count = value.Count;
            Assert.That(count, Is.Not.EqualTo(3));
        }
    }
}
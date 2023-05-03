using Moq;
using TestWpfCurdOprwithWebApi.Mock;
using TestWpfCurdOprwithWebApi.Model;
//using TestWpfCurdOprwithWebApi.Services;
using WpfCurd.BusinessAccessLayer;
using WpfCurd.BusinessEntityLayer;
using WpfCurd.DataAccessLayer;

namespace TestWpfCurdOprwithWebApi.ViewModel
{
    public class EmployeeViewTest
    {
        // MockData _services;
        private readonly Mock<IServiceRequest> _mockServiceRequest;
        [SetUp]
        public void Setup()
        {
        }
        public EmployeeViewTest()
        {
            _mockServiceRequest = new Mock<IServiceRequest>();
        }

        [Test]
        public void GetEmployee_returnAllResult()
        {
            //arrange
            _mockServiceRequest.Setup(n => n.GetEmployeeListRequest()).Returns(MockData.GetTestEmployee());
            var employee = new BAL(_mockServiceRequest.Object);
            //act
            var result = employee.GetEmployees();
            //assert
            Assert.IsNotNull(result);
            //Assert.That(result.Result.Length, Is.Not.EqualTo(0));
        }

        [Test]
        public void GetEmployeeById_retuns_CorrectResult()
        {
            //arrange
            _mockServiceRequest.Setup(n => n.GetEmployeeListRequest()).Returns(MockData.GetTestEmployeeId(1));
            var employee = new BAL(_mockServiceRequest.Object);
            //act
            var result = employee.GetEmployees();

            //assert
            Assert.IsNotNull(result);
            Assert.That(result.Result.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetEmployee_returnAllResult_NotFoundl()
        {
            //arrange
            _mockServiceRequest.Setup(n => n.GetEmployeeListRequest()).Returns(MockData.GetTestEmployee());
            var employee = new BAL(_mockServiceRequest.Object);
            //act
            var result = employee.GetEmployees();

            //assert
            Assert.IsNotNull(result);
            //  Assert.That(result., Is.EqualTo(1));
            Assert.That(result.Result.Count, Is.Not.EqualTo(4));
        }

        [Test]
        public void CreateEmployee_retuns_OkResult()
        {
            EmployeeDetails employeeModel = new EmployeeDetails()
            {
                id = 5,
                name = "test1",
                email = "test1",
                gender = "test1",
                status = "test1",
            };
            //arrange
            _mockServiceRequest.Setup(n => n.CreateEmployeeRequest(It.IsAny<EmployeeDetails>())).Returns(MockData.CreateandUpdateTestEmployee());

            var employee = new BAL(_mockServiceRequest.Object);

            //act
            var result = employee.CreateEmployee(employeeModel);

            //assert
            Assert.IsNotNull(result);
            Assert.That(result?.Result?.id, Is.EqualTo(1));
        }

        [Test]
        public void CreateEmployee_retuns_NoResult()
        {
            EmployeeDetails employeeModel = new EmployeeDetails()
            {
                id = 1,
                name = "test1",
                email = "test1",
                gender = "test1",
                status = "test1",
            };
            //arrange
            _mockServiceRequest.Setup(n => n.CreateEmployeeRequest(It.IsAny<EmployeeDetails>())).Returns(MockData.CreateandUpdateTestEmployee());

            var employee = new BAL(_mockServiceRequest.Object);

            //act
            var result = employee.CreateEmployee(employeeModel);

            //assert
            Assert.IsNotNull(result);
            Assert.That(result?.Result?.id, Is.Not.EqualTo(2));
        }


        [Test]
        public void UpdateEmployee_retuns_OkResult()
        {
            EmployeeDetails employeeModel = new EmployeeDetails()
            {
                id = 1,
                name = "test2",
                email = "test2",
                gender = "test2",
                status = "test2",
            };
            //arrange
            _mockServiceRequest.Setup(n => n.UpdateEmployeeRequest(It.IsAny<EmployeeDetails>())).Returns(MockData.CreateandUpdateTestEmployee());

            var employee = new BAL(_mockServiceRequest.Object);

            //act
            var result = employee.UpdateEmployee(employeeModel);

            //assert
            Assert.IsNotNull(result);
            Assert.That(result.Result.email, Is.EqualTo("test1"));
        }

        [Test]
        public void UpdateEmployee_retuns_NotFoundResult()
        {
            EmployeeDetails employeeModel = new EmployeeDetails()
            {
                id = 1,
                name = "test2",
                email = "test2",
                gender = "test2",
                status = "test2",
            };
            //arrange
            _mockServiceRequest.Setup(n => n.UpdateEmployeeRequest(It.IsAny<EmployeeDetails>())).Returns(MockData.CreateandUpdateTestEmployee());

            var employee = new BAL(_mockServiceRequest.Object);

            //act
            var result = employee.UpdateEmployee(employeeModel);

            //assert
            Assert.IsNotNull(result);
            Assert.That(result.Result.email, Is.Not.EqualTo("test2"));
        }

        [Test]
        public void DeleteEmployee_OkResult()
        {
            //arrange
            _mockServiceRequest.Setup(n => n.DeleteEmployeeRequest(It.IsAny<int>())).Returns(MockData.GetTestEmployeeId(1));
            var employee = new BAL(_mockServiceRequest.Object);
            //act
            var result = employee.DeleteEmployee(1);
            //assert
            Assert.IsNotNull(result);
            Assert.That(result.Result.Count, Is.EqualTo(1));
            //Assert.That(result.Result.Length, Is.EqualTo(0));
        }

        [Test]
        public void DeleteEmployee_NotFoundResult()
        {
            //arrange
            _mockServiceRequest.Setup(n => n.DeleteEmployeeRequest(It.IsAny<int>())).Returns(MockData.GetTestEmployeeId(1));
            var employee = new BAL(_mockServiceRequest.Object);
            //act
            var result = employee.DeleteEmployee(1);
            //assert
            Assert.IsNotNull(result);
            Assert.That(result.Result.Count, Is.Not.EqualTo(0));
        }
    }
}
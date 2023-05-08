using Moq;
using TestWpfCurdOprwithWebApi.Mock;
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
            _mockServiceRequest.Setup(n => n.GetEmployeeListRequest(It.IsAny<int>())).Returns(MockData.GetTestEmployee());
            var employee = new BAL(_mockServiceRequest.Object);
            //act
            var result = employee.GetEmployees(0);
            //assert
            Assert.IsNotNull(result);
            Assert.That(result?.Result.code, Is.EqualTo(200));
        }

        [Test]
        public void GetEmployee_returnAllResult_NotFoundl()
        {
            //arrange
            _mockServiceRequest.Setup(n => n.GetEmployeeListRequest(It.IsAny<int>())).Returns(MockData.GetTestEmployee());
            var employee = new BAL(_mockServiceRequest.Object);
            //act
            var result = employee.GetEmployees(1);

            //assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CreateEmployee_retuns_OkResult()
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
            Assert.That(result?.Result?.code, Is.EqualTo(200));
            Assert.That(result?.Result?.data.id, Is.EqualTo(3));
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
            Assert.That(result?.Result?.code, Is.EqualTo(200));
            Assert.That(result?.Result?.data.id, Is.Not.EqualTo(2));
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
            Assert.That(result.Result.data.email, Is.EqualTo("test3"));
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
            Assert.That(result?.Result?.code, Is.EqualTo(200));
            Assert.That(result.Result.data.email, Is.Not.EqualTo("test2"));
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
            Assert.That(result?.Result?.code, Is.EqualTo(200));
            Assert.That(result.Result.data.id, Is.EqualTo(1));
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
            Assert.That(result?.Result?.code, Is.EqualTo(200));
            Assert.That(result.Result.data.id, Is.Not.EqualTo(2));
        }
    }
}
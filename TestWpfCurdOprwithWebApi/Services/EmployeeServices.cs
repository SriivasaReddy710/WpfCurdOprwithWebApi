using Moq;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestWpfCurdOprwithWebApi.Model;
using WpfCurdOprwithWebApi.Model;
using EmployeeModel = TestWpfCurdOprwithWebApi.Model.EmployeeModel;

namespace TestWpfCurdOprwithWebApi.Services
{
    public class EmployeeServices
    {
        public Task<List<EmployeeModel>> GetEmployee()
        {
            var employee = new List<EmployeeModel>() {
            new EmployeeModel()
            {
                id = 1,
                name ="test1",
                email = "test1",
                gender = "test1",
                status = "test1" ,
            },
             new EmployeeModel()
            {
                id = 2,
                name ="test2",
                email = "test2",
                gender = "test2",
                status = "test2" ,
            },
             new EmployeeModel()
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

        public Task<List<EmployeeModel>> GetEmployee(int id)
        {
            var employee = new List<EmployeeModel>() {
            new EmployeeModel()
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
        public bool CreateEmployee(EmployeeModel employeeModel)
        {
            var employee = new EmployeeModel()
            {
                id = 1,
                name = "test1",
                email = "test1",
                gender = "test1",
                status = "test1",
            };
            if (!string.IsNullOrEmpty(employeeModel.ToString()))
                return employeeModel.id == employee.id;
            else
                return false;
        }

        public bool UpdateEmployee(EmployeeModel employeeModel)
        {
            var employee = new EmployeeModel()
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

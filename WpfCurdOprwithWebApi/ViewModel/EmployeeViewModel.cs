﻿using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfCurd.BusinessAccessLayer;
using WpfCurd.BusinessEntityLayer;
using WpfCurdOprwithWebApi.Commands;
using WpfCurdOprwithWebApi.Model;
namespace WpfCurdOprwithWebApi.ViewModel
{
    public class EmployeeViewModel : ViewModelBase
    {
        private readonly ILogger<EmployeeViewModel> _logger;
        private IEmployee _employee;

        #region Properties

        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        private string _gender;
        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
                OnPropertyChanged("Gender");
            }
        }

        private string _status;
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged("Gender");
            }
        }

        #endregion

        #region Command

        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new RelayCommand<EmployeeModel>((o) => SaveData());

                return _saveCommand;
            }
        }

        #endregion

        private EmployeeModel employeeModel;
        public EmployeeModel EmployeeModel
        {
            get { return employeeModel; }
            set { employeeModel = value; }
        }

        #region Constructor

        public EmployeeViewModel(IEmployee employee)
        {
            _employee = employee;
        }

        #endregion


        #region Methods
        public async Task<Usrerlist> GetEmployees(int ispage)
        {
            try
            {
                var response = await _employee.GetEmployees(ispage);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("Controller/ViewModel: EmployeeViewModel, Method :GetEmployees ", ex);
                throw;
            }

        }

        public async Task<Usrer> CreateEmployee(EmployeeDetails employeedetails)
        {
            try
            {
                var response = await _employee.CreateEmployee(employeedetails);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("Controller/ViewModel: EmployeeViewModel, Method :CreateEmployee ", ex);
                throw;
            }
        }

        public async Task<Usrer> UpdateEmployee(EmployeeDetails employeedetails)
        {
            try
            {
                var response = await _employee.UpdateEmployee(employeedetails);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("Controller/ViewModel: EmployeeViewModel, Method :UpdateEmployee ", ex);
                throw;
            }

        }

        public async Task<Usrer> DeleteEmployee(int id)
        {
            try
            {
                var response = await _employee.DeleteEmployee(id);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("Controller/ViewModel: EmployeeViewModel, Method :DeleteEmployee ", ex);
                throw;
            }

        }
        public void SaveData()
        {

        }

        #endregion
    }
}

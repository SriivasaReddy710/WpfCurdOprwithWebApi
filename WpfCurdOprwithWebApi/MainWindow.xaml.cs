using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using WpfCurd.BusinessAccessLayer;
using WpfCurd.BusinessEntityLayer;
using WpfCurd.DataAccessLayer;
using WpfCurdOprwithWebApi.Model;
using WpfCurdOprwithWebApi.ViewModel;
using Label = System.Windows.Controls.Label;

namespace WpfCurdOprwithWebApi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmployeeViewModel _employeeViewModel;
        private readonly IEmployee _employee;
        private readonly IServiceRequest _serviceRequest;

        Label lblMessage = new Label(); // lblmessage
        public MainWindow()
        {
            InitializeComponent();
            _serviceRequest = new ApiServiceRequest();
            _employee = new BAL(_serviceRequest);
            _employeeViewModel = new EmployeeViewModel(_employee);
            this.DataContext = this;
            CurrentPage = 1;
            NumberofPages = 10;
          
        }

        #region properties 

        private bool _updateVisibility = true;
        public bool UpdateVisibility
        {
            get { return _updateVisibility; }
            set { _updateVisibility = value; }
        }

        private int _genderIndex;
        public int GenderIndex
        {
            get { return _genderIndex; }
            set { _genderIndex = value; }
        }

        private int _currentPage = 1;
        public int CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; }
        }

        private int _numberofPages = 10;
        public int NumberofPages
        {
            get { return _numberofPages; }
            set { _numberofPages = value; }
        }

        #endregion

        private void btnLoadEmp_Click(object sender, RoutedEventArgs e)
        {
            this.GetEmployees();
        }

        private async void GetEmployees()
        {
            var response = await _employeeViewModel.GetEmployees();
            dgEmp.DataContext = response;
        }

        void btnDeleteEmployee(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm delete of this record?", "employee", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                EmployeeDetails employeedetails = ((FrameworkElement)sender).DataContext as EmployeeDetails;
                if (employeedetails != null)
                {
                    this.DeleteEmployee(employeedetails.id);
                }
            }
        }

        void btnEditEmployee(object sender, EventArgs e)
        {
            UpdateVisibility = false;
            EmployeeDetails employeedetails = ((FrameworkElement)sender).DataContext as EmployeeDetails;
            if (employeedetails != null)
            {
                txtEmpId.Text = employeedetails.id.ToString();
                txtName.Text = employeedetails.name;
                txtEmail.Text = employeedetails.email;
                txtStatus.Text = employeedetails.status;
                GetGenderIndex(employeedetails.gender);
            }
        }

        private void btnSaveEmp_Click(object sender, RoutedEventArgs e)
        {
            var employee = new EmployeeDetails()
            {
                id = Convert.ToInt32(txtEmpId.Text),
                name = txtName.Text,
                email = txtEmail.Text,
                gender = gendarCombx.Text,
                status = txtStatus.Text,
            };
            if (UpdateVisibility)
                this.CreateEmployee(employee);
            else
                this.UpdateEmployee(employee);

            txtName.Text = "";
            txtEmail.Text = "";
            txtStatus.Text = "";
            gendarCombx.Text = "";
            UpdateVisibility = true;
        }

        private async void CreateEmployee(EmployeeDetails employee)
        {
            lblMessage.Content = "Created";
            var response = await _employeeViewModel.CreateEmployee(employee);
            CreateandUpdateEmployeeResponse(response);
        }

        private async void UpdateEmployee(EmployeeDetails employee)
        {
            lblMessage.Content = "updated";
            var response = await _employeeViewModel.UpdateEmployee(employee);
            CreateandUpdateEmployeeResponse(response);
        }

        private void DeleteEmployee(int id)
        {
            var response = _employeeViewModel.DeleteEmployee(id);
            MessageBox.Show("Record successfully deleted.");
            this.GetEmployees();
        }

        private void CreateandUpdateEmployeeResponse(EmployeeDetails response)
        {
            if (string.IsNullOrEmpty(response.message))
            {
                dgEmp.DataContext = response;
                MessageBox.Show("Employee Record " + lblMessage.Content + "successfully");
                this.GetEmployees();
            }
            else
            {
                MessageBox.Show(response.ToString());
            }
        }

        private void GetGenderIndex(string gender)
        {
            if (gender == "male")
            {
                GenderIndex = 0;
                gendarCombx.Text = "Male";
            }
            else if (gender == "female")
            {
                gendarCombx.Text = "Female";
                GenderIndex = 1;
            }
            else if (gender == "others")
            {
                gendarCombx.Text = "Female";
                GenderIndex = 2;
            }

        }
    }
}

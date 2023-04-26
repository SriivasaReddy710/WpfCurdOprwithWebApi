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
            // this.DataContext = _employeeViewModel;
        }

        #region properties 

        private bool _updateVisibility = true;
        public bool UpdateVisibility
        {
            get { return _updateVisibility; }
            set { _updateVisibility = value; }
        }

        #endregion

        private void btnLoadEmp_Click(object sender, RoutedEventArgs e)
        {
            this.GetEmployees();
        }

        private async void GetEmployees()
        {
            var response = await _employeeViewModel.GetEmployees();
            var employee = JsonConvert.DeserializeObject<List<EmployeeModel>>(response);
            dgEmp.DataContext = employee;
        }

        void btnDeleteEmployee(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm delete of this record?", "employee", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                EmployeeModel employeedetails = ((FrameworkElement)sender).DataContext as EmployeeModel;
                if (employeedetails != null)
                {
                    this.DeleteEmployee(employeedetails.id);
                }
            }
        }

        void btnEditEmployee(object sender, EventArgs e)
        {
            UpdateVisibility = false;
            EmployeeModel employeedetails = ((FrameworkElement)sender).DataContext as EmployeeModel;
            if (employeedetails != null)
            {
                txtEmpId.Text = employeedetails.id.ToString();
                txtName.Text = employeedetails.name;
                txtEmail.Text = employeedetails.email;
                txtStatus.Text = employeedetails.status;
                gendarCombx.SelectedItem = employeedetails.gender;
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

        private void CreateandUpdateEmployeeResponse(HttpResponseMessage response)
        {
            var json = string.Empty;
            if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                response.EnsureSuccessStatusCode();
                json = response.Content.ReadAsStringAsync().Result;
                var employee = JsonConvert.DeserializeObject<EmployeeModel>(json);
                dgEmp.DataContext = employee;
                MessageBox.Show("Employee Record " + lblMessage.Content + "successfully");
                this.GetEmployees();
            }
            else
            {
                json = response.Content.ReadAsStringAsync().Result;
                MessageBox.Show(json.ToString());
            }
        }
    }
}

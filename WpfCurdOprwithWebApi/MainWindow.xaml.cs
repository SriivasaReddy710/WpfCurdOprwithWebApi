using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfCurdOprwithWebApi.Model;
using WpfCurdOprwithWebApi.Services;

namespace WpfCurdOprwithWebApi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceRequests _serviceRequest;
        public MainWindow()
        {
            InitializeComponent();
            _serviceRequest = new ServiceRequests();
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
            var response = await _serviceRequest.GetAsync();
            var employee = JsonConvert.DeserializeObject<List<EmployeeModel>>(response);
            dgEmp.DataContext = employee;
        }

        private async void SaveEmployee(EmployeeModel employeedetails)
        {
            var json = string.Empty;
            var response = await _serviceRequest.CreateandUpdateAsync(employeedetails, true);
            if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                response.EnsureSuccessStatusCode();
                json = await response.Content.ReadAsStringAsync();
                var employee = JsonConvert.DeserializeObject<EmployeeModel>(json);
                dgEmp.DataContext = employee;
                MessageBox.Show("Employee Recorder Created successfully");
                this.GetEmployees();
            }
            else
            {
                json = response.Content.ReadAsStringAsync().Result;
                MessageBox.Show(json.ToString());
            }
        }

        private async void UpdateEmployee(EmployeeModel employeedetails)
        {
            var json = string.Empty;
            var response = await _serviceRequest.CreateandUpdateAsync(employeedetails, false);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                json = await response.Content.ReadAsStringAsync();
                var employee = JsonConvert.DeserializeObject<EmployeeModel>(json);
                dgEmp.DataContext = employee;
                MessageBox.Show("Employee Record updated successfully");
                this.GetEmployees();
            }
            else
            {
                json = response.Content.ReadAsStringAsync().Result;
                MessageBox.Show(json.ToString());
            }
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

        private async void DeleteEmployee(int id)
        {
            var response = await _serviceRequest.DeleteAsync(id);
            MessageBox.Show("Record successfully deleted.");
            GetEmployees();

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
            var employee = new EmployeeModel()
            {
                id = Convert.ToInt32(txtEmpId.Text),
                name = txtName.Text,
                email = txtEmail.Text,
                gender = gendarCombx.Text,
                status = txtStatus.Text,
            };
            if (UpdateVisibility)
                this.SaveEmployee(employee);
            else
                this.UpdateEmployee(employee);

            txtName.Text = "";
            txtEmail.Text = "";
            txtStatus.Text = "";
            gendarCombx.Text = "";
            UpdateVisibility = true;
        }
    }
}

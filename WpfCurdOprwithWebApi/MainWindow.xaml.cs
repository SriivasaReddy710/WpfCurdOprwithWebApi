using System;
using System.ComponentModel;
using System.Windows;
using WpfCurd.BusinessAccessLayer;
using WpfCurd.BusinessEntityLayer;
using WpfCurd.DataAccessLayer;
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
            this.GetEmployees(0);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #region properties 

        private bool _updateVisibility = true;
        public bool UpdateVisibility
        {
            get { return _updateVisibility; }
            set
            {
                _updateVisibility = value;
                OnPropertyChanged("UpdateVisibility");
            }
        }

        private int _genderIndex;
        public int GenderIndex
        {
            get { return _genderIndex; }
            set
            {
                _genderIndex = value;
                OnPropertyChanged("GenderIndex");
            }
        }

        private int _start;
        public int Start
        {
            get { return _start; }
            set
            {
                _start = value;
                OnPropertyChanged("Start");
            }
        }

        private int _nextpage;
        public int Nextpage
        {
            get { return _nextpage; }
            set
            {
                _nextpage = value;
                OnPropertyChanged("Nextpage");
            }
        }

        private int _totalItems;
        public int TotalItems
        {
            get { return _totalItems; }
            set
            {
                _totalItems = value;
                OnPropertyChanged("TotalItems");
            }
        }

        #endregion

        private void btnLoadEmp_Click(object sender, RoutedEventArgs e)
        {
            this.GetEmployees(0);
        }

        private async void GetEmployees(int ispage)
        {
            var response = await _employeeViewModel.GetEmployees(ispage);
            dgEmp.DataContext = response.data;
            TotalItems = response.meta.pagination.limit;
            Start = response.meta.pagination.page;
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
            this.GetEmployees(0);
        }

        private void CreateandUpdateEmployeeResponse(Usrer response)
        {
            if (response.code == 200 || response.code == 201)
            {
                dgEmp.DataContext = response;
                MessageBox.Show("Employee Record " + lblMessage.Content + "successfully");
                this.GetEmployees(0);
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

        private void btnnextpage_Click(object sender, RoutedEventArgs e)
        {
            int nextpage = 0;
            nextpage = Start++;
            GetEmployees(nextpage);
        }

        private void btnlAstpage_Click(object sender, RoutedEventArgs e)
        {
            GetEmployees(10);
        }

        private void btnfirstpage_Click(object sender, RoutedEventArgs e)
        {
            GetEmployees(0);
        }

        private void btnpreviouspage_Click(object sender, RoutedEventArgs e)
        {
            int previous = 0;
            previous = Nextpage--;
            GetEmployees(previous);
        }

    }
}

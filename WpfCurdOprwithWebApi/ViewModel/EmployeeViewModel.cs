using System;
using System.Windows;
using System.Windows.Input;
using WpfCurd.BusinessAccessLayer;
using WpfCurd.BusinessEntityLayer;
using WpfCurd.DataAccessLayer;
using WpfCurdOprwithWebApi.Commands;
using WpfCurdOprwithWebApi.Model;
namespace WpfCurdOprwithWebApi.ViewModel
{
    public class EmployeeViewModel : ViewModelBase
    {

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
                    _saveCommand = new RelayCommand(param => SaveData(), null);

                return _saveCommand;
            }
        }

        #endregion

        public EmployeeModel EmployeeModel { get; }

        #region Constructor

        public EmployeeViewModel()
        {

            EmployeeModel = new EmployeeModel();
        }

        #endregion

        public void SaveData()
        {

        }

    }
}

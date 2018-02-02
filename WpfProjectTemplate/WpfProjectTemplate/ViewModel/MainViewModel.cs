using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfProjectTemplate.BLL.Interface;
using WpfProjectTemplate.BLL.Service;
using WpfProjectTemplate.Commands;

namespace WpfProjectTemplate.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private IAuthenticationService _authenticationService;
        public MainViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        private string _login;
        private string _password;
        private RelayCommand _loginCommand;
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }


        public RelayCommand LoginCommand => _loginCommand ?? new RelayCommand(UserWindow);




        public async void UserWindow(object passBox)
        {
            string pass = "";
            if (passBox is PasswordBox passwordBox) pass = passwordBox.Password;
            var message = await _authenticationService.Auth(Login, pass);

            if (message.Result)
                MessageBox.Show("User window;)");
            else
            {
                MessageBox.Show(message.Message);

            }
        }
    }
}
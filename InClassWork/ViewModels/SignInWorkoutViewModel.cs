using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using InClassWork.Helper;
using InClassWork.Models;
using InClassWork.Service;

namespace InClassWork.ViewModels
{
    public class SignInWorkoutViewModel:ViewModelBase
    {
        #region Data Members
        private string? _userName;
        private string? _password;
        private string? _errorMessage;
        private bool _errorMessageVisible;
        private bool _passwordNotVisible;
        private Color? _signInMessageColor;
        private string _passwordButtonText;
        
        private readonly INavigation? _navigationPage;
        private DBMokup? _db;
        #endregion

        #region Properties
        public string UserName
        {
            get => _userName;
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged();
                    (SignInCommand as Command).ChangeCanExecute();
                }
            }
        }
        public string UserPassword
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                    (SignInCommand as Command).ChangeCanExecute();
                }
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool ErrorMessageVisible
        {
            get => _errorMessageVisible;
            set
            {
                if (_errorMessageVisible != value)
                {
                    _errorMessageVisible = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool PasswordNotVisible
        {
            get => _passwordNotVisible;
            set
            {
                if (_passwordNotVisible != value)
                {
                    _passwordNotVisible = value;
                    OnPropertyChanged();
                }
            }
        }
        public Color SignInMessageColor
        {
            get => _signInMessageColor;
            set
            {
                if (_signInMessageColor != value)
                {
                    _signInMessageColor = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool CanSignIn()
        {
            return !(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPassword));
        }
        public string PasswordButtonText
        {
            get => _passwordButtonText;
            set
            {
                if (_passwordButtonText != value)
                {
                    _passwordButtonText = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ShowPasswordCommand { get; }
        public ICommand SignInCommand { get; }
        public ICommand NavigateToSignUpCommand { get; }
        #endregion

        public SignInWorkoutViewModel(INavigation? navigationPage)
        {
            _passwordNotVisible = true;
            _passwordButtonText = FontHelper.CLOSED_EYE_ICON;
            _errorMessageVisible = false;
            _errorMessage = String.Empty;
            _db = new DBMokup();
            _navigationPage = navigationPage;

            ShowPasswordCommand = new Command(TogglePassword);
            SignInCommand = new Command(SignInButtonClick, CanSignIn);
            NavigateToSignUpCommand = new Command(async () =>
            {
                if (navigationPage != null)
                {
                    await navigationPage.PushAsync(new Views.SignUpWorkout());
                }
            });
        }

        private void TogglePassword()
        {
            PasswordNotVisible = !PasswordNotVisible;

            if (PasswordNotVisible)
            {
                PasswordButtonText = FontHelper.OPEN_EYE_ICON;
            }
            else
            {
                PasswordButtonText = FontHelper.CLOSED_EYE_ICON;

            }
        }
        private void SignInButtonClick()
        {
            ErrorMessageVisible = true;
            if (_db.isExist(UserName, UserPassword))
            {
                //Get User from DB
                AppUser user = _db.GetUserByEmail(UserName)!;

                //Set CurrentUser in App
                (App.Current as App)!.currentUser = user;

                //Navigate to MainPage
                Application.Current!.Windows[0].Page = new AppShell();
            }
            else
            {
                ErrorMessage = AppMessages.loginErrorMessage;
                SignInMessageColor = Colors.Red;
            }
        }
        
    }
}

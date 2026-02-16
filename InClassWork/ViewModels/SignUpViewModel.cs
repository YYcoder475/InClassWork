using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InClassWork.Helper;
using InClassWork.Models;
using InClassWork.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InClassWork.ViewModels
{
    public partial class SignUpViewModel: ObservableObject
    {
        #region Data Members
        AppUser _newUser;
        DBMokup _dbMokup;
        private string? _firstName;
        private string? _lastName;
        private string? _userEmail;
        private string? _userPassword;
        private string? _userMobile;
        [ObservableProperty] private bool _isPasswordNotVisible;
        [ObservableProperty] private string _passwordButtonText;
        private readonly INavigation? _navigationPage;
        #endregion

        #region Properties
        public string? FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged();
                    (SignUpCommand as Command).ChangeCanExecute();
                }
            }
        }
        public string? LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged();
                    (SignUpCommand as Command).ChangeCanExecute();
                }
            }
        }
        public string? UserEmail
        {
            get => _userEmail;
            set
            {
                if (_userEmail != value)
                {
                    _userEmail = value;
                    OnPropertyChanged();
                    (SignUpCommand as Command).ChangeCanExecute();
                }
            }
        }
        public string? UserPassword
        {
            get => _userPassword;
            set
            {
                if (_userPassword != value)
                {
                    _userPassword = value;
                    OnPropertyChanged();
                    (SignUpCommand as Command).ChangeCanExecute();
                }
            }
        }
        public string? UserMobile
        {
            get => _userMobile;
            set
            {
                if (_userMobile != value)
                {
                    _userMobile = value;
                    OnPropertyChanged();
                    (SignUpCommand as Command).ChangeCanExecute();
                }
            }
        }
        #endregion

        public ICommand? SignUpCommand { get; }
        public ICommand? NavigateToSignInCommand { get; }


        public SignUpViewModel(INavigation? navigationPage)
        {
            _dbMokup = new DBMokup();
            IsPasswordNotVisible = true;
            PasswordButtonText = FontHelper.OPEN_EYE_ICON;

            SignUpCommand = new Command(SignUp, ValidateData);
            NavigateToSignInCommand = new Command(async () =>
            {
                if (navigationPage != null)
                {
                    await navigationPage.PushAsync(new Views.SignInWorkout());
                }
            });

        }

        private bool ValidateData()
        {
            var fnameOK = !string.IsNullOrEmpty(_firstName);
            var lnameOK = !string.IsNullOrEmpty(_lastName);
            var emailOK = !string.IsNullOrEmpty(_userEmail);
            var passOK = string.IsNullOrEmpty(_userPassword) ? false : UserPassword.Length > 5;
            var mobileOK = string.IsNullOrEmpty(_userMobile) ? false : UserMobile.Length == 10;

            return fnameOK && lnameOK && emailOK && passOK && mobileOK;
        }

        [RelayCommand]
        private void TogglePassword()
        {
            IsPasswordNotVisible = !IsPasswordNotVisible;

            if (IsPasswordNotVisible)
            {
                PasswordButtonText = FontHelper.OPEN_EYE_ICON;
            }
            else
            {
                PasswordButtonText = FontHelper.CLOSED_EYE_ICON;
            }
        }
        private async void SignUp()
        {
            AppUser newUser = new AppUser()
            {
                FirstName = _firstName,
                LastName = _lastName,
                UserEmail = _userEmail,
                UserPassword = _userPassword,
                UserMobile = _userMobile,
                RegDate = DateTime.Now.ToShortDateString()
            };

            //Checks if User email not exist
            if (_dbMokup.GetUserByEmail(newUser.UserEmail) != null)
            {
                await Toast.Make($"Email already exists!", ToastDuration.Short, 14).Show();
                return;
            }
            
            //Add user to database
            _dbMokup.Insert(newUser);

            //Sign In the user
            //Set CurrntUser in app
            (App.Current as App)!.currentUser = newUser;    

            //Navigate To Mainpage
            Application.Current!.Windows[0].Page = new AppShell();

        }

    }
}

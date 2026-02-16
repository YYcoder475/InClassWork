using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InClassWork.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InClassWork.ViewModels
{
    public partial class AppShellViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isAdminVisible;

        private NavigationPage NavigationPage { get; set; }

        public ICommand YYSignOutCommand { get; }
        public ICommand YYNavigateToAdminPageCommand { get; }

        public AppShellViewModel()
        {
            BindableProperty NavigatePage;
            if ((App.Current as App)!.currentUser.IsAdmin)
                IsAdminVisible = true; // set to true for testing purposes

            YYSignOutCommand = new Command(SignOut);
            YYNavigateToAdminPageCommand = new Command(NavigateToAdminPage);
        }


        [RelayCommand]
        private async void SignOut()
        {
            (App.Current as App)!.currentUser = null;
            Application.Current.Windows[0].Page = new SignInWorkout();
        }

        [RelayCommand]
        private async void NavigateToAdminPage()
        {
            if ((App.Current as App)!.currentUser.IsAdmin)
                NavigationPage = new NavigationPage(new AdminMainPageView());
                //Application.Current.Windows[0].Page = new AdminMainPageView();
        }
    }
}

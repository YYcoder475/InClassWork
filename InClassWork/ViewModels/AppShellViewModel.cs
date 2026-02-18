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


        public AppShellViewModel()
        {
            if ((App.Current as App)!.currentUser.IsAdmin)
                IsAdminVisible = true; // set to true for testing purposes

            

        }


        [RelayCommand]
        private async Task SignOut()
        {
            (App.Current as App)!.currentUser = null;
            Application.Current.Windows[0].Page = new NavigationPage(new SignInWorkout());
        }

        [RelayCommand]
        private async Task NavigateToAdminPage()
        {
            Shell.Current.GoToAsync(nameof(AdminMainPageView));
        }
    }
}

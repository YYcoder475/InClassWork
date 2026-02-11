using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InClassWork.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClassWork.ViewModels
{
    public partial class AppShellViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isAdminVisible;

        public AppShellViewModel()
        {
            if ((App.Current as App)!.currentUser.IsAdmin)
                IsAdminVisible = true; // set to true for testing purposes

        }


        [RelayCommand]
        private async Task SignOut()
        {
            (App.Current as App)!.currentUser = null;
            Application.Current.Windows[0].Page = new SignInWorkout();
        }
    }
}

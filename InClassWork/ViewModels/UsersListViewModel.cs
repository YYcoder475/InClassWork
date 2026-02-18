using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InClassWork.Helper;
using InClassWork.Models;
using InClassWork.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClassWork.ViewModels
{
    public partial class UsersListViewModel : ObservableObject
    {
        private List<AppUser> _allUsers;
        [ObservableProperty] private string? _searchText;
        [ObservableProperty] private string _usersFilterButtonText;
        private bool _isBusy;

        public ObservableCollection<AppUser> AllUsers { get; set; }
        public Command? ClearFilterCommand { get; }


        public UsersListViewModel()
        {
            _usersFilterButtonText = FontHelper.USERS_FILTER_ON;
            ClearFilterCommand = new Command(ClearFilter, () => string.IsNullOrEmpty(_searchText));

            // Load all users from the database mockup
            //If this operation will be async, it could not be called in the constructor
            //_allUsers = new DBMokup().GetUsers();
            AllUsers = new();// Initialize the ObservableCollection
        }

        private void ClearFilter()
        {

            throw new NotImplementedException();

        }
        [RelayCommand] private void Search()
        {

            throw new NotImplementedException();

        }
        public Command? GetAllUsersCommand
        {
            get
            {
                return new Command(() =>
                {
                    // This command can be used to fetch all users from the database
                    // For example, it could be bound to a button to refresh the user list
                    _allUsers = new DBMokup().GetUsers();
                });
            }
        }
        public Command GetUsersCommand
        {
            get
            {
                return new Command(() =>
                {
                    // This command can be used to fetch all users from the database
                    // For example, it could be bound to a button to refresh the user list
                    _allUsers = new DBMokup().GetUsers();
                    AllUsers.Clear(); // Clear the existing collection
                    foreach (var user in _allUsers)
                    {
                        AllUsers.Add(user); // Add each user to the ObservableCollection
                    }
                });
            }
        }
    }
}

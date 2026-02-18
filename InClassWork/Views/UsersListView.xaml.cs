using InClassWork.ViewModels;

namespace InClassWork.Views;

public partial class UsersListView : ContentPage
{
	public UsersListView()
	{
		InitializeComponent();
		BindingContext = new ViewModels.UsersListViewModel();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
        //((ViewModels.UsersListViewModel)BindingContext).GetUsersCommand.Execute(null);

        // Optionally, you can call a method to load data when the page appears
        if (BindingContext is UsersListViewModel viewModel)
        {

            viewModel.GetAllUsersCommand?.Execute(null);

        }
    }
}
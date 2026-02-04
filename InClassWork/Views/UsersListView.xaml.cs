namespace InClassWork.Views;

public partial class UsersListView : ContentPage
{
	public UsersListView()
	{
		InitializeComponent();
		BindingContext = new ViewModels.UsersListViewModel();
	}
}
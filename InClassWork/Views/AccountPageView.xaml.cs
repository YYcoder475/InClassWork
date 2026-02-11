namespace InClassWork.Views;

public partial class AccountPageView : ContentPage
{
	public AccountPageView()
	{
		InitializeComponent();
		BindingContext = new ViewModels.AccountPageViewModel();
	}
}
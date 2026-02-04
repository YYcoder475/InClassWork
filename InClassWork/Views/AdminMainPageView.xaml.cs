namespace InClassWork.Views;

public partial class AdminMainPageView : ContentPage
{
	public AdminMainPageView()
	{
		InitializeComponent();
		BindingContext = new ViewModels.AdminMainPageViewModel();
	}
}
namespace InClassWork.Views;

public partial class MainPageView : ContentPage
{
	public MainPageView()
	{
		InitializeComponent();
        BindingContext = new ViewModels.MainPageViewModel();
    }
}
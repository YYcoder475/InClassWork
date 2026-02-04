namespace InClassWork;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		BindingContext = new ViewModels.AppShellViewModel();
	}
}

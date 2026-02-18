using InClassWork.Views;

namespace InClassWork;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		BindingContext = new ViewModels.AppShellViewModel();

		Routing.RegisterRoute(nameof(MainPageView), typeof(MainPageView));
		Routing.RegisterRoute(nameof(AdminMainPageView), typeof(AdminMainPageView));
		Routing.RegisterRoute(nameof(AccountPageView), typeof(AccountPageView));
		Routing.RegisterRoute(nameof(UsersListView), typeof(UsersListView));
		Routing.RegisterRoute(nameof(SignOutView), typeof(SignOutView));
	}
}

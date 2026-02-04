
using InClassWork.Models;
using InClassWork.Views;

namespace InClassWork;

public partial class App : Application
{
	public AppUser currentUser { get; set; }
	public App()
	{
		InitializeComponent();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
		NavigationPage navigationPage = new NavigationPage(new SignInWorkout());
		return new Window(navigationPage);
	}
}

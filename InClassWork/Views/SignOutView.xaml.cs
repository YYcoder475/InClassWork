namespace InClassWork.Views;

public partial class SignOutView : ContentPage
{
	public SignOutView()
	{
		InitializeComponent();
    }

	protected override void OnAppearing()
	{
		base.OnAppearing();

		//Sign out the user by clearing the current user and navigate to the sign-in page
		//(App.Current as App)!.currentUser = null;
		//Application.Current.Windows[0].Page = new SignInWorkout();
    }
}
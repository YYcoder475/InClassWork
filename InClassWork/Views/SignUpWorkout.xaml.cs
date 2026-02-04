using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using InClassWork.Helper;

namespace InClassWork.Views;

public partial class SignUpWorkout : ContentPage
{
    public SignUpWorkout()
    {
        InitializeComponent();
        BindingContext = new ViewModels.SignUpViewModel(this.Navigation);
    }

}
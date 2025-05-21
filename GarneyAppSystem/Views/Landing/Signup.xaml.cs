using ApplicationService.EntityModel;
using GarneyAppSystem.ApiService;
using System.ComponentModel.DataAnnotations;

namespace GarneyAppSystem.Views.Landing;

public partial class Signup : ContentPage
{
    private readonly UserService _userService = new UserService();

	public Signup()
	{
		InitializeComponent();
	}

	public async void OnSignupButtonClicked(object sender, EventArgs e)
    {
        user _user = new user();
        _user.FullName = txtfullname.Text;
        _user.Address = txtaddress.Text;
        _user.Email = txtEmail.Text;
        _user.PasswordHash = txtPassword.Text;

        var context = new ValidationContext(_user);
        var results = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(_user, context, results, true);

        if (!isValid)
        {
            string errors = string.Join("\n", results.Select(r => r.ErrorMessage));
            await DisplayAlert("Validation Error", errors, "OK");
            return;
        }

        var isExist = await _userService.checkEmail(_user.Email);

        if (isExist.dataModel.apiResult.isExist)
        {
            await DisplayAlert("Email already exists", "Please use a different email address.", "OK");
            return;
        }

        var result = await _userService.CreateUser(_user);

        if(result.dataModel.apiResult.statuscode == 200)
            await DisplayAlert("Sign Up account", result.dataModel.apiResult.msg, "OK");
        else
            await DisplayAlert("Sign Up account", "Failed to create account. Please try again.", "OK");
    }

	public async void OnLoginTapped(object sender, EventArgs e)
    {
        var currentPage = Navigation.NavigationStack[Navigation.NavigationStack.Count - 1];
        Navigation.RemovePage(currentPage);
    }
}
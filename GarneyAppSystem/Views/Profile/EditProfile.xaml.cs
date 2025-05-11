using ApplicationService.EntityModel;
using ApplicationService.Utility;
using GarneyAppSystem.ApiService;
using System.ComponentModel.DataAnnotations;

namespace GarneyAppSystem.Views.Profile;

public partial class EditProfile : ContentPage
{
    private readonly UserService _userservice = new UserService();
    private user _currentUser;

    public EditProfile()
	{
		InitializeComponent();

		LoadData();
	}

	public async void LoadData()
    {
        EntityMaster  data = await _userservice.getUserDetail();

        if (data != null && data.user != null)
        {
            data.user.PasswordHash = EncryptionHelper.Decrypt(data.user.PasswordHash);
            _currentUser = data.user;

            BindingContext = _currentUser;
        }
    }

	public async void OnClickCancelEditProfileDetails(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

	public async void OnClickSubmitEditProfileDetails(object sender, EventArgs e)
    {
        if (BindingContext is user currentUser)
        {
            var context = new ValidationContext(currentUser);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(currentUser, context, results, true);

            if (!isValid)
            {
                string errors = string.Join("\n", results.Select(r => r.ErrorMessage));
                await DisplayAlert("Validation Error", errors, "OK");
                return;
            }

            var result = await _userservice.updateUserDetails(currentUser);

            if(result != null)
            {
                await DisplayAlert("Edit Details", "Details successfully updated.", "OK");
            }
        }
    }

    public async void OnTappedSelectType(object sender, EventArgs e)
    {
        SenderPicker1.Focus();
    }
}
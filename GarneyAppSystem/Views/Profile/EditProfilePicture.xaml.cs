using ApplicationService.EntityModel;
using GarneyAppSystem.ApiService;

namespace GarneyAppSystem.Views.Profile;

public partial class EditProfilePicture : ContentPage
{
    private readonly UserService _userservice = new UserService();
    FileResult _pickedPhoto;

    public EditProfilePicture(user _user)
	{
		InitializeComponent();

		BindingContext = _user;
    }

	private async void OnClickUploadPictureBtn(object sender, EventArgs e)
    {
        try
        {
            _pickedPhoto = await MediaPicker.Default.PickPhotoAsync();

            if (_pickedPhoto != null)
            {
                ProfileImage.Source = ImageSource.FromFile(_pickedPhoto.FullPath);

                if (BindingContext is user _user)
                {
                    _user.imageDIR = _pickedPhoto.FullPath;
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to pick image: {ex.Message}", "OK");
        }
    }

    private async void OnClickSavePictureBtn(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(_pickedPhoto.FullPath) && File.Exists(_pickedPhoto.FullPath))
            {
                using var stream = File.OpenRead(_pickedPhoto.FullPath);

                ProfileImage.Source = ImageSource.FromStream(() => File.OpenRead(_pickedPhoto.FullPath));

                using var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
                byte[] imageBytes = memoryStream.ToArray();

                string fileName = Path.GetFileName(_pickedPhoto.FullPath);

                var result = await _userservice.UploadProfileImage(imageBytes, fileName);

                await DisplayAlert("Upload Picture", result.dataModel.apiResult.msg, "OK");

                var currentPage = Navigation.NavigationStack[Navigation.NavigationStack.Count - 1];
                Navigation.RemovePage(currentPage);
            }
            else
            {
                await DisplayAlert("Warning", "No image selected.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to save image: {ex.Message}", "OK");
        }
    }
}
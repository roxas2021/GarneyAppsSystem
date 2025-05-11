using ApplicationService.EntityModel;

namespace GarneyAppSystem.Views.Home;

public partial class UploadPage : ContentPage
{
    public List<Posts> Posts { get; set; }

    public UploadPage()
	{
		InitializeComponent();
		LoadData();
	}

	public void LoadData()
	{
        Posts = new List<Posts>();

        Posts samplePost = new Posts
        {
            PostID = 1,
            UserID = 101,
            Content = "Waiting for the Garbage truck to collect this.",
            ImagePath = "garbage1.jpg",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            IsDeleted = 0,
            Privacy = "public"
        };

        Posts.Add(samplePost);

        Posts samplePost2 = new Posts
        {
            PostID = 1,
            UserID = 101,
            Content = "Please take our garbage for today.",
            ImagePath = "garbage2.jpg",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            IsDeleted = 0,
            Privacy = "public"
        };

        Posts.Add(samplePost2);

        BindingContext = this;
    }
}
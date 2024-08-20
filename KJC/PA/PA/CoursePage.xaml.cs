namespace PA;

public partial class CoursePage : ContentPage
{
	private DBService _dbService;
	private int courseCount;
	private int currentTermID;
	public CoursePage(int termID, DBService dBService)
	{
		InitializeComponent();
		_dbService = dBService;
		currentTermID = termID;
        courseCount = Task.Run(async () => await _dbService.GetCoursesWithID(currentTermID)).Result.Count;
        Task.Run(async () => courseView.ItemsSource = await _dbService.GetCoursesWithID(currentTermID));
        
	}



	private void PopulateCourseInformation(int termID)
	{

	}

    private async void AddCourseButton_Clicked(object sender, EventArgs e)
    {
        if (courseCount >= 6)
        {
            await DisplayAlert("At Course Limit", "You already have the maximum amount of courses for this term", "ok");
        }
        else
        {

        }
    }

    private async void UpdateCourseButton_Clicked(object sender, EventArgs e)
    {
		
    }

    private void DeleteCourseButton_Clicked(object sender, EventArgs e)
    {

    }

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }
}

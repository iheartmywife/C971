namespace PA;

public partial class AddCourse : ContentPage
{
	private readonly DBService _dbService;
	private readonly int currentTermID;
	public AddCourse(int termID, DBService dbService)
    {
        InitializeComponent();
        _dbService = dbService;
		currentTermID = termID;
        
	}

    private async void addCourseButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            await _dbService.CreateCourse(new Course
            {
                TermID = currentTermID,
                CourseName = CourseNameField.Text,
                CourseStartDate = CourseStartPicker.Date,
                CourseEndDate = CourseEndPicker.Date,
                Status = (StatusPicker.SelectedItem).ToString(),
                CIName = CINameField.Text,
                CIPhone = CIPhoneField.Text,
                CIEmail = CIEmailField.Text,

            });
        }
        catch (Exception ex) 
        {
            await DisplayAlert("error", "One or more fields was left blank and must be filled out", "ok");
        }
        finally
        {
            await Navigation.PopModalAsync();
        }

    }

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}
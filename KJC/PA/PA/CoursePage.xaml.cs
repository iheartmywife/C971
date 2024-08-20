using System.Collections.ObjectModel;

namespace PA;

public partial class CoursePage : ContentPage
{
	private readonly DBService _dbService;
	private int courseCount;
	private readonly int currentTermID;
    private readonly string _termName;
    private ObservableCollection<Course> _courses;
	public CoursePage(int termID, DBService dBService, string termName)
	{
		InitializeComponent();
		_dbService = dBService;
		currentTermID = termID;
        _termName = termName;
        _courses = new ObservableCollection<Course>(Task.Run(async () => await _dbService.GetCoursesWithID(currentTermID)).Result);
        courseCount = _courses.Count;
        courseView.ItemsSource = _courses;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ReloadPage();
    }

    private void ReloadPage()
    {
        _courses = new ObservableCollection<Course>(Task.Run(async () => await _dbService.GetCoursesWithID(currentTermID)).Result);
        courseCount = _courses.Count;
        courseView.ItemsSource = _courses;
    }

    private async void AddCourseButton_Clicked(object sender, EventArgs e)
    {
        if (courseCount >= 6)
        {
            await DisplayAlert("At Course Limit", "You already have the maximum amount of courses for this term", "ok");
        }
        else
        {
            await Navigation.PushModalAsync(new AddCourse(currentTermID, _dbService));
        }
        courseCount = Task.Run(async () => await _dbService.GetCoursesWithID(currentTermID)).Result.Count;
        
    }

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }

    private async void courseView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var course = (Course)e.Item;
        var doSomething = await DisplayActionSheet("What Would You Like To Do?", "Cancel", null, "Change/Update Course Info", "Delete Course", "Add Assessment Info");

        switch (doSomething)
        {
            case "Change/Update Course Info":

                await Navigation.PushModalAsync(new UpdateCourse(course, _dbService));
                break;
            case "Delete Course":
                await _dbService.DeleteCourse(course);
                ReloadPage();
                break;
            case "Add Assessment Info":
                break;
        }
    }
}

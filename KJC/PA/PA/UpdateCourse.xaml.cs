using static Microsoft.Maui.ApplicationModel.Permissions;
using System.Xml.Linq;

namespace PA;

public partial class UpdateCourse : ContentPage
{
	private readonly DBService _dbService;
	private readonly Course currentCourse;
	public UpdateCourse(Course course, DBService dbService)
    {
        InitializeComponent();
        _dbService = dbService;
		currentCourse = course;
		PopulateEntryFields(currentCourse);
    }

	private void PopulateEntryFields(Course course)
	{
		CourseNameField.Text = course.CourseName;
		CourseStartPicker.Date = course.CourseStartDate;
		CourseEndPicker.Date = course.CourseEndDate;
		StatusPicker.SelectedItem = course.Status;
		CINameField.Text = course.CIName;
		CIPhoneField.Text = course.CIPhone;
		CIEmailField.Text = course.CIEmail;

		
	}

	private async void UpdateCourseButton_Clicked(object sender, EventArgs e)
	{
		try
		{
			await _dbService.UpdateCourse(new Course
			{
				ID = currentCourse.ID,
				TermID = currentCourse.TermID,
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
			await DisplayAlert($"{ex}", "One or more fields was left blank and must be filled out", "ok");
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

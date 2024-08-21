using Plugin.LocalNotification;

namespace PA;

public partial class NotificationHandler : ContentPage
{
	private Course currentCourse;
    internal int notif_id;
	public NotificationHandler(Course course)
	{
		InitializeComponent();
		currentCourse = course;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		
    }

    private void CourseStartButton_Clicked(object sender, EventArgs e)
    {
        var request = new NotificationRequest()
        {
            NotificationId = notif_id++,
            Title = $" {currentCourse.CourseName} Start",
            Subtitle = "PA Starts Today!",

            Schedule = new NotificationRequestSchedule()
            {
                NotifyTime = currentCourse.CourseStartDate,
            }
        };
    }

    private void CourseEndButton_Clicked(object sender, EventArgs e)
    {
        var request = new NotificationRequest()
        {
            NotificationId = notif_id++,
            Title = $" {currentCourse.CourseName} End",
            Subtitle = "PA Starts Today!",

            Schedule = new NotificationRequestSchedule()
            {
                NotifyTime = currentCourse.CourseEndDate,
            }
        };
    }

    private void PAStartButton_Clicked(object sender, EventArgs e)
    {
        var request = new NotificationRequest()
        {
            NotificationId = notif_id++,
            Title = $" {currentCourse.PA} Anticipated Start",
            Subtitle = "PA Starts Today!",

            Schedule = new NotificationRequestSchedule()
            {
                NotifyTime = PAStartPicker.Date,
            }
        };
    }

    private void PAEndButton_Clicked(object sender, EventArgs e)
    {
        var request = new NotificationRequest()
        {
            NotificationId = notif_id++,
            Title = $" {currentCourse.PA} Anticipated End",
            Subtitle = "PA Ends Today!",

            Schedule = new NotificationRequestSchedule()
            {
                NotifyTime = PAEndPicker.Date,
            }
        };
    }

    private void OAStartButton_Clicked(object sender, EventArgs e)
    {
        var request = new NotificationRequest()
        {
            NotificationId = notif_id++,
            Title = $" {currentCourse.OA} Anticipated Start",
            Subtitle = "OA Starts Today!",

            Schedule = new NotificationRequestSchedule()
            {
                NotifyTime = OAStartPicker.Date,
            }
        };
    }

    private void OAEndButton_Clicked(object sender, EventArgs e)
    {
        var request = new NotificationRequest()
        {
            NotificationId = notif_id++,
            Title = $" {currentCourse.OA} Anticipated End",
            Subtitle = "OA Ends Today!",

            Schedule = new NotificationRequestSchedule()
            {
                NotifyTime = OAEndPicker.Date,
            }
        };
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {

    }

    private async void DoneButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}
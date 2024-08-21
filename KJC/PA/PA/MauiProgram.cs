using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;

namespace PA
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseLocalNotification()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<DBService>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<CoursePage>();
            builder.Services.AddTransient<AddCourse>();
            builder.Services.AddTransient<UpdateCourse>();
            builder.Services.AddTransient<NotificationHandler>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

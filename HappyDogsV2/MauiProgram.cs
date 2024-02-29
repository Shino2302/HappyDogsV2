using HappyDogsV2.ViewModel;
using HappyDogsV2.Views;
using Microsoft.Extensions.Logging;
using Firebase.Database;
using Firebase.Database.Query;


namespace HappyDogsV2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
        public static void Registrar()
        {
            FirebaseClient client = new FirebaseClient("https://happydogdb-55b97-default-rtdb.firebaseio.com/");
        }
    }
}
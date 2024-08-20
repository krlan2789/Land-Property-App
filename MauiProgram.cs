using CommunityToolkit.Maui;
using Land_Property_App.Database;
using Land_Property_App.Helper;
using Land_Property_App.Models;
using Land_Property_App.ViewModels;
using Land_Property_App.Views;
using Microsoft.Extensions.Logging;

namespace Land_Property_App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiMaps()
                .ConfigureEssentials(essentials =>
                {
                    essentials.UseVersionTracking();
                });
            
#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<DatabaseContext>();
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<HomePage>();
            //builder.Services.AddSingleton<ISharedService, SharedService>();
            
            builder.Services.AddTransient<MapsViewModel>();
            builder.Services.AddTransient<DetailsViewModel>();
            builder.Services.AddTransient<DetailsSpecViewModel>();

            return builder.Build();
        }
    }
}

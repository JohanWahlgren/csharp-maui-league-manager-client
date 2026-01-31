using vt25_sysb24_it_client_csharp_vt25_sysb24_booligans.MauiClient.Pages;
using vt25_sysb24_it_client_csharp_vt25_sysb24_booligans.MauiClient.Services;
using vt25_sysb24_it_client_csharp_vt25_sysb24_booligans.MauiClient.ViewModels;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace vt25_sysb24_it_client_csharp_vt25_sysb24_booligans.MauiClient;

public static class MauiProgram // Creates and configures MAUI app — setting fonts, libraries, services, viewmodels, pages, and logging.
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder(); // Creates a builder object that sets up app
        builder
            .UseMauiApp<App>()

            .UseMauiCommunityToolkit() // Adds CommunityToolkit.Maui library for additional controls and helpers, like expander

            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Services - Singleton for API services, one instance for entire app
        builder.Services.AddSingleton<ITeamService, TeamsService>();
        builder.Services.AddSingleton<IPlayerService, PlayerService>();

        // ViewModels - Singleton used to preserve state between tab switches
        builder.Services.AddSingleton<TeamsViewModel>();
        builder.Services.AddSingleton<PlayersViewModel>();
        builder.Services.AddSingleton<MainViewModel>();

        // Pages - Transient for UI components, new instance each time a page is navigated to
        builder.Services.AddTransient<TeamsPage>();
        builder.Services.AddTransient<PlayersPage>();
        builder.Services.AddTransient<MainPage>();

#if DEBUG // Logging - Adds debug logging for development
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}
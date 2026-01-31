using System.Windows.Input;

namespace vt25_sysb24_it_client_csharp_vt25_sysb24_booligans.MauiClient.ViewModels;

public class MainViewModel
{
    public ICommand NavigateToTeamsCommand { get; }
    public ICommand NavigateToPlayersCommand { get; }

    public MainViewModel() // When the MainViewModel is created, the NavigateToTeamsCommand and NavigateToPlayersCommand are initialized
    {
        NavigateToTeamsCommand = new Command(async () =>
            await Shell.Current.GoToAsync("teams")); // Navigates to the "teams" route, registered in AppShell.xaml.cs

        NavigateToPlayersCommand = new Command(async () =>
            await Shell.Current.GoToAsync("players"));
    }
}
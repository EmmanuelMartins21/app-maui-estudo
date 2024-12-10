using app_maui_estudo.Views.Pages;
using Microsoft.Maui.Storage;
using Microsoft.Maui.Controls;
#if ANDROID
using Android.Content;
using Android.Provider;
using AndroidX.Activity.Result;
#endif

namespace app_maui_estudo;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new ProtegidaPrincipal();
    }

    protected override void OnStart()
    {
        base.OnStart();
        RequestPermissionsOnStartup();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);
        // Pode alterar as propriedades da tela
        window.Width = 280;
        window.Height = 320;
        return window;
    }

    private async void RequestPermissionsOnStartup()
    {
#if ANDROID
        var writePermissionStatus = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
        var readPermissionStatus = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

        if (writePermissionStatus != PermissionStatus.Granted || readPermissionStatus != PermissionStatus.Granted)
        {
            var writePermission = await Permissions.RequestAsync<Permissions.StorageWrite>();
            var readPermission = await Permissions.RequestAsync<Permissions.StorageRead>();

            if (writePermission != PermissionStatus.Granted || readPermission != PermissionStatus.Granted)
            {
                // Se as permissões não foram concedidas, mostre um alerta e redirecione para as configurações
                await Application.Current.MainPage.DisplayAlert(
                    "Permissões Necessárias",
                    "O aplicativo precisa de permissões para acessar o armazenamento. Por favor, habilite-as nas configurações.",
                    "OK"
                );

            }
        }
#endif
    }
}

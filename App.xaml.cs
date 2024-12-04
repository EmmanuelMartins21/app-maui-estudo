using app_maui_estudo.Views.Pages;

namespace app_maui_estudo;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new Login();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);
        // Pode alterar as propriedades da tela
        window.Width = 280;
        window.Height = 320;
        return window;
    }

}


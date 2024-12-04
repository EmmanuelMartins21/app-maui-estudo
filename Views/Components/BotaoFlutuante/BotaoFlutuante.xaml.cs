using System.Windows.Input;

namespace app_maui_estudo.Views.Components.BotaoFlutuante;

public partial class BotaoFlutuante : ContentView
{
    // Propriedade que será configurada para definir a ação do clique
    public static readonly BindableProperty ClickCommandProperty =
        BindableProperty.Create(
            nameof(ClickCommand),
            typeof(ICommand),
            typeof(BotaoFlutuante),
            default(ICommand));

    public ICommand ClickCommand
    {
        get => (ICommand)GetValue(ClickCommandProperty);
        set => SetValue(ClickCommandProperty, value);
    }

    public BotaoFlutuante()
    {
        InitializeComponent();
    }

    // Manipulador de clique
    private void OnBtnFlutuanteClicked(object sender, EventArgs e)
    {
        if (ClickCommand?.CanExecute(null) == true)
        {
            ClickCommand.Execute(null);
        }
    }

    private void btnFlutuante_Clicked(object sender, EventArgs e)
    {

    }
}
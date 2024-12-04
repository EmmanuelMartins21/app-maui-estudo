using app_maui_estudo.Models;

namespace app_maui_estudo.Views.Pages;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            var usuariosCadastrados = Utils.RetornarUsuariosDisponiveis();
            var exiteUsuario = usuariosCadastrados.Any(x => x.Email == txt_email.Text &&
                                                       x.Senha == txt_senha.Text && x.Ativo);

            if(exiteUsuario)
            {
                // Armazena no secureStorage (local) os dados do usuario logado
                await SecureStorage.Default.SetAsync("usuario_logado", txt_email.Text);

                App.Current.MainPage = new ProtegidaPrincipal();
            }
            else
            {
                throw new Exception("Usuario sem acesso ao sistema");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Fechar");
        }
    }
}
namespace app_maui_estudo.Views.Pages;

public partial class ProtegidaPrincipal : ContentPage
{
    public ProtegidaPrincipal()
    {
        string usuario = SecureStorage.Default.GetAsync("usuario_logado").Result;
        InitializeComponent();
        this.txt_usuario.Text = Utils.RetornarNomeUsuario(usuario);               
    }

    private void btnSair_Clicked(object sender, EventArgs e)
    {
        SecureStorage.Default.RemoveAll();
        App.Current.MainPage = new Login();
    }
}
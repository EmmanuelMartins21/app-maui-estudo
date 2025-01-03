using System.IO;
namespace app_maui_estudo.Views.Pages;

#if ANDROID
                    using Android.App;
                    using Android.Content;
                    using Android.OS;

                    // rootPath ser� um diret�rio privado no armazenamento principal (por exemplo: /storage/emulated/0/Android/data/com.seuprojeto/files)
#endif


public partial class ProtegidaPrincipal : ContentPage
{
    public ProtegidaPrincipal()
    {
        string usuario = SecureStorage.Default.GetAsync("usuario_logado").Result;
        InitializeComponent();
        this.txt_usuario.Text = Utils.RetornarNomeUsuario(usuario ?? "admin");
        this.btn_mapa.IsEnabled = false;
    }

    private void btnSair_Clicked(object sender, EventArgs e)
    {
        SecureStorage.Default.RemoveAll();
        App.Current.MainPage = new Login();
    }

    private void btn_mapa_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Ol�", "O mapa ainda est� em desenvolvimento", "sair");
    }

    private async void btn_galeria_Clicked(object sender, EventArgs e)
    {
        try
        {
            
                // Permite selecionar m�ltiplos arquivos
                var result = await FilePicker.PickMultipleAsync(new PickOptions
                {
                    PickerTitle = "Selecione as fotos",
                    FileTypes = FilePickerFileType.Images // Apenas imagens
                });

                if (result != null)
                {
                    string rootPath = Application.Context.GetExternalFilesDir(null)?.AbsolutePath;



                    var targetFolder = Path.Combine(rootPath, "Dados", "Fotos");

                    // Cria a pasta se n�o existir
                    if (!Directory.Exists(targetFolder))
                    {
                        Directory.CreateDirectory(targetFolder);
                    }

                    foreach (var file in result)
                    {
                        var extension = Path.GetExtension(file.FileName);

                        string newFileName = $"Foto_{DateTime.Now:yyyyMMdd_HHmmss_fff}{extension}";

                        var targetPath = Path.Combine(targetFolder, newFileName);

                        // Salva o arquivo no novo local
                        using var stream = await file.OpenReadAsync();
                        using var fileStream = File.Create(targetPath);
                        await stream.CopyToAsync(fileStream);
                    }

                }
            
        }
        catch (Exception ex)
        {
        }

    }

    private async Task<bool> RequestStoragePermissionAsync()
    {
        var writePermission = await Permissions.RequestAsync<Permissions.StorageWrite>();
        var readPermission = await Permissions.RequestAsync<Permissions.StorageRead>();
        //return writePermission == PermissionStatus.Granted && readPermission == PermissionStatus.Granted;
        return true;
    }
}

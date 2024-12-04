using app_maui_estudo.Models;

namespace app_maui_estudo;

public static class Utils
{
    private static readonly List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario
            {
                Nome = "João Silva",
                Email = "joao.silva@email.com",
                Senha = "senha123",
                Ativo = true
            },
            new Usuario
            {
                Nome = "Maria Oliveira",
                Email = "maria.oliveira@email.com",
                Senha = "senha456",
                Ativo = true
            },
            new Usuario
            {
                Nome = "Carlos Pereira",
                Email = "carlos.pereira@email.com",
                Senha = "senha789",
                Ativo = false
            },
            new Usuario
            {
                Nome = "Ana Souza",
                Email = "ana.souza@email.com",
                Senha = "senha101",
                Ativo = true
            },
            new Usuario
            {
                Nome = "Lucas Lima",
                Email = "lucas.lima@email.com",
                Senha = "senha202",
                Ativo = true
            }
        };


    public static List<Usuario> RetornarUsuariosDisponiveis() => usuarios;
    public static string RetornarNomeUsuario(string email) => usuarios.Find(x => x.Email == email).Nome ?? string.Empty;
}

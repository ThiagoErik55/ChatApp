using ChatApp.Business.Services;
using ChatApp.Model.Users;
using System;

class Program
{
    static UsuarioService usuarioService = new UsuarioService();
    static Usuario usuarioLogado = null;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== BEM VINDO AO POOCHAT ====");
            Console.WriteLine("1. Cadastre-se");
            Console.WriteLine("2. Fazer Login");
            Console.WriteLine("3. Sair");
            Console.WriteLine("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarUsuario();
                    break;
                case "2":
                    FazerLogin();
                    break;
                case "3":
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void CadastrarUsuario()
    {
        Console.Clear();
        Console.WriteLine("==== CADASTRO DE USUÁRIO ====");
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Senha: ");
        string senha = Console.ReadLine();

        int novoId = usuarioService.ObterTotalUsuarios() + 1;
        var usuario = new Usuario(novoId, nome, email, senha, StatusUsuario.Offline);
        usuarioService.CadastrarUsuario(usuario);

        Console.WriteLine("Usuário cadastrado com sucesso!");
        Console.ReadLine();
    }

    static void FazerLogin()
    {
        Console.Clear();
        Console.WriteLine("==== LOGIN ====");
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Senha: ");
        string senha = Console.ReadLine();

        usuarioLogado = usuarioService.AutenticarUsuario(email, senha);

        if (usuarioLogado != null)
        {
            Console.WriteLine("Login efetuado com sucesso!");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Email ou senha inválidos");
            Console.ReadLine();
        }
    }
}
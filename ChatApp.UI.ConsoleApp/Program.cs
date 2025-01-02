using ChatApp.Business.Services;
using ChatApp.Model.Users;

class Program
{
    static UsuarioService usuarioService = new();
    static ConversaService conversaService = new();
    static MensagemService mensagemService = new();
    static Usuario usuarioLogado = null;

    static void Main(string[] args)
    {
        while (true)
        {
            if (usuarioLogado == null)
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Chat ===");
                Console.WriteLine("1. Registrar novo usuário");
                Console.WriteLine("2. Fazer login");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        RegistrarUsuario();
                        break;
                    case "2":
                        FazerLogin();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                MenuPrincipal();
            }
        }
    }

    static void RegistrarUsuario()
    {
        Console.WriteLine("=== Registrar Novo Usuário ===");
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Senha: ");
        string senha = Console.ReadLine();

        try
        {
            usuarioLogado = usuarioService.RegistrarUsuario(nome, email, senha);
            Console.WriteLine("Usuário registrado com sucesso! Você está logado.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao registrar: {ex.Message}");
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void FazerLogin()
    {
        Console.WriteLine("=== Login ===");
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Senha: ");
        string senha = Console.ReadLine();

        try
        {
            usuarioLogado = usuarioService.AutenticarUsuario(email, senha);
            Console.WriteLine("Login bem-sucedido!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao fazer login: {ex.Message}");
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void MenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine($"Bem-vindo, {usuarioLogado.Nome}!");
        Console.WriteLine("1. Criar conversa");
        Console.WriteLine("2. Enviar mensagem");
        Console.WriteLine("3. Ver mensagens não lidas");
        Console.WriteLine("0. Logout");
        Console.Write("Escolha uma opção: ");
        var opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                CriarConversa();
                break;
            case "2":
                EnviarMensagem();
                break;
            case "3":
                VerMensagensNaoLidas();
                break;
            case "0":
                usuarioLogado = null;
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }

    static void CriarConversa()
    {
        Console.WriteLine("=== Criar Nova Conversa ===");
        Console.Write("Digite o nome de outro participante: ");
        string nomeParticipante = Console.ReadLine();

        try
        {
            var participante = new Usuario { Nome = nomeParticipante }; 
            var conversa = conversaService.CriarConversa(new List<Usuario> { usuarioLogado, participante });
            Console.WriteLine($"Conversa criada com sucesso! ID: {conversa.Id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao criar conversa: {ex.Message}");
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void EnviarMensagem()
    {
        Console.WriteLine("=== Enviar Mensagem ===");
        Console.Write("ID da conversa: ");
        int conversaId = int.Parse(Console.ReadLine());
        Console.Write("Mensagem: ");
        string c

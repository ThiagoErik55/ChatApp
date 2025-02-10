using ChatApp.Business.Services;
using ChatApp.Model.Users;
using System;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

class Program
{
    static UsuarioService usuarioService = new UsuarioService();
    static Usuario usuarioLogado = null;
    static ConversaService conversaService = new ConversaService();
    static MensagemService mensagemService = new MensagemService();

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
            Console.Clear();
            Console.WriteLine($"Login efetuado com sucesso!\nBem vindo {usuarioLogado.Nome}");
            Console.ReadLine();
            MenuUsuarioLogado();
        }
        else
        {
            Console.WriteLine("Email ou senha inválidos");
            Console.ReadLine();
        }
    }

    static void MenuUsuarioLogado()
    {
        while (usuarioLogado != null)
        {
            Console.Clear();
            Console.WriteLine($" ==== MENU - {usuarioLogado.Nome} ====");
            Console.WriteLine("1. Iniciar uma nova conversa");
            Console.WriteLine("2. Listar minhas conversas");
            Console.WriteLine("3. Enviar mensagem");
            Console.WriteLine("4. Ver mensagens não lidas");
            Console.WriteLine("5. Atualizar status");
            Console.WriteLine("6. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    IniciarNovaConversa();
                    break;
                case "2":
                    ListarConversas();
                    break;
                case "3":
                    EnviarMensagem();
                    break;
                case "4":
                    VerMensagensNaoLidas();
                    break;
                case "5":
                    AtualizarStatus();
                    break;
                case "6":
                    Console.WriteLine("Logout realizado com sucesso!");
                    usuarioLogado = null;
                    return;
                default:
                    Console.WriteLine("Opção inválida");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void IniciarNovaConversa()
    {
        Console.Clear();
        Console.WriteLine("==== INICIAR NOVA CONVERSA ====\n\n");

        Console.Write("Digite o email do usuário com quem deseja conversar: ");
        string email = Console.ReadLine();

        Usuario participante = usuarioService.AutenticarUsuario(email, "");

        if (participante == null)
        {
            Console.WriteLine("Usuário não encontrado");
            Console.ReadLine();
            return;
        }

        var novaConversa = conversaService.CriarConversa(new List<Usuario> { usuarioLogado, participante });

        Console.WriteLine($"Conversa iniciada com {participante.Nome}!\nID da conversa: {novaConversa.ConversaId}");
        Console.ReadLine();
    }

    static void ListarConversas()
    {
        Console.Clear();
        Console.WriteLine("==== MINHAS CONVERSAS ====\n\n");

        var conversas = conversaService.ObterConversasUsuario(usuarioLogado);

        if (!conversas.Any())
        {
            Console.WriteLine("Você não possui conversas!");
            Console.ReadLine();
            return;
        }

        foreach (var conversa in conversas)
        {
            var participantes = string.Join(", ", conversa.Participantes.Where(p => p != usuarioLogado).Select(p => p.Nome));
            Console.WriteLine($"ID: {conversa.ConversaId} | Participantes: {participantes} | Última mensagem: {conversa.DataUltimaMensagem}");
        }

    }

    static void EnviarMensagem()
    {
        Console.Clear();
        Console.WriteLine("==== ENVIAR MENSAGEM ====");

        var conversas = conversaService.ObterConversasUsuario(usuarioLogado);
        if (!conversas.Any())
        {
            Console.WriteLine("Você não tem conversas. Inicie uma conversa primeiro.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Suas conversas:");
        foreach (var conversa in conversas)
        {
            var participantes = string.Join(", ", conversa.Participantes.Where(p => p != usuarioLogado).Select(p => p.Nome));
            Console.WriteLine($"ID: {conversa.ConversaId} | Participantes: {participantes}");
        }

        Console.Write("\nDigite o ID da conversa para enviar uma mensagem: ");
        if (!int.TryParse(Console.ReadLine(), out int conversaId))
        {
            Console.WriteLine("ID inválido! Pressione Enter para voltar ao menu.");
            Console.ReadLine();
            return;
        }

        var conversaSelecionada = conversaService.ObterConversa(conversaId);
        if (conversaSelecionada == null)
        {
            Console.WriteLine("Conversa não encontrada! Pressione Enter para voltar ao menu.");
            Console.ReadLine();
            return;
        }

        Console.Write("Digite sua mensagem: ");
        string conteudo = Console.ReadLine();

        mensagemService.EnviarMensagem(usuarioLogado, conversaId, conteudo);

        Console.WriteLine("Mensagem enviada com sucesso!");
        Console.ReadLine();
    }

    static void VerMensagensNaoLidas()
    {
        Console.Clear();
        Console.WriteLine("==== MENSAGENS NÃO LIDAS ====");

        var mensagensNaoLidas = mensagemService.ObterMensagensNaoLidas(usuarioLogado);

        if (!mensagensNaoLidas.Any())
        {
            Console.WriteLine("Você não tem mensagens não lidas.");
            Console.ReadLine();
            return;
        }

        foreach (var mensagem in mensagensNaoLidas)
        {
            Console.WriteLine($"De: {mensagem.Remetente.Nome} | Mensagem: {mensagem.Conteudo} | Enviada em: {mensagem.DataEnvio}");
            mensagemService.MarcarMensagemComoVisualizada(mensagem.Id);
        }

        Console.WriteLine("\nPressione Enter para continuar.");
        Console.ReadLine();
    }

    static void AtualizarStatus()
    {
        Console.Clear();
        Console.WriteLine("==== ATUALIZAR STATUS ====\n");
        Console.WriteLine("Escolha um novo status:");
        Console.WriteLine("1. Online");
        Console.WriteLine("2. Offline");
        Console.WriteLine("3. Ausente");
        Console.Write("Opção: ");

        string opcao = Console.ReadLine();
        StatusUsuario novoStatus;

        switch (opcao)
        {
            case "1":
                novoStatus = StatusUsuario.Online;
                break;
            case "2":
                novoStatus = StatusUsuario.Offline;
                break;
            case "3":
                novoStatus = StatusUsuario.Ausente;
                break;
            default:
                Console.WriteLine("Opção inválida! Pressione Enter para tentar novamente.");
                Console.ReadLine();
                return;
        }

        usuarioService.AtualizarStatusUsuario(usuarioLogado.Id, novoStatus);
        usuarioLogado.AtualizarStatus(novoStatus);

        Console.WriteLine($"Seu status foi atualizado para {novoStatus}.");
        Console.ReadLine();
    }

}
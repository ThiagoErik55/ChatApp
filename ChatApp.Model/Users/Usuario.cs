using System.ComponentModel;

namespace ChatApp.Model.Users;

public class Usuario
{
    public int Id { get; }
    public string Nome { get; }
    public string Email { get; }
    public string SenhaHash { get; private set; }  
    public StatusUsuario Status { get; private set; } 

    public Usuario(int id, string nome, string email, string senhaHash, StatusUsuario status)
    {
        Id = id;
        Nome = nome;
        Email = email;
        SenhaHash = senhaHash;
        Status = status;
    }

    public void AlterarSenha(string novaSenhaHash)
    {
        SenhaHash = novaSenhaHash;
    }

    public void AtualizarStatus(StatusUsuario novoStatus)
    {
        Status = novoStatus;
    }
}
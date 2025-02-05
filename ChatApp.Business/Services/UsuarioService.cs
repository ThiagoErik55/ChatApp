using ChatApp.Model.Users;  
using System.Collections.Generic;
using System.Linq;

namespace ChatApp.Business.Services
{
    public class UsuarioService
    {

        private static List<Usuario> usuarios = new List<Usuario>();  //guardar dados em memória

        public Usuario AutenticarUsuario(string email, string senha)
        {
            return usuarios.FirstOrDefault(u => u.Email == email && u.SenhaHash == senha);
        }

        public void AtualizarStatusUsuario(int usuarioId, StatusUsuario status)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == usuarioId);
            if (usuario != null)
            {
                usuario.AtualizarStatus(status);
            }
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public int ObterTotalUsuarios()
        {
            return usuarios.Count;
        }

    }
}
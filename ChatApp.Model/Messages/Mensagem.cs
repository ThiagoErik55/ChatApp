using ChatApp.Model.Users;

namespace ChatApp.Model.Messages
{
    public class Mensagem
    {
        public int Id { get; }
        public string Conteudo { get; }
        public DateTime DataEnvio { get; }
        public Usuario Remetente { get; }
        public bool Visualizada { get; set; }
        public int? RespostaId { get; }

        public Mensagem() { }
        
        public Mensagem(string conteudo, Usuario remetente)
        {
            Conteudo = conteudo;
            Remetente = remetente;
            DataEnvio = DateTime.Now;
            Visualizada = false;
        }
    }
}
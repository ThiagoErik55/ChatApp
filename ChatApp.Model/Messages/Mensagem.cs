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

        public Mensagem(int id, string conteudo, DateTime dataEnvio, Usuario remetente, bool visualizada, int? respostaId = null)
        {
            Id = id;
            Conteudo = conteudo;
            DataEnvio = dataEnvio;
            Remetente = remetente;
            Visualizada = visualizada;
            RespostaId = respostaId;
        }
    }
}
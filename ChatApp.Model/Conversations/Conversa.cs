namespace ChatApp.Model.Conversations
{
    using ChatApp.Model.Users;
    using ChatApp.Model.Messages;

    public class Conversa
    {
        public int Id { get; set; } 
        public ICollection<Usuario> Participantes { get; set; }
        public ICollection<Mensagem> Mensagens { get; set; } 
        public DateTime DataUltimaMensagem { get; set; } 

        public Conversa()
        {
            Participantes = new List<Usuario>();
            Mensagens = new List<Mensagem>();
        }
    }
}

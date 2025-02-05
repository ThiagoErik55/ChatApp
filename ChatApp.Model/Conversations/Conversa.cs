using ChatApp.Model.Users;

namespace ChatApp.Model.Conversations
{
    public class Conversa
    {
        public int ConversaId { get; }
        public List<Usuario> Participantes { get; set; }
        public List<Mensagem> Mensagens { get; set; }
        public DateTime DataUltimaMensagem { get; }

        public Conversa(int conversaId, List<Usuario> participantes, List<Mensagem> mensagens, DateTime dataUltimaMensagem)
        {
            ConversaId = conversaId;
            Participantes = participantes;
            Mensagens = mensagens;
            DataUltimaMensagem = dataUltimaMensagem;
        }
    }
}
using ChatApp.Model.Messages;
using ChatApp.Model.Users;

namespace ChatApp.Model.Conversations
{
    public class Conversa
    {
        public int ConversaId { get; }
        public List<Usuario> Participantes { get; set; }
        public List<Mensagem> Mensagens { get; set; }
        public DateTime DataUltimaMensagem { get; }

        public Conversa(){ }

        public Conversa(List<Usuario> participantes)
        {
            Participantes = participantes;
            DataUltimaMensagem = DateTime.Now;
        }
    }
}
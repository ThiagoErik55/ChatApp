using ChatApp.Model.Messages;
using ChatApp.Model.Users;

namespace ChatApp.Business.Services
{
    public class MensagemService
    {
        public void EnviarMensagem(Usuario remetente, int conversaId, string conteudo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mensagem> ObterMensagensNaoLidas(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void MarcarMensagemComoVisualizada(int mensagemId)
        {
            throw new NotImplementedException();
        }
    }
}

using ChatApp.Model.Messages;

namespace ChatApp.Business.Observers
{
    public interface INotificationObserver
    {
        void NotificarMensagemRecebida(Mensagem mensagem);
    }
}

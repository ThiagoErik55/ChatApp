using ChatApp.Model.Messages;

namespace ChatApp.Business.Observers
{
    public interface INotificationObserver
    {
        void NotificarMensagemRecebida(Mensagem mensagem)
        {
            // Método para notificar
            // a chegada de uma nova mensagem.
        }
    }
}


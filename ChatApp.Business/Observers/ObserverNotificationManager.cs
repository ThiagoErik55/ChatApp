using ChatApp.Model.Messages;

namespace ChatApp.Business.Observers
{
    public class ObserverNotificationManager
    {
        private readonly List<INotificationObserver> observers = new();

        public void RegistrarObserver(INotificationObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoverObserver(INotificationObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotificarObservers(Mensagem mensagem)
        {
            foreach (var observer in observers)
            {
                observer.NotificarMensagemRecebida(mensagem);
            }
        }
    }
}

using ChatApp.Model.Messages;

namespace ChatApp.Business.Observers
{
	public class ObserverNotificationManager
	{
		private List<INotificationObserver> _observers = new List<INotificationObserver>();
		public void RegistrarObserver(INotificationObserver observer)
		{
			_observers.Add(observer);
		}

		public void RemoverObserver(INotificationObserver observer)
		{
			_observers.Remove(observer);
		}

		public void NotificarObservers(Mensagem mensagem)
		{
			foreach (var observer in _observers)
			{
				observer.NotificarMensagemRecebida(mensagem);
			}
		}
	}

}
namespace ChatApp.Business.Services;

public class ConversaService
{
    private static List<Conversa> conversas = new List<Conversa>();  //armazenar conversas enquanto está sem database

    public Conversa CriarConversa(ICollection<Usuario> participantes)
	{
		var novaConversa = new Conversa(conversas.Count + 1, participantes.ToList(), new List<Mensagem>(), DateTime.Now);
		conversas.Add(novaConversa);
		return novaConversa;
    }

	public Conversa ObterConversa(int conversaId)
	{
        return conversas.FirstOrDefault(c => c.ConversaId == conversaId);
    }

    public IEnumerable<Conversa> ObterConversasUsuario(Usuario usuario)
	{
        return conversas.Where(c => c.Participantes.Contains(usuario)).ToList();
    }
}


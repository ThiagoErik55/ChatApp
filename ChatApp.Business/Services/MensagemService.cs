using ChatApp.Model.Users;
using ChatApp.Model.Messages;
using System.Collections.Generic;
using System.Linq;

namespace ChatApp.Business.Services;

public class MensagemService
{
    private static List<Mensagem> mensagens = new List<Mensagem>(); 

    public void EnviarMensagem(Usuario remetente, int conversaId, string conteudo)
    {
        var novaMensagem = new MensagemService(mensagens.Count + 1, conteudo, DateTime.now, remetente, false);
        mensagens.Add(novaMensagem);
    }

    public IEnumerable<Mensagem> ObterMensagensNaoLidas(Usuario usuario)
    {
        return mensagens.Where(m => !m.Visualizada && m.Remetente != usuario).ToList();
    }

    public void MarcarMensagemComoVisualizada(int mensagemId)
    {
        var mensagem = mensagens.FirstOrDefault(m => m.Id == mensagemId);
        if (mensagem != null)
        {
            mensagem.Visualizada = true;
        }
    }
}

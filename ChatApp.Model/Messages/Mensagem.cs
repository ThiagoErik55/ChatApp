namespace ChatApp.Model.Messages
{
    using ChatApp.Model.Users;

    public class Mensagem
    {
        public int Id { get; set; }
        public string Conteudo { get; set; }
        public Datetime DataEnvio { get; set; }
        public Usuario Remetente { get; set; }
        public bool Visualizada { get; set; }
        public int? RespostaId { get; set; }
    }
}
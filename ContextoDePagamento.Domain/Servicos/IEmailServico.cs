namespace ContextoDePagamento.Domain.Servicos
{
    public interface IEmailServico
    {
        void Enviar(string destinatario, string email, string assunto, string corpo);
    }
}
using ContextoDePagamento.Domain.Servicos;

namespace ContextoDePagamento.Tests.Mocks
{
    public class FakeEmailServico : IEmailServico
    {
        public void Enviar(string destinatario, string email, string assunto, string corpo)
        {

        }
    }
}
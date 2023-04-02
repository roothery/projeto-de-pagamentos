using ContextoDePagamento.Shared.Comandos;

namespace ContextoDePagamento.Domain.Comandos
{
    public class ComandoResult : IComandoResult
    {
        public ComandoResult()
        {

        }

        public ComandoResult(bool sucesso, string mensagem)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
    }
}
using ContextoContextoDePagamento.Shared.ObjetosDeValores;

namespace ContextoDePagamento.Domain.ObjetosDeValores
{
    public class Email : ObjetoDeValor
    {
        public Email(string endereco)
        {
            Endereco = endereco;
        }

        public string Endereco { get; private set; }
    }
}
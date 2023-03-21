using ContextoContextoDePagamento.Shared.ObjetosDeValores;
using Flunt.Validations;

namespace ContextoDePagamento.Domain.ObjetosDeValores
{
    public class Email : ObjetoDeValor
    {
        public Email(string endereco)
        {
            Endereco = endereco;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Endereco, "Email.Endereco", "E-mail inválido"));
        }

        public string Endereco { get; private set; }
    }
}
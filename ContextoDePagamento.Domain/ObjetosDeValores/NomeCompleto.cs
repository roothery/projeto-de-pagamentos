using ContextoDePagamento.Shared.ObjetosDeValores;
using Flunt.Validations;

namespace ContextoDePagamento.Domain.ObjetosDeValores
{
    public class NomeCompleto : ObjetoDeValor
    {
        public NomeCompleto(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "NomeCompleto.Nome", "Nome deve conter pelo menos 3 caracteres")
                .HasMinLen(Sobrenome, 3, "NomeCompleto.Sobrenome", "Sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Nome, 40, "NomeCompleto.Nome", "Nome deve conter até 40 caracteres"));
        }

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
    }
}
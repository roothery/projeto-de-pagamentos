using ContextoDePagamento.Shared.ObjetosDeValores;
using Flunt.Validations;

namespace ContextoDePagamento.Domain.ObjetosDeValores
{
    public class Endereco : ObjetoDeValor
    {
        public Endereco(
            string rua,
            string numero,
            string bairro,
            string cidade,
            string estado,
            string pais,
            string cep)
        {
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            Cep = cep;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Rua, 3, "Endereco.Rua", "Rua deve conter pelo menos 3 caracteres"));
        }

        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Cep { get; set; }
    }
}
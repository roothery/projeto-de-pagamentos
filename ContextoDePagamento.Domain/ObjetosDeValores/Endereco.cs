using ContextoContextoDePagamento.Shared.ObjetosDeValores;

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
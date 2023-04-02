using ContextoDePagamento.Domain.Enums;

namespace ContextoContextoDePagamento.Domain.Comandos
{
    public class CriarAssinaturaPaypalComando
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }

        public string CodigoDaTransacao { get; set; }
        public string NumeroDoPagamento { get; set; }
        public DateTime DataDoPagamento { get; set; }
        public DateTime DateDeExpiracaoDoPagamento { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPago { get; set; }
        public string Proprietario { get; set; }
        public string DocumentoDoProprietario { get; set; }
        public ETipoDeDocumento TipoDeDocumentoDoProprietario { get; set; }
        public string EmailDoProprietario { get; set; }

        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Cep { get; set; }
    }
}
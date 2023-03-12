namespace ContextoDePagamento.Domain.Entidades
{
    public abstract class FormaDePagamento
    {
        public string Numero { get; set; }
        public DateTime DataDoPagamento { get; set; }
        public DateTime DateDeExpiracaoDoPagamento { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPago { get; set; }
        public string Proprietario { get; set; }
        public string Documento { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
    }

    public class Boleto : FormaDePagamento
    {
        public string CodigoDeBarras { get; set; }
        public string NumeroDoBoleto { get; set; }
    }

    public class CartaoDeCredito : FormaDePagamento
    {
        public string NomeDoTitular { get; set; }
        public string NumeroDoCartao { get; set; }
        public string NumeroDaUltimaTransacao { get; set; }
    }

    public class Paypal : FormaDePagamento
    {
        public string CodigoDaTransacao { get; set; }
    }
}
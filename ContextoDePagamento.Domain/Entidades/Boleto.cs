using ContextoDePagamento.Domain.ObjetosDeValores;

namespace ContextoDePagamento.Domain.Entidades
{
    public class Boleto : FormaDePagamento
    {
        public Boleto(
            string codigoDeBarras,
            string numeroDoBoleto,
            DateTime dataDoPagamento,
            DateTime dateDeExpiracaoDoPagamento,
            decimal total,
            decimal totalPago,
            string proprietario,
            Documento documento,
            Endereco endereco,
            Email email) : base(
                dataDoPagamento,
                dateDeExpiracaoDoPagamento,
                total,
                totalPago,
                proprietario,
                documento,
                endereco,
                email)
        {
            CodigoDeBarras = codigoDeBarras;
            NumeroDoBoleto = numeroDoBoleto;
        }

        public string CodigoDeBarras { get; private set; }
        public string NumeroDoBoleto { get; private set; }
    }
}
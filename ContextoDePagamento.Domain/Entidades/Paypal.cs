using ContextoDePagamento.Domain.ObjetosDeValores;

namespace ContextoDePagamento.Domain.Entidades
{
    public class Paypal : FormaDePagamento
    {
        public Paypal(
            string codigoDaTransacao,
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
            CodigoDaTransacao = codigoDaTransacao;
        }

        public string CodigoDaTransacao { get; private set; }
    }
}
namespace ContextoDePagamento.Domain.Entidades
{
    public class CartaoDeCredito : FormaDePagamento
    {
        public CartaoDeCredito(
            string nomeDoTitular,
            string numeroDoCartao,
            string numeroDaUltimaTransacao,
            DateTime dataDoPagamento,
            DateTime dateDeExpiracaoDoPagamento,
            decimal total,
            decimal totalPago,
            string proprietario,
            string documento,
            string endereco,
            string email) : base(
                dataDoPagamento,
                dateDeExpiracaoDoPagamento,
                total,
                totalPago,
                proprietario,
                documento,
                endereco,
                email)
        {
            NomeDoTitular = nomeDoTitular;
            NumeroDoCartao = numeroDoCartao;
            NumeroDaUltimaTransacao = numeroDaUltimaTransacao;
        }

        public string NomeDoTitular { get; private set; }
        public string NumeroDoCartao { get; private set; }
        public string NumeroDaUltimaTransacao { get; private set; }
    }
}
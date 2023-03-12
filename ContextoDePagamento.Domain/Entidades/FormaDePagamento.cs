namespace ContextoDePagamento.Domain.Entidades
{
    public abstract class FormaDePagamento
    {
        public FormaDePagamento(DateTime dataDoPagamento, DateTime dateDeExpiracaoDoPagamento, decimal total, decimal totalPago, string proprietario, string documento, string endereco, string email)
        {
            Numero = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            DataDoPagamento = dataDoPagamento;
            DateDeExpiracaoDoPagamento = dateDeExpiracaoDoPagamento;
            Total = total;
            TotalPago = totalPago;
            Proprietario = proprietario;
            Documento = documento;
            Endereco = endereco;
            Email = email;
        }

        public string Numero { get; private set; }
        public DateTime DataDoPagamento { get; private set; }
        public DateTime DateDeExpiracaoDoPagamento { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPago { get; private set; }
        public string Proprietario { get; private set; }
        public string Documento { get; private set; }
        public string Endereco { get; private set; }
        public string Email { get; private set; }
    }
}
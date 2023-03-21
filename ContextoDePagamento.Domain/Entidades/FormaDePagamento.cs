using ContextoContextoDePagamento.Shared.Entidades;
using ContextoDePagamento.Domain.ObjetosDeValores;
using Flunt.Validations;

namespace ContextoDePagamento.Domain.Entidades
{
    public abstract class FormaDePagamento : Entidade
    {
        public FormaDePagamento(
            DateTime dataDoPagamento,
            DateTime dateDeExpiracaoDoPagamento,
            decimal total,
            decimal totalPago,
            string proprietario,
            Documento documento,
            Endereco endereco,
            Email email)
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

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(0, Total, "FormaDePagamento.Total", "O total não pode ser zero")
                .IsGreaterOrEqualsThan(
                    Total,
                    TotalPago,
                    "FormaDePagamento.TotalPago", "O valor pago é menor que o valor do pagamento")
            );
        }

        public string Numero { get; private set; }
        public DateTime DataDoPagamento { get; private set; }
        public DateTime DateDeExpiracaoDoPagamento { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPago { get; private set; }
        public string Proprietario { get; private set; }
        public Documento Documento { get; private set; }
        public Endereco Endereco { get; private set; }
        public Email Email { get; private set; }
    }
}
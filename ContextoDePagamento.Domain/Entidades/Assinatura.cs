using ContextoDePagamento.Shared.Entidades;
using Flunt.Validations;

namespace ContextoDePagamento.Domain.Entidades
{
    public class Assinatura : Entidade
    {
        private IList<FormaDePagamento> _formasDePagamento;
        public Assinatura(DateTime? dataDeExpiracao)
        {
            DataDeCriacao = DateTime.Now;
            DataDaUltimaAtualizacao = DateTime.Now;
            DataDeExpiracao = dataDeExpiracao;
            Ativo = true;
            _formasDePagamento = new List<FormaDePagamento>();
        }

        public DateTime DataDeCriacao { get; private set; }
        public DateTime DataDaUltimaAtualizacao { get; private set; }
        public DateTime? DataDeExpiracao { get; private set; }
        public bool Ativo { get; private set; }
        public IReadOnlyCollection<FormaDePagamento> FormasDePagamento { get { return _formasDePagamento.ToArray(); } }

        public void AdicionarFormaDePagamento(FormaDePagamento formaDePagamento)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(
                    DateTime.Now,
                    formaDePagamento.DataDoPagamento,
                    "Assinatura.FormasDePagamento",
                    "A data do pagamento deve ser futura")
            );

            _formasDePagamento.Add(formaDePagamento);
        }

        public void AlterarAssinatura(bool status)
        {
            Ativo = status;
            DataDaUltimaAtualizacao = DateTime.Now;
        }
    }
}
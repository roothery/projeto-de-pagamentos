namespace ContextoDePagamento.Domain.Entidades
{
    public class Assinatura
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
        public IReadOnlyCollection<FormaDePagamento> FormasDePagamento { get; private set; }

        public void AdicionarFormaDePagamento(FormaDePagamento formaDePagamento)
        {
            _formasDePagamento.Add(formaDePagamento);
        }

        public void AlterarAssinatura(bool status)
        {
            Ativo = status;
            DataDaUltimaAtualizacao = DateTime.Now;
        }
    }
}
using ContextoContextoDePagamento.Shared.Entidades;
using ContextoDePagamento.Domain.ObjetosDeValores;

namespace ContextoDePagamento.Domain.Entidades
{
    public class Aluno : Entidade
    {
        private IList<Assinatura> _assinaturas;
        public Aluno(NomeCompleto nome, Documento documento, Email email)
        {
            Nome = nome;
            Documento = documento;
            Email = email;
            _assinaturas = new List<Assinatura>();

            AddNotifications(nome, documento, email);
        }

        public NomeCompleto Nome { get; private set; }
        public Documento Documento { get; private set; }
        public Email Email { get; private set; }
        public Endereco Endereco { get; private set; }
        public IReadOnlyCollection<Assinatura> Assinaturas { get { return _assinaturas.ToArray(); } }

        public void AdicionarAssinatura(Assinatura assinatura)
        {
            foreach (var ass in Assinaturas)
                ass.AlterarAssinatura(false);

            _assinaturas.Add(assinatura);
        }
    }
}
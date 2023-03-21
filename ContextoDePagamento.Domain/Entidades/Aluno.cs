using ContextoContextoDePagamento.Shared.Entidades;
using ContextoDePagamento.Domain.ObjetosDeValores;
using Flunt.Validations;

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
            var temAssinaturaAtiva = false;
            foreach (var ass in _assinaturas)
            {
                if (ass.Ativo)
                    temAssinaturaAtiva = true;
            }

            if (temAssinaturaAtiva)
                AddNotification("Aluno.Assinaturas", "Você já tem assinatura ativa");
        }
    }
}
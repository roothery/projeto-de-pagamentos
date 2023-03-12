namespace ContextoDePagamento.Domain.Entidades
{
    public class Aluno
    {
        private IList<Assinatura> _assinaturas;
        public Aluno(string nome, string sobrenome, string documento, string email)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Documento = documento;
            Email = email;
            _assinaturas = new List<Assinatura>();
        }

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Documento { get; private set; }
        public string Email { get; private set; }
        public string Endereco { get; private set; }
        public IReadOnlyCollection<Assinatura> Assinaturas { get { return _assinaturas.ToArray(); } }

        public void AdicionarAssinatura(Assinatura assinatura)
        {
            foreach (var ass in Assinaturas)
                ass.AlterarAssinatura(false);

            _assinaturas.Add(assinatura);
        }
    }
}
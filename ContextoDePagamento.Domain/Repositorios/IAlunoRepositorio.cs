using ContextoDePagamento.Domain.Entidades;

namespace ContextoDePagamento.Domain.Repositorios
{
    public interface IAlunoRepositorio
    {
        bool ExisteDocumento(string documento);
        bool ExisteEmail(string email);
        void CriarAssinatura(Aluno aluno);
    }
}
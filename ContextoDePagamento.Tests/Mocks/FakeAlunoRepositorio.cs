using ContextoDePagamento.Domain.Entidades;
using ContextoDePagamento.Domain.Repositorios;

namespace ContextoDePagamento.Tests.Mocks
{
    public class FakeAlunoRepositorio : IAlunoRepositorio
    {
        public void CriarAssinatura(Aluno aluno)
        {

        }

        public bool ExisteDocumento(string document)
        {
            if (document == "99999999999")
                return true;

            return false;
        }

        public bool ExisteEmail(string email)
        {
            if (email == "hello@balta.io")
                return true;

            return false;
        }
    }
}
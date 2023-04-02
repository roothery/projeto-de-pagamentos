using System.Linq.Expressions;
using ContextoDePagamento.Domain.Entidades;

namespace ContextoDePagamento.Domain.Queries
{
    public static class AlunoQueries
    {
        public static Expression<Func<Aluno, bool>> GetInformacoesAluno(string documento)
        {
            return x => x.Documento.Numero == documento;
        }
    }
}
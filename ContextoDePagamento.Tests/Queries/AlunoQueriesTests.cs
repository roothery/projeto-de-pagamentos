using ContextoDePagamento.Domain.Entidades;
using ContextoDePagamento.Domain.Enums;
using ContextoDePagamento.Domain.ObjetosDeValores;
using ContextoDePagamento.Domain.Queries;

namespace ContextoDePagamento.Tests
{
    [TestClass]
    public class AlunoQueriesTests
    {
        private IList<Aluno> _alunos;

        public AlunoQueriesTests()
        {
            _alunos = new List<Aluno>();
            for (var i = 0; i <= 10; i++)
            {
                _alunos.Add(new Aluno(
                    new NomeCompleto("Aluno", i.ToString()),
                    new Documento("1111111111" + i.ToString(), ETipoDeDocumento.CPF),
                    new Email(i.ToString() + "@balta.io")
                ));
            }
        }

        [TestMethod]
        public void Deve_retornar_nulo_quando_nao_existe_documento()
        {
            var expression = AlunoQueries.GetInformacoesAluno("12345678911");
            var aluno = _alunos.AsQueryable().Where(expression).FirstOrDefault();

            Assert.AreEqual(null, aluno);
        }

        [TestMethod]
        public void Deve_retornar_aluno_quando_existe_documento()
        {
            var expression = AlunoQueries.GetInformacoesAluno("11111111111");
            var aluno = _alunos.AsQueryable().Where(expression).FirstOrDefault();

            Assert.AreNotEqual(null, aluno);
        }
    }
}